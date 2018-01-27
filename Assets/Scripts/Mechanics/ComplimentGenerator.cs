using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class ComplimentGenerator
	{
		private const string BODY_PART_FILE_NAME = @"./Assets/Resources/lists/body-parts.txt";
		private const string ADJECTIVE_FILE_NAME = @"./Assets/Resources/lists/pos-adjective.txt";
		private static RandomSelector bodyPartSelector = new RandomSelector(BODY_PART_FILE_NAME);
		private static RandomSelector adjectiveSelector = new RandomSelector(ADJECTIVE_FILE_NAME);

		public ComplimentGenerator () {
			
		}

		public string generateCompliment(Random random) {
			string adjective = adjectiveSelector.getRandomItem ();
			string bodyPart = bodyPartSelector.getRandomItem ();

			bool isPlural = bodyPart.EndsWith ("s");

			List<String> formats = new List<String>();
			formats.Add ("Your {0} {1} very {2}");
			formats.Add ("Your {0} {1} {2}");
			formats.Add ("I like how {2} your {0} {1}");
			formats.Add ("You have such {3}{2} {0}");
			return String.Format(formats [random.Next (formats.Count)], 
				bodyPart,
				isPlural ? "are" : "is",
				adjective,
				isPlural ? "" : "a ");
		}
	}
}

