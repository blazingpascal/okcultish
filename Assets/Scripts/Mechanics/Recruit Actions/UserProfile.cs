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
        return new MessageImpl(success ? "Oh, tell me more" : "uh ok");
    }

    public IMessage GenerateCultMentionResponse(System.Random r, bool success, Interest interest)
    {
        // TODO
        return new MessageImpl(success ? "That's really interesting" : "...");
    }

    public IMessage GenerateJoinCultResponse(System.Random r, bool success)
    {
        // TODO
        return new MessageImpl(success ? "Yes I will join your cult" : "No I will not join your weird cult");
    }

    public IMessage GenerateSmallTalkResponse(System.Random r, bool success, Interest interest)
    {
        // TODO
        return new MessageImpl(success ? "I too am interested in this" : "k.");
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
        // TODO: Replace with real interests
        List<Interest> interests = new List<Interest>
        {
            new Interest("Entertainment", "80s Avante Garde French Film"),
            new Interest("Health", "Veganism"),
            new Interest("Music", "Third Century Rock Opera")
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

