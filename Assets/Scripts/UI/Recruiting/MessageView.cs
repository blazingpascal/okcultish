
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public abstract class AMessageView : MonoBehaviour
{
	private IMessage message;
	public string Message { get { return message.GetMessage(); } }

	public void SetMessage(IMessage message)
	{
		this.message = message;
		UpdateUI();
	}

	protected abstract void UpdateUI();
}

