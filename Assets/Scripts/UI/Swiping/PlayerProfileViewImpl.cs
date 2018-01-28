using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfileViewImpl : MonoBehaviour
{
	private IUserProfile profile;
	public Image profilePicture;
	public Text fullNameAndGenderText;
	public Text distanceText;
	public Text interestBox;
	public Sprite defaultSprite;

	internal void Load(IUserProfile profile)
	{
		this.profile = profile;
		IUser user = profile.GetUser();
		fullNameAndGenderText.text = user.GetFullName() + ", " + user.Gender;
		distanceText.text = string.Format("{0:0.0} miles away",user.Distance);
		interestBox.text = GetInterestText(profile.Interests);
		Sprite sprite = profile.LoadPicture();
		if(sprite == null)
		{
			sprite = defaultSprite;
		}
		profilePicture.sprite = sprite;
		
	}

	private string GetInterestText(ICollection<Interest> interests)
	{
		StringBuilder sb = new StringBuilder();
		foreach (Interest i in interests)
		{
			sb.Append(i.ToString() + "\n");
		}
		return sb.ToString();
	}
}
