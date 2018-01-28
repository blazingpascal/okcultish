using System;
using System.Collections.Generic;

public class TestProfile : IPlayerProfile
{
	public List<Interest> interests;

	public TestProfile()
	{
		interests = new List<Interest>();
		for(int i = 0; i < 3; i++)
		{
			interests.Add(InterestsHandler.GetRandomInterest(new Random()));
			interests.Add(InterestsHandler.GetRandomInterest(new Random()));
			interests.Add(InterestsHandler.GetRandomInterest(new Random()));
		}
	}

	public Interest GetRandomInterest(Random r)
	{
		return interests[r.Next(interests.Count)];
	}
}