using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class UserProfile : IUserProfile
{
	private IUser user;
    private HashSet<Interest> interests = new HashSet<Interest>();
    public Sprite Image { get; private set; }

    private const string RESOURCES_PATH = @"Assets/Resources/";
    private const string FEMALE_IMAGES_PATH = @"images/profile_images/female_portraits/";
    private const string MALE_IMAGES_PATH = @"images/profile_images/male_portraits/";

    private static List<String> male_filenames = new List<String>(Directory.GetFiles(RESOURCES_PATH + MALE_IMAGES_PATH));
    private static List<String> female_filenames = new List<String>(Directory.GetFiles(RESOURCES_PATH + FEMALE_IMAGES_PATH));

	public ICollection<Interest> Interests
	{
		get
		{
			return interests;
		}
	}

    private UserProfile(IUser user, ICollection<Interest> interests, string imageFilename)
    {
        this.user = user;
        this.interests.UnionWith(interests);

        string path = (user.Gender == Gender.Female ? FEMALE_IMAGES_PATH : MALE_IMAGES_PATH) + imageFilename;

        Image = Resources.Load<Sprite>(path);
	}

    public IMessage GenerateComplimentResponse(System.Random r)
    {
        // TODO
        return new MessageImpl("Thanks! <3");
    }

    public IMessage GenerateCultHintResponse(System.Random r, bool success, Interest interest)
    {
		return new MessageImpl(InterestsHandler.GenerateCultHintResponseMessage(r, success, interest));
    }

    public IMessage GenerateCultMentionResponse(System.Random r, bool success, Interest interest)
    {
		return new MessageImpl(InterestsHandler.GenerateCultMentionResponseMessage(r, success, interest));
	}

    public IMessage GenerateJoinCultResponse(System.Random r, bool success)
    {
        return new MessageImpl(success ? "Yes I will join your cult" : "No I will not join your weird cult");
    }

    public IMessage GenerateSmallTalkResponse(System.Random r, bool success, Interest interest)
    {
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
        IUser user = User.UserGenerator(random);

        int interestCount = 3;
        List<Interest> interests = new List<Interest>();
        for (int i=0; i<interestCount; i++)
        {
            interests.Add(InterestsHandler.GetRandomInterest(random));
        }

        String filename = user.Gender == Gender.Female ?
            female_filenames[random.Next(female_filenames.Count)] :
            male_filenames[random.Next(male_filenames.Count)];

        return new UserProfile(user, interests, Path.GetFileNameWithoutExtension(filename));
    }

    public IMessage GenerateAbortResponse(System.Random r)
    {
        return new MessageImpl("lolno");
    }
}

