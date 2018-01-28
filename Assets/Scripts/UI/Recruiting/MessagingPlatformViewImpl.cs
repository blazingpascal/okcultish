
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MessagingPlatformViewImpl : AMessagingPlatformView
{
    private const int TYPING_DELAY = 1000;
    private int internalTimer = 0;
    private bool waitForResponse = false;

	public ScrollRect messageHolder;
	public AMessageView playerMessageView;
	public AMessageView recruitMessageView;
	private GameManager gm;

	public void Start()
	{
		gm = FindObjectOfType<GameManager>();
		if(gm != null)
		{
			gm.SetMessagingPlatform(this);
		}
		abortSelectable.SetReaction(Abort);
	}

	private void Abort()
	{
		gm.GameState = GameState.Swiping;
	}

    private IGameManager manager;
    private List<AMessageView> queue = new List<AMessageView>();

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    public override void AddPlayerMessage(IMessage message)
    {
        AMessageView playerMsg = Instantiate(playerMessageView);
        playerMsg.SetMessage(message);
        AddMessageToUI(playerMsg);
    }

    private void TriggerAwaitResponse()
    {
        manager.IsUiLocked = true;
        StartCoroutine(AwaitResponse());
    }

    IEnumerator AwaitResponse()
    {
        foreach (AMessageView view in queue)
        {
            yield return new WaitForSeconds((float)TYPING_DELAY / 1000f);
            AddMessageToUI(view);
        }
        manager.IsUiLocked = false;
        queue.Clear();
    }

    private void AddMessageToUI(AMessageView msg)
    {
        msg.transform.SetParent(messageHolder.content.transform);
        msg.gameObject.SetActive(true);
        msg.transform.localScale = Vector3.one;
        UpdateScroll();
    }

    public override void AddResponse(IMessage message, bool success)
    {
        AMessageView recruitMsg = Instantiate(recruitMessageView);
        recruitMsg.SetMessage(message);
        queue.Add(recruitMsg);
        TriggerAwaitResponse();
        //AddMessageToUI(recruitMsg);
    }

    private void UpdateScroll()
    {
        Canvas.ForceUpdateCanvases();
        this.messageHolder.verticalNormalizedPosition = 0f;
        Canvas.ForceUpdateCanvases();
    }
}

