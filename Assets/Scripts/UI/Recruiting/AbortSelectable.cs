
using System;
using UnityEngine.Events;
using UnityEngine.UI;

public class AbortSelectable : AAbortSelectable
{
	public Button abortButton;

	public override void SetReaction(UnityAction action)
	{
		abortButton.onClick.RemoveAllListeners();
		abortButton.onClick.AddListener(action);
	}
}

