using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

interface IRecruitingSession
{
	void complimentRecruit(Random r);
	void smallTalkRecruit(Random r);
	void mentionCultToRecruit(Random r);
	void hintAtCultToRecruit(Random r);
	void askToJoinCult(Random r);
	IMessage GenerateCompliment(Random r);
	IMessage GenerateSmallTalk(Random r, Interest i);
	IMessage GenerateCultMention(Random r, Interest i);
	IMessage GenerateCultHint(Random r, Interest i);
	IMessage GenerateJoinCultMessage(Random r);
	void SetMessagingPlatform(IMessagingPlatform p);
	bool IsOver { get; }
	bool IsRecruited { get; }
	void Abort(Random r);
	int CultConversionChance { get; }
}

