using UnityEngine;
using UnityEngine.UI;

public class BatteryView : MonoBehaviour
{

    private int percentLeft;
    private int totalTime;
    private float timeLeft;

	public Image fillBar;

    private IGameManager manager;

    public int GetPercentLeft()
    {
        return percentLeft;
    }

    public float GetTimeLeft()
    {
        return timeLeft;
    }

    public void Awake()
    {
        manager = FindObjectOfType<GameManager>().GetComponent<IGameManager>();
        totalTime = manager.TotalTime;
        timeLeft = manager.SecondsLeft;
    }

    public void Update()
    {
        timeLeft = manager.SecondsLeft;
        percentLeft = ((int)(100 * GetTimeLeft() / totalTime));
		//GetComponent<Transform>().localScale = new Vector3(percentLeft / 100f, 1);
		fillBar.fillAmount = percentLeft * 0.01f;
    }

}

