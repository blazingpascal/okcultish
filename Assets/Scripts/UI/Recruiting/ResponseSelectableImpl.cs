
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResponseSelectableImpl : AResponseSelectable
{
	Button button;

	public void Start()
	{
		this.button = GetComponentInChildren<Button>();
	}

	public override void SetReaction(UnityAction reaction)
	{
		button.onClick.RemoveAllListeners();
		button.onClick.AddListener(reaction);
	}
}

