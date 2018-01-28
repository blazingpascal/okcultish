using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserProfile : IUserProfile
{
	private User user;
    private HashSet<Interest> interests = new HashSet<Interest>();

	public ICollection<Interest> Interests
	{
		get
		{
			return interests;
		}
	}

	private UserProfile (User user, ICollection<Interest> interests)
	{
        this.user = user;
        this.interests.UnionWith(interests);
	}

    public IMessage GenerateComplimentResponse(System.Random r)
    {
        // TODO
        return new MessageImpl("Thanks! <3");
    }

    public IMessage GenerateCultHintResponse(System.Random r, bool success, Interest interest)
    {
		// TODO
		return new MessageImpl(InterestsHandler.GenerateCultHintResponseMessage(r, success, interest));
    }

    public IMessage GenerateCultMentionResponse(System.Random r, bool success, Interest interest)
    {
		// TODO
		return new MessageImpl(InterestsHandler.GenerateCultMentionResponseMessage(r, success, interest));
	}

    public IMessage GenerateJoinCultResponse(System.Random r, bool success)
    {
        // TODO
        return new MessageImpl(success ? "Yes I will join your cult" : "No I will not join your weird cult");
    }

    public IMessage GenerateSmallTalkResponse(System.Random r, bool success, Interest interest)
    {
		// TODO
		return new MessageImpl(InterestsHandler.GenerateSmallTalkResponseMessage(r, success, interest));
    }

    public bool InterestedIn(Interest interest)
    {
        return interests.Contains(interest);
    }

    public IUser GetUser()
    {
        return user;
    }

    public static UserProfile UserProfileGenerator(System.Random random)
    {
		System.Random r = new System.Random();
		// TODO: Replace with real interests
		List<Interest> interests = new List<Interest>
		{
			InterestsHandler.GetRandomInterest(r),
			InterestsHandler.GetRandomInterest(r),
			InterestsHandler.GetRandomInterest(r),
		};

        return new UserProfile(User.UserGenerator(random), interests);
    }

    public IMessage GenerateAbortResponse(System.Random r)
    {
        return new MessageImpl("lolno");
    }

	public Sprite LoadPicture()
	{
		return null;
	}
}

