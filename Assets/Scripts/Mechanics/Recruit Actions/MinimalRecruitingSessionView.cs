using System;
using System.Collections.Generic;
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
        IUserProfile currentRecruitProfile = UserProfile.UserProfileGenerator(r);
        IPlayerProfile playerProfile = new TestPlayerProfile();
        session = new RecruitingSessionImpl(currentRecruitProfile, playerProfile, platform, gameManager);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            session.ComplimentRecruit(r);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            session.SmallTalkRecruit(r);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            session.HintAtCultToRecruit(r);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            session.MentionCultToRecruit(r);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            session.AskToJoinCult(r);
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
            return InterestsHandler.GetRandomInterest(r);

        }
    }

    private class TestUserProfile : IUserProfile
    {
        User user = User.UserGenerator(new System.Random());
        Interest[] interests = { new Interest("Athletics", "Watching Sports"), new Interest("Entertainment", "Art") };

		public ICollection<Interest> Interests
		{
			get
			{
				HashSet<Interest> interests = new HashSet<Interest>();
				foreach(Interest i in this.interests)
				{
					interests.Add(i);
				}
				return interests;
			}
		}

        public Sprite Image
        {
            get
            {
                return Resources.Load<Sprite>("images/profile_images/male_portraits/13887_10151657163159067_259519404_n.jpg");
            }
        }

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
            foreach (Interest i in interests)
            {
                if (i.Equals(interest))
                {
                    return true;
                }
            }
            return false;
        }

		public Sprite LoadPicture()
		{
			return new Sprite();
		}
	}
}

