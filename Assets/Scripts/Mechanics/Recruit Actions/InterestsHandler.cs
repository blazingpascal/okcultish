using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

public class InterestsHandler {
    const string INTERESTS_XML_FILE = @"Assets/Resources/data/interests.xml";
    private static XmlDocument data;
    private static XmlNode root;
    private static List<Interest> interests;

    private InterestsHandler()
    {

    }

    private static void ParseFromFile(string filename)
    {
        data = new XmlDocument();
        data.Load(filename);
        root = data.FirstChild;
    }

    public static List<String> GetCategories()
    {
        if (data == null)
        {
            ParseFromFile(INTERESTS_XML_FILE);
        }
        XmlNodeList names = data.SelectNodes("Categories/Category/Name");
        return names.Cast<XmlNode>()
                    .Select(node => node.InnerText)
                    .ToList();
    }

    public static List<String> GetInterestsForCategory(string category)
    {
        XmlNodeList names = data.SelectNodes(String.Format("Categories/Category[Name = \"{0}\"]/Interests/Interest/Name", category));
        return names.Cast<XmlNode>()
                    .Select(node => node.InnerText)
                    .ToList();
    }

    public static List<Interest> GetAllInterests()
    {
        if (interests != null)
        {
            return interests;
        }

        List<Interest> all_interests = new List<Interest>();
        foreach (string category in GetCategories()) {
            foreach (string specificInterest in GetInterestsForCategory(category))
            {
                all_interests.Add(new Interest(category, specificInterest));
            }
        }
        interests = all_interests;
        return all_interests;
    }

    public static Interest GetRandomInterest(Random r)
    {
        List<Interest> interests = GetAllInterests();
        return interests[r.Next(interests.Count)];
    }

    public static string SmallTalkMessage(Random r, Interest interest)
    {
        string xpath = String.Format("Categories/Category[Name = \"{0}\"]/Interests/Interest[Name = \"{1}\"]/SmallTalks/SmallTalk/Text", interest.Category, interest.SpecificInterest);
        XmlNodeList smallTalks = data.SelectNodes(xpath);
        List<String> smallTalkStrings = smallTalks
            .Cast<XmlNode>()
            .Select(node => node.InnerText)
            .ToList();
        return smallTalkStrings[r.Next(smallTalkStrings.Count)];
    }
}
