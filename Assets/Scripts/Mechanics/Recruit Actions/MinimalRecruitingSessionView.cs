using System;
using UnityEngine;
using UnityEngine.UI;

public class MinimalRecruitingSessionView : MonoBehaviour
{
	public MinimalMessagingPlatformView platform;
	public Text scoreText;
    private System.Random r = new System.Random();
    IRecruitingSession session;
	public Text isOverText;
	public Text isRecruitedTest;
	public GameManager gameManager;

	void Start()
	{
        IUserProfile currentRecruitProfile = UserProfile.UserProfileGenerator(r) ;
		IPlayerProfile playerProfile = new TestPlayerProfile();
		session = new RecruitingSessionImpl(currentRecruitProfile, playerProfile, platform, gameManager);
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
		if (Input.GetKeyDown(KeyCode.A))
		{
			session.Abort(r);
		}
		this.scoreText.text = session.CultConversionChance.ToString();
		this.isOverText.text = session.IsOver.ToString();
		this.isRecruitedTest.text = session.IsRecruited.ToString();
	}

	private class TestPlayerProfile : IPlayerProfile
	{
		public Interest GetRandomInterest(System.Random r)
		{
			int roll = r.Next(100);
			if(roll < 50)
			{
				return new Interest("Athletics", "Watching Sports");
			}
			return new Interest("Religion", "Scientology");

		}
	}

	private class TestUserProfile : IUserProfile
	{
        User user = User.UserGenerator(new System.Random());
		Interest[] interests = { new Interest("Athletics", "Watching Sports"), new Interest("Entertainment", "Art") };

		public IMessage GenerateAbortResponse(System.Random r)
		{
			return new TestMessage("uh ok");
		}

		public IMessage GenerateComplimentResponse(System.Random r)
		{
			return new TestMessage("Oh my gawsh thx ;)");
		}

		public IMessage GenerateCultHintResponse(System.Random r, bool success, Interest interest)
		{
			if (success)
			{
				return new TestMessage("Oh wow I didn't realize you spent much time thinking about " + interest.ToString());
			}
			return new TestMessage("That's kinda weird you spend so much time thinking about " + interest.ToString());
		}

		public IMessage GenerateCultMentionResponse(System.Random r, bool success, Interest interest)
		{
			if (success)
			{
				return new TestMessage("I have always wondered about that and other " + interest.ToString() + "-related issues.");
			}
			return new TestMessage("That's, uh, that's really weird.");
		}

		public IMessage GenerateJoinCultResponse(System.Random r, bool success)
		{
			if (success)
			{
				return new TestMessage("You know, I think I will.");
			}
			return new TestMessage("Ew no what the hell.");
		}

		public IMessage GenerateSmallTalkResponse(System.Random r, bool success, Interest interest)
		{
			if (success)
			{
				return new TestMessage("Oooo, yes I love talking about stuff like " + interest);
			}
			return new TestMessage("Eh, I'm not really interested in " + interest);
		}

        public IUser GetUser()
        {
            return user;
        }

        public bool InterestedIn(Interest interest)
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

