using AssemblyCSharp;
using System;
using UnityEngine;

public class MinimalRecruitingSessionView : MonoBehaviour
{
	public MinimalMessagingPlatformView platform;
    private System.Random r = new System.Random();

    IRecruitingSession session;

	void Awake()
	{


	}

	void Start()
	{
        IUserProfile currentRecruitProfile = UserProfile.UserProfileGenerator(r) ;
		IPlayerProfile playerProfile = new TestPlayerProfile();
		session = new RecruitingSessionImpl(currentRecruitProfile, playerProfile, platform);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			session.complimentRecruit(r);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			session.smallTalkRecruit(r);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			session.hintAtCultToRecruit(r);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			session.mentionCultToRecruit(r);
		}
		if (Input.GetKeyDown(KeyCode.Alpha0))
		{
			session.askToJoinCult(r);
		}
	}

	private class TestPlayerProfile : IPlayerProfile
	{
		public Interest getRandomInterest(System.Random r)
		{
			int roll = r.Next(100);
			if(roll < 50)
			{
				return Interest.Athletics;
			}
			return Interest.Religion;

		}
	}

}

