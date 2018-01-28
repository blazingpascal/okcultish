
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResponseSelectableImpl : AResponseSelectable
{
	Button button;

	public void Awake()
	{
		this.button = GetComponent<Button>() ?? GetComponentInChildren<Button>();
	}

	public override void SetReaction(UnityAction reaction)
	{
		button.onClick.RemoveAllListeners();
		button.onClick.AddListener(reaction);
	}
}

