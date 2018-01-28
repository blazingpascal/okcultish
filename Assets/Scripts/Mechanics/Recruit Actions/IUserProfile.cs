using System;

public interface IUserProfile
{
	IMessage GenerateComplimentResponse(Random r);
	bool InterestedIn(Interest interest);
	IMessage GenerateSmallTalkResponse(Random r, bool success, Interest interest);
	IMessage GenerateCultMentionResponse(Random r, bool success, Interest interest);
	IMessage GenerateCultHintResponse(Random r, bool success, Interest interest);
	IMessage GenerateJoinCultResponse(Random r, bool success);
	IMessage GenerateAbortResponse(Random r);
    IUser GetUser();
    UnityEngine.Sprite Image { get; }
}