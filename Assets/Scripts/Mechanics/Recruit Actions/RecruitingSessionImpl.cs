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
	private int currentInterest;
	private IMessagingPlatform platform;
	private bool isOver = false;

	public void complimentRecruit(System.Random r)
	{
		IMessage msg = generateCompliment(r);
		platform.addPlayerMessage(msg);
		IMessage response = currentRecruitProfile.generateComplimentResponse(r);
		platform.addResponse(response, true);
		currentInterest += COMPLIMENT_DELTA;
	}

	public void smallTalkRecruit(System.Random r)
	{
		Interest interest = playerProfile.getRandomInterest(r);
		IMessage msg = generateSmallTalk(r, interest);
		bool success = currentRecruitProfile.interestedIn(interest);
		platform.addPlayerMessage(msg);
		IMessage response = currentRecruitProfile.generateSmallTalkResponse(r, success, interest);
		platform.addResponse(response, success);
		currentInterest += success ? SMALL_TALK_RECRUIT_DELTA_SUCCESS : SMALL_TALK_RECRUIT_DELTA_FAIL;
	}

	public void mentionCultToRecruit(Random r)
	{
		Interest interest = playerProfile.getRandomInterest(r);
		IMessage msg = generateCultMention(r, interest);
		int roll = r.Next(INTEREST_MAX);
		bool success = roll < currentInterest;
		platform.addPlayerMessage(msg);
		IMessage response = currentRecruitProfile.generateCultMentionResponse(r, success, interest);
		platform.addResponse(response, success);
		currentInterest += success ? CULT_MENTION_DELTA_SUCCEED : CULT_MENTION_DELTA_FAIL;
	}

	public void hintAtCultToRecruit(System.Random r)
	{
		Interest interest = playerProfile.getRandomInterest(r);
		IMessage msg = generateCultHint(r, interest);
		int roll = r.Next(INTEREST_MAX);
		bool success = roll < currentInterest;
		platform.addPlayerMessage(msg);
		IMessage response = currentRecruitProfile.generateCultHintResponse(r, success, interest);
		platform.addResponse(response, success);
		currentInterest += success ? CULT_HINT_DELTA_SUCCEED : CULT_HINT_DELTA_FAIL;
	}

	public void askToJoinCult(System.Random r)
	{
		IMessage msg = generateJoinCultMessage(r);
		int roll = r.Next(INTEREST_MAX);
		bool success = roll < currentInterest;
		platform.addPlayerMessage(msg);
		IMessage response = currentRecruitProfile.generateJoinCultResponse(r, success);
		platform.addResponse(response);
	}

	public IMessage generateCompliment(System.Random r)
	{
		throw new NotImplementedException();
	}

	public IMessage generateSmallTalk(System.Random r, Interest interest)
	{
		throw new NotImplementedException();
	}

	public IMessage generateCultMention(System.Random r, Interest interest)
	{
		throw new NotImplementedException();
	}

	public IMessage generateCultHint(System.Random r)
	{
		throw new NotImplementedException();
	}

	public IMessage generateJoinCultMessage(System.Random r)
	{
		return new TestMessage("")
	}

	public void setMessagingPlatform(IMessagingPlatform p)
	{
		this.platform = p;
	}

	public IMessage generateCultHint(Random r, Interest i)
	{
		// TODO
		return new TestMessage("Do you like hanging out with your friends? I love hanging with my friends.");
	}

	public bool IsOver
	{
		get { return this.isOver; }
	}

	private class TestMessage
	{
		private string msg;

		public TestMessage(string v)
		{
			this.msg = v;
		}
	}
}
