using System;
using System.Collections.Generic;

public class UserProfile : IUserProfile
{
	private User user;
    private HashSet<Interest> interests = new HashSet<Interest>();

	private UserProfile (User user, ICollection<Interest> interests)
	{
        this.user = user;
        this.interests.UnionWith(interests);
	}

    public IMessage GenerateComplimentResponse(Random r)
    {
        // TODO
        return new MessageImpl("Thanks! <3");
    }

    public IMessage GenerateCultHintResponse(Random r, bool success, Interest interest)
    {
        // TODO
        return new MessageImpl(success ? "Oh, tell me more" : "uh ok");
    }

    public IMessage GenerateCultMentionResponse(Random r, bool success, Interest interest)
    {
        // TODO
        return new MessageImpl(success ? "That's really interesting" : "...");
    }

    public IMessage GenerateJoinCultResponse(Random r, bool success)
    {
        // TODO
        return new MessageImpl(success ? "Yes I will join your cult" : "No I will not join your weird cult");
    }

    public IMessage GenerateSmallTalkResponse(Random r, bool success, Interest interest)
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

    public static UserProfile UserProfileGenerator(Random random)
    {
        int interestCount = 3;

        Array allInterests = Enum.GetValues(typeof(Interest));
        HashSet<Interest> interests = new HashSet<Interest>();

        for (int i = 0; i< interestCount; i++)
        {

            interests.Add((Interest)allInterests.GetValue(random.Next(allInterests.Length)));
        }

        return new UserProfile(User.UserGenerator(random), interests);
    }

    public IMessage GenerateAbortResponse(Random r)
    {
        return new MessageImpl("lolno");
    }
}



