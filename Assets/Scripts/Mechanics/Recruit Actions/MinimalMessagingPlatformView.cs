using System;
using UnityEngine;
using UnityEngine.UI;

public class MinimalMessagingPlatformView : MonoBehaviour, IMessagingPlatform
{
	public Text playerResponse;
	public Text dateResponse;

	public void addPlayerMessage(IMessage msg)
	{
		playerResponse.text = msg.getMessage();
	}

	public void addResponse(IMessage msg, bool success)
	{
		dateResponse.text = msg.getMessage();
		dateResponse.color = success ? Color.green : Color.red;
	}
}