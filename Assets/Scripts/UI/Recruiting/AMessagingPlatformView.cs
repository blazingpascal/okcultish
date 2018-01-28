using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AMessagingPlatformView : MonoBehaviour, IMessagingPlatform {
	public AAbortSelectable abortSelectable;
	public AResponseKeyboard keyboard;

	public abstract void AddPlayerMessage(IMessage msg);


	public abstract void AddResponse(IMessage msg, bool success);
}
