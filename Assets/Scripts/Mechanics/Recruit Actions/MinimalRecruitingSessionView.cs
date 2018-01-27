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

	private class TestUserProfile : IUserProfile
	{
		Interest[] interests = { Interest.Athletics, Interest.Entertainment };
		public IMessage generateComplimentResponse(System.Random r)
		{
			return new TestMessage("Oh my gawsh thx ;)");
		}

		public IMessage generateCultHintResponse(System.Random r, bool success, Interest interest)
		{
			if (success)
			{
				return new TestMessage("Oh wow I didn't realize you spent much time thinking about " + interest.ToString());
			}
			return new TestMessage("That's kinda weird you spend so much time thinking about " + interest.ToString());
		}

		public IMessage generateCultMentionResponse(System.Random r, bool success, Interest interest)
		{
			if (success)
			{
				return new TestMessage("I have always wondered about that and other " + interest.ToString() + "-related issues.");
			}
			return new TestMessage("That's, uh, that's really weird.");
		}

		public IMessage generateJoinCultResponse(System.Random r, bool success)
		{
			if (success)
			{
				return new TestMessage("You know, I think I will.");
			}
			return new TestMessage("Ew no what the hell.");
		}

		public IMessage generateSmallTalkResponse(System.Random r, bool success, Interest interest)
		{
			if (success)
			{
				return new TestMessage("Oooo, yes I love talking about stuff like " + interest);
			}
			return new TestMessage("Eh, I'm not really interested in " + interest);
		}

		public bool interestedIn(Interest interest)
		{
			foreach(Interest i in interests)
			{
				if (i.Equals(interest))
				{
					return true;
				}
			}
			return false;
		}
	}
}

