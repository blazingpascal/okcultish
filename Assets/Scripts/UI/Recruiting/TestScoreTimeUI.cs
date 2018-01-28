
using UnityEngine;
using UnityEngine.UI;

public class TestScoreTimeUI : MonoBehaviour
{
	private GameManager gm;
	public Text score;
	public Text time;
	void Start()
	{
		gm = FindObjectOfType<GameManager>();
	}

	void Update()
	{
		score.text = gm.ScoreForRound + "/" + gm.Quota;
		time.text = gm.TimeRemaining.ToString();
	}
}

