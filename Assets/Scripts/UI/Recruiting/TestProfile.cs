using System;
using System.Collections.Generic;

public class TestProfile : IPlayerProfile
{
	public List<Interest> interests = new List<Interest>
		{
			new Interest("Entertainment", "80s Avante Garde French Film"),
			new Interest("Health", "Veganism"),
			new Interest("Athletics", "Deeply Uncomfortable Aerobics")
		};

	public TestProfile()
	{
		
	}

	public Interest GetRandomInterest(Random r)
	{
		return interests[r.Next(interests.Count)];
	}
}