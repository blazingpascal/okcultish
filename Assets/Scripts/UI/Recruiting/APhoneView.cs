using UnityEngine;

public abstract class APhoneView : MonoBehaviour
{
	public APhoneToolbar toolbar;
	public RectTransform panelRect;
	public AMessagingPlatformView messaingPlatformView;
	public ASwipingPlatformView wipingPlatformView;
}

