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

	public GameManager()
	{

	}

	void Start()
	{
		CurrentRound = 0;
		ScoreForRound = 0;
		InitNewRound();
		HasLost = false;
	}

	void Update()
	{
		TimeRemaining -= (long)(1000 * Time.deltaTime);
		if (TimeRemaining <= 0)
		{
			HasLost = ScoreForRound >= Quota;
		}
	}

	public void SetCurrentMatch(UserProfile match)
	{
		currentMatch = match;
	}

	public void IncrementScore()
	{
		ScoreForRound++;
	}

	public bool TryToRecruit(System.Random random)
	{
		bool success = random.Next(100) < currentMatch.GetUser().GetConversionChance();
		if (success)
		{
			ScoreForRound++;
		}
		currentMatch = null;
		return success;
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
		this.IncrementScore();
	}
}
