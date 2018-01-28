using System;


public class User : IUser
{
	private static String FEMALE_FIRST_NAME_FILE = @"./Assets/Resources/lists/female-names.txt";
	private static String MALE_FIRST_NAME_FILE = @"./Assets/Resources/lists/male-names.txt";
	private static String LAST_NAME_FILE = @"./Assets/Resources/lists/last-names.txt";

	private static RandomSelector femaleFirstNameSelector = new RandomSelector(FEMALE_FIRST_NAME_FILE);
	private static RandomSelector maleFirstNameSelector = new RandomSelector(MALE_FIRST_NAME_FILE);
	private static RandomSelector lastNameSelector = new RandomSelector(LAST_NAME_FILE);

private String firstName;
private String lastName;
private int cultConversionChance;
public Gender Gender { get; private set; }

	private static Random random = new Random();

	private const int MIN_START_CONVERSION_CHANCE = 5;
	private const int MAX_START_CONVERSION_CHANCE = 20;
	private double distance;

	public double Distance
	{
		get
		{
			return distance;
		}
	}

	private User(String firstName, String lastName, Gender gender, int cultConversionChance, double distance)
	{
		this.firstName = firstName;
		this.lastName = lastName;
		this.Gender = gender;
		this.cultConversionChance = cultConversionChance;
		this.distance = distance;
	}

	public String GetFirstName()
	{
		return firstName;
	}

	public String GetFullName()
	{
		return firstName + " " + lastName;
	}

	public Boolean TryToConvert(Random random)
	{
		return random.Next(100) < cultConversionChance;
	}

	public int GetConversionChance()
	{
		return cultConversionChance;
	}

	public void ChangeConversionChance(int delta)
	{
		/**
			* Change the cultConversionChance by a delta, bounded to [0, 100]
			**/
		cultConversionChance += delta;
		cultConversionChance = Math.Min(100, cultConversionChance);
		cultConversionChance = Math.Max(0, cultConversionChance);
	}

	public static User UserGenerator(Random random)
	{
		Gender gender = random.Next(2) == 0 ? Gender.Male : Gender.Female;
		return new User((gender == Gender.Female ? femaleFirstNameSelector.GetRandomItem() : maleFirstNameSelector.GetRandomItem()),
			lastNameSelector.GetRandomItem(),
			gender,
			random.Next(MAX_START_CONVERSION_CHANCE - MIN_START_CONVERSION_CHANCE) + MIN_START_CONVERSION_CHANCE,
			random.NextDouble() * 10f);
	}

}


