using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AwardScreenUI : MonoBehaviour
{
	public Button exit;
	public Button continueButton;
	public Text scoreText;

	// Use this for initialization
	void Start()
	{
		GameManager gm = FindObjectOfType<GameManager>();
		scoreText.text = string.Format("{0}/{1} recruited! {2} so far!", gm.ScoreForRound, gm.Quota, gm.TotalScore);
		exit.onClick.AddListener(() => Application.Quit());
		continueButton.onClick.AddListener(() => Continue(gm));
	}

	private void Continue(GameManager gm)
	{
		gm.InitNewRound();
		gm.GameState = GameState.Swiping;
	}
}
