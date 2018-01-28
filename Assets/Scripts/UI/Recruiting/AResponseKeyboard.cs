
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class AResponseKeyboard : MonoBehaviour {
	public AResponseSelectable complimentSelectable;
	public AResponseSelectable smallTalkSelectable;
	public AResponseSelectable mentionCultSelectable;
	public AResponseSelectable hintAtCultSelectable;
	public AResponseSelectable joinCultSelectable;

	private IRecruitingSession session;
    private IGameManager manager;

	// Use this for initialization
	void Start()
	{
        manager = FindObjectOfType<GameManager>();
		session = FindObjectOfType<GameManager>().CurrentRecruitingSession;
		if(session == null)
		{
			session = new RecruitingSessionImpl(UserProfile.UserProfileGenerator(new System.Random()), 
				new TestProfile(), FindObjectOfType<AMessagingPlatformView>(), FindObjectOfType<GameManager>());
		}
		complimentSelectable.SetReaction(Compliment);
		smallTalkSelectable.SetReaction(SmallTalk);
		mentionCultSelectable.SetReaction(MentionCult);
		hintAtCultSelectable.SetReaction(HintAtCult);
		joinCultSelectable.SetReaction(JoinCult);
	}

	private void JoinCult()
	{
		session.AskToJoinCult(new System.Random());
	}

	private void HintAtCult()
	{
		session.HintAtCultToRecruit(new System.Random());
	}

	private void MentionCult()
	{
		session.MentionCultToRecruit(new System.Random());
	}

	private void SmallTalk()
	{
		session.SmallTalkRecruit(new System.Random());
	}

	private void Compliment()
	{
		session.ComplimentRecruit(new System.Random());
	}

	// Update is called once per frame
	void Update () {
        SetUiInteractable(!manager.IsUiLocked);
	}

    private void SetUiInteractable(bool interactable)
    {
        complimentSelectable.GetComponentInChildren<Selectable>().interactable = interactable;
        smallTalkSelectable.GetComponentInChildren<Selectable>().interactable = interactable;
        mentionCultSelectable.GetComponentInChildren<Selectable>().interactable = interactable;
        hintAtCultSelectable.GetComponentInChildren<Selectable>().interactable = interactable;
        joinCultSelectable.GetComponentInChildren<Selectable>().interactable = interactable;
    }
}