using System.Collections.Generic;

public interface IUserProfile
{
	ICollection<Interest> Interests { get; }

	IMessage GenerateComplimentResponse(System.Random r);
	bool InterestedIn(Interest interest);
	IMessage GenerateSmallTalkResponse(System.Random r, bool success, Interest interest);
	IMessage GenerateCultMentionResponse(System.Random r, bool success, Interest interest);
	IMessage GenerateCultHintResponse(System.Random r, bool success, Interest interest);
	IMessage GenerateJoinCultResponse(System.Random r, bool success);
	IMessage GenerateAbortResponse(System.Random r);
    IUser GetUser();
    UnityEngine.Sprite Image { get; }
}