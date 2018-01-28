using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IGameManager
{
	private const int QUOTA_INCREASE_PER_ROUND = 1;
	private const long MS_PER_ROUND = 30000;
	private const int MS_INCREASE_PER_ROUND = 0;

	private IPlayerProfile playerProfile = new TestProfile();
	private UserProfile currentMatch;
	private GameState gameState;

	internal void SetMessagingPlatform(MessagingPlatformViewImpl messagingPlatformViewImpl)
	{
		CurrentRecruitingSession.SetMessagingPlatform(messagingPlatformViewImpl);
	}

	public GameState GameState
	{
		get { return gameState; }
		set
		{
			if (value != GameState)
			{
				gameState = value;
				SwitchToScene(gameState);
			}
		}
	}

	private void SwitchToScene(GameState gameState)
	{
		switch (gameState)
		{
			case GameState.Swiping:
				SceneManager.LoadScene(0);
				break;
			case GameState.Recruiting:
				SceneManager.LoadScene(1);
				break;
			default:
				break;
		}
	}



	public int TotalScore { get; private set; }
	public int ScoreForRound { get; private set; }
	public int Quota { get; private set; }
	public long TimeRemaining { get; private set; }
	public int CurrentRound { get; private set; }
	public bool HasLost { get; private set; }
	public bool IsRunning { get; private set; }
	internal IRecruitingSession CurrentRecruitingSession { get; set; }

	public IUserProfile CurrentMatch
	{
		get
		{
			return currentMatch;
		}

		set
		{
			currentMatch = (UserProfile)value;
			CurrentRecruitingSession = new RecruitingSessionImpl(currentMatch, playerProfile, null, this);
		}
	}

	public IPlayerProfile PlayerProfile
	{
		get
		{
			return playerProfile;
		}

		set
		{
			playerProfile = value;
		}
	}

	public GameManager()
	{

	}

	void Start()
	{
		DontDestroyOnLoad(transform.gameObject);
		CurrentRound = 0;
		ScoreForRound = 0;
		InitNewRound();
		HasLost = false;
		IsRunning = false;
	}

	void Update()
	{
		TimeRemaining -= (long)(1000 * Time.deltaTime);
		if (TimeRemaining <= 0)
		{
			HasLost = ScoreForRound >= Quota;
			IsRunning = false;
		}
	}

	private void InitNewRound()
	{
		CurrentRound++;
		TotalScore += ScoreForRound;
		ScoreForRound = 0;
		Quota += QUOTA_INCREASE_PER_ROUND;
		TimeRemaining = MS_PER_ROUND + MS_INCREASE_PER_ROUND * CurrentRound;

	}

	public void IncrementRecruitCount()
	{
		ScoreForRound++;
	}

	public void EndGame(bool succeeded)
	{
		IsRunning = false;
	}
}
