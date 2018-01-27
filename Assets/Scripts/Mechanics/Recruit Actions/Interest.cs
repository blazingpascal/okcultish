public class Interest
{
	private string category;
	private string specificInterest;

	public Interest(string category, string specificInterest)
	{
		this.category = category;
		this.specificInterest = specificInterest;
	}

	public override string ToString()
	{
		return specificInterest;
	}

	public override int GetHashCode()
	{
		return category.GetHashCode() * 3 + category.GetHashCode() * 7;
	}

	public override bool Equals(object obj)
	{
		return obj is Interest && ((Interest)obj).category.Equals(category) 
			&& ((Interest)obj).specificInterest.Equals(specificInterest);
	}
}