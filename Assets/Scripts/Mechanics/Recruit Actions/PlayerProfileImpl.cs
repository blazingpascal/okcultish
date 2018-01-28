using System;
using System.Collections.Generic;

public class PlayerProfileImpl : IPlayerProfile
{
    private string _CultName;
    private CultStyle _CultStyle;
    private List<String> categories;

    public PlayerProfileImpl(String cultName, CultStyle cultStyle, List<String> categories)
    {
        _CultName = cultName;
        _CultStyle = cultStyle;
        this.categories = categories;
    }

    public string CultName
    {
        get
        {
            return _CultName;
        }
    }

    public CultStyle CultStyle
    {
        get
        {
            return _CultStyle;
        }
    }

    public Interest GetRandomInterest(Random random)
    {
        string category = categories[random.Next(categories.Count)];
        return new Interest(category, 
                            InterestsHandler.GetSpecificInterestInCategory(random, category));
    }

    public void SetInterestCategories(List<string> categories)
    {
        this.categories = categories;
    }
}
