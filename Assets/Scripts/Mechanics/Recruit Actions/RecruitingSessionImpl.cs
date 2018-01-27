using AssemblyCSharp;
using System;

public class RecruitingSessionImpl : IRecruitingSession
{
	public const int COMPLIMENT_DELTA = 5;
	public const int SMALL_TALK_RECRUIT_DELTA_SUCCESS = 10;
	public const int SMALL_TALK_RECRUIT_DELTA_FAIL = -2;
	public const int CULT_HINT_DELTA_SUCCEED = 20;
	public const int CULT_HINT_DELTA_FAIL = -10;
	public const int CULT_MENTION_DELTA_SUCCEED = 30;
	public const int CULT_MENTION_DELTA_FAIL = -50;
	public const int INTEREST_MAX = 100;

	private IUserProfile currentRecruitProfile;
	private IPlayerProfile playerProfile;
	private IMessagingPlatform platform;
	private IGameManager gameManager;

	public RecruitingSessionImpl(IUserProfile currentRecruitProfile, IPlayerProfile playerProfile, IMessagingPlatform platform, IGameManager manager)
	{
		this.currentRecruitProfile = currentRecruitProfile;
		this.playerProfile = playerProfile;
		this.platform = platform;
		this.gameManager = manager;
	}

	public void complimentRecruit(System.Random r)
	{
		IMessage msg = GenerateCompliment(r);
		platform.AddPlayerMessage(msg);
		IMessage response = currentRecruitProfile.generateComplimentResponse(r);
		platform.addResponse(response, true);
		currentRecruitProfile.GetUser().ChangeConversionChance(COMPLIMENT_DELTA);

	}

	public void smallTalkRecruit(System.Random r)
	{
		Interest interest = playerProfile.getRandomInterest(r);
		IMessage msg = generateSmallTalk(r, interest);
		bool success = currentRecruitProfile.interestedIn(interest);
		platform.addPlayerMessage(msg);
		IMessage response = currentRecruitProfile.generateSmallTalkResponse(r, success, interest);
		platform.addResponse(response, success);
        currentRecruitProfile.GetUser().ChangeConversionChance(success ? SMALL_TALK_RECRUIT_DELTA_SUCCESS : SMALL_TALK_RECRUIT_DELTA_FAIL);
	}

	public void mentionCultToRecruit(Random r)
	{
		Interest interest = playerProfile.GetRandomInterest(r);
		IMessage msg = GenerateCultMention(r, interest);
		int roll = r.Next(INTEREST_MAX);
		bool success = currentRecruitProfile.interestedIn(interest) && roll < currentRecruitProfile.GetUser().GetConversionChance();
		platform.addPlayerMessage(msg);
		IMessage response = currentRecruitProfile.generateCultMentionResponse(r, success, interest);
		platform.addResponse(response, success);
        currentRecruitProfile.GetUser().ChangeConversionChance(success ? CULT_MENTION_DELTA_SUCCEED : CULT_MENTION_DELTA_FAIL);
	}

	public void hintAtCultToRecruit(System.Random r)
	{
		Interest interest = playerProfile.GetRandomInterest(r);
		IMessage msg = GenerateCultHint(r, interest);
		int roll = r.Next(INTEREST_MAX);
		bool success = currentRecruitProfile.interestedIn(interest) && roll < currentRecruitProfile.GetUser().GetConversionChance();
        platform.addPlayerMessage(msg);
		IMessage response = currentRecruitProfile.generateCultHintResponse(r, success, interest);
		platform.addResponse(response, success);
        currentRecruitProfile.GetUser().ChangeConversionChance(success ? CULT_HINT_DELTA_SUCCEED : CULT_HINT_DELTA_FAIL);
	}

	public void askToJoinCult(System.Random r)
	{
		IMessage msg = GenerateJoinCultMessage(r);
		int roll = r.Next(INTEREST_MAX);
		bool success = roll < currentRecruitProfile.GetUser().GetConversionChance();
		platform.AddPlayerMessage(msg);
		IMessage response = currentRecruitProfile.GenerateJoinCultResponse(r, success);
		platform.AddResponse(response, success);
		if (success)
		{
			this.gameManager.IncrementRecruitCount();
		}
		//this.cultConversionChance = -1;
	}

	public IMessage GenerateCompliment(System.Random r)
	{
		return new MessageImpl(ComplimentGenerator.GenerateCompliment(r));
	}

	public IMessage GenerateSmallTalk(System.Random r, Interest interest)
	{
		// TODO
		return new TestMessage("How do you feel about " + interest.ToString());
	}

	public IMessage GenerateCultMention(System.Random r, Interest interest)
	{
		// TODO
		return new TestMessage("Do you think you could win a cage match with Jesus?");
	}

	public IMessage GenerateJoinCultMessage(System.Random r)
	{
		// TODO
		return new TestMessage("Hey, wanna join my cult?");
	}

	public void SetMessagingPlatform(IMessagingPlatform p)
	{
		this.platform = p;
	}

	public IMessage GenerateCultHint(Random r, Interest i)
	{
		// TODO
		return new TestMessage("Do you like hanging out with your friends? I love hanging with my friends.");
	}

	public void Abort()
	{
		this.cultConversionChance = -1;
	}

	public bool IsOver
	{
		get { return this.currentRecruitProfile.GetUser().GetConversionChance() < 0; }
	}

	public bool IsRecruited
	{
		get
		{
			return this.currentRecruitProfile.GetUser().GetConversionChance() > INTEREST_MAX;
		}
	}

	public int CultConversionChance
	{
		get { return this.currentRecruitProfile.GetUser().GetConversionChance(); }
	}
}
