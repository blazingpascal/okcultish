using UnityEngine;
using UnityEngine.UI;

public class MinimalMessagingPlatformView : MonoBehaviour, IMessagingPlatform
{
	public Text dateResponse;
	public Text playerResponse;

	public void AddPlayerMessage(IMessage msg)
	{
		playerResponse.text = msg.GetMessage();
	}

	public void AddResponse(IMessage msg, bool success)
	{
		dateResponse.text = msg.GetMessage();
		dateResponse.color = success ? Color.green : Color.red;
	}
}