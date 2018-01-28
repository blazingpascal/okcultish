
using System;
using UnityEngine;
using UnityEngine.UI;

public class SwipingProfileImpl : MonoBehaviour
{
	public PlayerProfileViewImpl playerProfile;
	public Button acceptButton;
	public Button rejectButton;

	public void Start()
	{
		LoadNewProfile();
		acceptButton.onClick.AddListener(Accept);
		rejectButton.onClick.AddListener(Reject);
	}

	private void LoadNewProfile()
	{
		LoadProfile(UserProfile.UserProfileGenerator(new System.Random()));
	}

	private void Reject()
	{
		LoadNewProfile();
	}

	private void Accept()
	{
		LoadNewProfile();
	}

	public void LoadProfile(IUserProfile profile)
	{
		playerProfile.Load(profile);
	}
}

