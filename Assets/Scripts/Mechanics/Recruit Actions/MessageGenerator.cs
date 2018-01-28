using System;
using System.Collections.Generic;

public class MessageGenerator
{
    private const string BODY_PART_FILE_NAME = @"./Assets/Resources/lists/body-parts.txt";
    private const string ADJECTIVE_FILE_NAME = @"./Assets/Resources/lists/pos-adjective.txt";
    private const string ABORT_FILE_NAME = @"./Assets/Resources/lists/abort.txt";
    private const string COMPLIMENT_FILE_NAME = @"./Assets/Resources/lists/compliments.txt";
    private const string COMPLIMENT_RESPONSE_LOW_FILE_NAME = @"./Assets/Resources/lists/compliment-response-low.txt";
    private const string COMPLIMENT_RESPONSE_MID_FILE_NAME = @"./Assets/Resources/lists/compliment-response-mid.txt";
    private const string COMPLIMENT_RESPONSE_HIGH_FILE_NAME = @"./Assets/Resources/lists/compliment-response-high.txt";
    private const string CULT_JOIN_ACCEPT_FILE_NAME = @"./Assets/Resources/lists/cult-join-accept.txt";
    private const string CULT_JOIN_REJECT_FILE_NAME = @"./Assets/Resources/lists/cult-join-reject.txt";

    private static RandomSelector bodyPartSelector = new RandomSelector(BODY_PART_FILE_NAME);
    private static RandomSelector adjectiveSelector = new RandomSelector(ADJECTIVE_FILE_NAME);
    private static RandomSelector abortSelector = new RandomSelector(ABORT_FILE_NAME);
    private static RandomSelector complimentSelector = new RandomSelector(COMPLIMENT_FILE_NAME);
    private static RandomSelector complimentResponseLowSelector = new RandomSelector(COMPLIMENT_RESPONSE_LOW_FILE_NAME);
    private static RandomSelector complimentResponseMidSelector = new RandomSelector(COMPLIMENT_RESPONSE_MID_FILE_NAME);
    private static RandomSelector complimentResponseHighSelector = new RandomSelector(COMPLIMENT_RESPONSE_HIGH_FILE_NAME);
    private static RandomSelector cultJoinResponseAcceptSelector = new RandomSelector(CULT_JOIN_ACCEPT_FILE_NAME);
    private static RandomSelector cultJoinResponseRejectSelector = new RandomSelector(CULT_JOIN_REJECT_FILE_NAME);

    public MessageGenerator()
    {

    }

    public static string GenerateCompliment(Random random)
    {
        string adjective = adjectiveSelector.GetRandomItem();
        string bodyPart = bodyPartSelector.GetRandomItem();

        bool isPlural = bodyPart.EndsWith("s");

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

    public static string GenerateComplimentResponse(Random random, int cultChance)
    {
        if (cultChance < 40)
        {
            return complimentResponseLowSelector.GetRandomItem();
        }
        else if (cultChance < 80)
        {
            return complimentResponseMidSelector.GetRandomItem();
        }
        else
        {
            return complimentResponseHighSelector.GetRandomItem();
        }
    }

    public static string GenerateJoinCultResponse(Random random, bool success)
    {
        return success ? cultJoinResponseAcceptSelector.GetRandomItem() : cultJoinResponseRejectSelector.GetRandomItem();
    }
}

