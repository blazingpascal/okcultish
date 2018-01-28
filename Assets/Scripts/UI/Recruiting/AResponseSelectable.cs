using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Selectable))]
public abstract class AResponseSelectable : MonoBehaviour
{
	protected Selectable selectable;

	public abstract void SetReaction(UnityAction reaction);

	public virtual void Start()
	{
		selectable = GetComponent<Selectable>();
	}


}