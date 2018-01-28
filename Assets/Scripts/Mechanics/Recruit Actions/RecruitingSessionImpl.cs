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

	public void ComplimentRecruit(Random r)
	{
		IMessage msg = GenerateCompliment(r);
		platform.AddPlayerMessage(msg);
		if (!IsOver)
		{
			IMessage response = currentRecruitProfile.GenerateComplimentResponse(r);
			platform.AddResponse(response, true);
			currentRecruitProfile.GetUser().ChangeConversionChance(COMPLIMENT_DELTA);
		}

	}

	public void SmallTalkRecruit(Random r)
	{
		Interest interest = playerProfile.GetRandomInterest(r);
		IMessage msg = GenerateSmallTalk(r, interest);
		platform.AddPlayerMessage(msg);
		if (!IsOver)
		{
			bool success = currentRecruitProfile.InterestedIn(interest);
			IMessage response = currentRecruitProfile.GenerateSmallTalkResponse(r, success, interest);
			platform.AddResponse(response, success);
			currentRecruitProfile.GetUser().ChangeConversionChance(success ? SMALL_TALK_RECRUIT_DELTA_SUCCESS : SMALL_TALK_RECRUIT_DELTA_FAIL);
		}
	}

	public void MentionCultToRecruit(Random r)
	{
		Interest interest = playerProfile.GetRandomInterest(r);
		IMessage msg = GenerateCultMention(r, interest);
		platform.AddPlayerMessage(msg);
		if (!IsOver)
		{
			int roll = r.Next(INTEREST_MAX);
			bool success = currentRecruitProfile.InterestedIn(interest) && roll < currentRecruitProfile.GetUser().GetConversionChance();
			IMessage response = currentRecruitProfile.GenerateCultMentionResponse(r, success, interest);
			platform.AddResponse(response, success);
			currentRecruitProfile.GetUser().ChangeConversionChance(success ? CULT_MENTION_DELTA_SUCCEED : CULT_MENTION_DELTA_FAIL);
		}
	}

	public void HintAtCultToRecruit(Random r)
	{
		Interest interest = playerProfile.GetRandomInterest(r);
		IMessage msg = GenerateCultHint(r, interest);
		platform.AddPlayerMessage(msg);
		if (!IsOver)
		{
			int roll = r.Next(INTEREST_MAX);
			bool success = currentRecruitProfile.InterestedIn(interest) && roll < currentRecruitProfile.GetUser().GetConversionChance();
			IMessage response = currentRecruitProfile.GenerateCultHintResponse(r, success, interest);
			platform.AddResponse(response, success);
			currentRecruitProfile.GetUser().ChangeConversionChance(success ? CULT_HINT_DELTA_SUCCEED : CULT_HINT_DELTA_FAIL);
		}
	}

	public void AskToJoinCult(Random r)
	{
		IMessage msg = GenerateJoinCultMessage(r);
		int roll = r.Next(INTEREST_MAX);
		platform.AddPlayerMessage(msg);
		if (!IsOver)
		{
			bool success = roll < currentRecruitProfile.GetUser().GetConversionChance();
			IMessage response = currentRecruitProfile.GenerateJoinCultResponse(r, success);
			platform.AddResponse(response, success);
			if (success)
			{
				gameManager.IncrementRecruitCount();
			}
			currentRecruitProfile.GetUser().ChangeConversionChance(-1000);
		}
	}

	public IMessage GenerateCompliment(Random r)
	{
		return new MessageImpl(MessageGenerator.GenerateCompliment(r));
	}

    public IMessage GenerateSmallTalk(Random r, Interest interest)
    {
        return new MessageImpl(InterestsHandler.GeneratSmallTalkMessage(r, interest));
    }

    public IMessage GenerateCultMention(Random r, Interest interest)
    {
        return new MessageImpl(InterestsHandler.GenerateCultMentionMessage(r, interest));
    }

	public IMessage GenerateJoinCultMessage(Random r)
	{
		// TODO
		return new TestMessage("Hey, wanna join my cult?");
	}

	public void SetMessagingPlatform(IMessagingPlatform p)
	{
		this.platform = p;
	}

    public IMessage GenerateCultHint(Random r, Interest interest)
    {
        return new MessageImpl(InterestsHandler.GenerateCultHintMessage(r, interest));
    }


	public void Abort(Random r)
	{
		platform.AddPlayerMessage(GenerateAbortMessage(r));
		platform.AddResponse(currentRecruitProfile.GenerateAbortResponse(r), false);
		// this.cultConversionChance = -1;
	}

	private IMessage GenerateAbortMessage(Random r)
	{
		return new MessageImpl(MessageGenerator.GenerateAbort(r));
	}

	public bool IsOver
	{
		get { return this.currentRecruitProfile.GetUser().GetConversionChance() <= 0; }
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
