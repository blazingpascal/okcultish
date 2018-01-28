using System;
using System.Collections.Generic;

public interface IPlayerProfile
{
    string CultName { get; }
    CultStyle CultStyle { get; }

	Interest GetRandomInterest(Random r);
}