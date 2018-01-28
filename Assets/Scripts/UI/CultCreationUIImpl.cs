using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CultCreationUIImpl : MonoBehaviour {

	public InputField nameOfCult;
	public Dropdown colorDropdown;
	public List<Toggle> interestToggles; 
	public Button beginButton;
	public int interestsSelected;

	public List<string> InterestsSelected { get {
			List<string> interests = new List<string>();
			interestToggles.FindAll(t => t.isOn).ForEach(t => interests.Add(t.gameObject.name));
			return interests;
		}  }

	// Use this for initialization
	void Start () {
		beginButton.onClick.AddListener(BeginGame);
	}

	private void BeginGame()
	{
		GameManager gm = FindObjectOfType<GameManager>();
		var text = nameOfCult.text;
		var cultStyle = (CultStyle)Enum.Parse(typeof(CultStyle), colorDropdown.options[colorDropdown.value].text.ToUpper() + "_FLAG");
		gm.PlayerProfile = new PlayerProfileImpl(text, cultStyle, InterestsSelected);
		gm.GameState = GameState.Swiping;
	}

	// Update is called once per frame
	void Update () {
		interestsSelected = interestToggles.FindAll(t => t.isOn).Count;
		if(interestsSelected == 3)
		{
			beginButton.interactable = true;
			foreach(Toggle t in interestToggles.FindAll(t => !t.isOn)){
				t.interactable = false;
			}
		}
		else
		{
			beginButton.interactable = false;
			interestToggles.ForEach(t => t.interactable = true);
		}
		beginButton.interactable = beginButton.interactable && nameOfCult.text.Trim().Length > 0;
		
	}
}
