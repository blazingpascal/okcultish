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
	IMessage generateCompliment(Random r);
	IMessage generateSmallTalk(Random r, Interest i);
	IMessage generateCultMention(Random r, Interest i);
	IMessage generateCultHint(Random r, Interest i);
	IMessage generateJoinCultMessage(Random r);
	void setMessagingPlatform(IMessagingPlatform p);
	bool IsOver { get; }
	bool IsRecruited { get; }
	void abort();
	int CultConversionChance { get; }
}

