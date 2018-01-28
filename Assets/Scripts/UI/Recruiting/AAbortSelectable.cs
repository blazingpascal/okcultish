using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Selectable))]
public abstract class AAbortSelectable : MonoBehaviour
{
	public abstract void SetReaction(UnityAction action);
}