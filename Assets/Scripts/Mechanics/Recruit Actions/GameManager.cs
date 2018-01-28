using System;
using UnityEngine;

public class GameManager : MonoBehaviour, IGameManager
{
	private const int QUOTA_INCREASE_PER_ROUND = 1;
	private const long MS_PER_ROUND = 30000;
	private const int MS_INCREASE_PER_ROUND = 0;

	private UserProfile currentMatch;
	public int TotalScore { get; private set; }
	public int ScoreForRound { get; private set; }
	public int Quota { get; private set; }
	public long TimeRemaining { get; private set; }
	public int CurrentRound { get; private set; }
	public bool HasLost { get; private set; }
    public bool IsRunning { get; private set; }
    public bool IsUiLocked { get; set; }

	internal IRecruitingSession CurrentRecruitingSession { get; set; }

    private float unlockTime;

    public int SecondsLeft
    {
        get
        {
            return (int)TimeRemaining / 1000;
        }
    }

    public int TotalTime
    {
        get
        {
            return (int)MS_PER_ROUND / 1000;
        }
    }

    public GameManager()
	{

	}

	void Start()
	{
		CurrentRound = 0;
		ScoreForRound = 0;
		InitNewRound();
		HasLost = false;
        IsRunning = false;
	}

/*	void Update()
	{
		TimeRemaining -= (long)(1000 * Time.deltaTime);
		if (TimeRemaining <= 0)
		{
			HasLost = ScoreForRound >= Quota;
            IsRunning = false;
		}

        if (IsUiLocked && Time.time >= unlockTime)
        {
            IsUiLocked = false;
        }
	}*/

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

    public void LockUiFor(int milliseconds)
    {
        float currentTime = Time.time;
        unlockTime = currentTime + milliseconds / 1000f;
        IsUiLocked = true;
    }
}
