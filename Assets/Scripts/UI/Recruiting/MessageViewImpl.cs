using System;
using UnityEngine.UI;

public class MessageViewImpl : AMessageView
{
	public Text text;

	protected override void UpdateUI()
	{
		text.text = Message;
	}
}

