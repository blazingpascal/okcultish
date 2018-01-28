using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class MessageGenerator
	{
		private const string BODY_PART_FILE_NAME = @"./Assets/Resources/lists/body-parts.txt";
		private const string ADJECTIVE_FILE_NAME = @"./Assets/Resources/lists/pos-adjective.txt";
        private const string ABORT_FILE_NAME = @"./Assets/Resources/lists/abort.txt";
        private const string COMPLIMENT_FILE_NAME = @"./Assets/Resources/lists/compliments.txt";
		private static RandomSelector bodyPartSelector = new RandomSelector(BODY_PART_FILE_NAME);
		private static RandomSelector adjectiveSelector = new RandomSelector(ADJECTIVE_FILE_NAME);
        private static RandomSelector abortSelector = new RandomSelector(ABORT_FILE_NAME);
        private static RandomSelector complimentSelector = new RandomSelector(COMPLIMENT_FILE_NAME);

        public MessageGenerator () {
			
		}

		public static string GenerateCompliment(Random random) {
			string adjective = adjectiveSelector.GetRandomItem ();
			string bodyPart = bodyPartSelector.GetRandomItem ();

			bool isPlural = bodyPart.EndsWith ("s");

            return complimentSelector.GetRandomItem()
                .Replace("{BODY_PART}", bodyPart)
                .Replace("{IS_ARE}", isPlural ? "are" : "is")
                .Replace("{POSITIVE_ADJ}", adjective)
                .Replace("{A_OR_BLANK}", isPlural ? "" : "a ");
		}

        public static string GenerateAbort(Random random)
        {
            string bodyPart = bodyPartSelector.GetRandomItem();
            return abortSelector.GetRandomItem().Replace("{BODY_PART}", bodyPart);
        }
	}
}

