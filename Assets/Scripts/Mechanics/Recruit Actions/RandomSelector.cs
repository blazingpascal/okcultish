using System;
using System.Collections.Generic;

public class RandomSelector
{
	private List<String> items = new List<string>();
	private Random random = new Random();

	public RandomSelector(String filename)
	{
		System.IO.StreamReader file = new System.IO.StreamReader(filename);
		string line;
		while ((line = file.ReadLine()) != null)
		{
			items.Add(line);
		}
	}

	public String getRandomItem()
	{
		return items[random.Next(items.Count)];
	}
}

