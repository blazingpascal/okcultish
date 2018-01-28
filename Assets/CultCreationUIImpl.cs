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

	// Use this for initialization
	void Start () {
		
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

		
	}
}
