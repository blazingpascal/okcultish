
using System;
using UnityEngine;
using UnityEngine.UI;

public class MessagingPlatformViewImpl : AMessagingPlatformView
{

	public ScrollRect messageHolder;
	public AMessageView playerMessageView;
	public AMessageView recruitMessageView;

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			foo(Vector2.zero);
		}	
	}

	private void foo(Vector2 arg0)
	{
		UpdateScroll();
	}

	public override void AddPlayerMessage(IMessage message)
	{
		AMessageView playerMsg = Instantiate(playerMessageView);
		playerMsg.SetMessage(message);
		playerMsg.transform.SetParent(messageHolder.content.transform);
		playerMsg.gameObject.SetActive(true);
		playerMsg.transform.localScale = Vector3.one;
		UpdateScroll();
	}

	public override void AddResponse(IMessage message, bool success)
	{
		AMessageView recruitMsg = Instantiate(recruitMessageView);
		recruitMsg.SetMessage(message);
		recruitMsg.transform.SetParent(messageHolder.content.transform);
		recruitMsg.gameObject.SetActive(true);
		recruitMsg.transform.localScale = Vector3.one;
		UpdateScroll();
	}

	private void UpdateScroll()
	{
		Canvas.ForceUpdateCanvases();
		this.messageHolder.verticalNormalizedPosition = 0f;
		Canvas.ForceUpdateCanvases();
	}
}

