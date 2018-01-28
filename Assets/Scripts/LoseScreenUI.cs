using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreenUI : MonoBehaviour
{
	public Text daysServedText;
	public Text totalScoreText;
	public Button playAgainButton;
	public Button exit;

	// Use this for initialization
	void Start()
	{
		GameManager gm = FindObjectOfType<GameManager>();
		daysServedText.text = string.Format("Days Served: {0}", gm.CurrentRound);
		totalScoreText.text = string.Format("People Recruited: {0}", gm.TotalScore);
		exit.onClick.AddListener(() => Application.Quit());
	}
}
