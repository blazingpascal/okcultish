public class Interest
{
	public string Category { get; private set; }
	public string SpecificInterest { get; private set; }

	public Interest(string category, string specificInterest)
	{
		this.Category = category;
		this.SpecificInterest = specificInterest;
	}

	public override string ToString()
	{
		return SpecificInterest;
	}

	public override int GetHashCode()
	{
		return Category.GetHashCode() * 3 + Category.GetHashCode() * 7;
	}

	public override bool Equals(object obj)
	{
		return obj is Interest && ((Interest)obj).Category.Equals(Category) 
			&& ((Interest)obj).SpecificInterest.Equals(SpecificInterest);
	}
}