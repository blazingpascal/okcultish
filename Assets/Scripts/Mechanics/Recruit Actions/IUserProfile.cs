using System;

public interface IUserProfile
{
	IMessage generateComplimentResponse(Random r);
	bool interestedIn(Interest interest);
	IMessage generateSmallTalkResponse(Random r, bool success, Interest interest);
	IMessage generateCultMentionResponse(Random r, bool success, Interest interest);
	IMessage generateCultHintResponse(Random r, bool success, Interest interest);
	IMessage generateJoinCultResponse(Random r, bool success);
}