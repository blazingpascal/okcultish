using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenUI : MonoBehaviour {
	public Button begin;

	// Use this for initialization
	void Awake () {
		GameManager manager = FindObjectOfType<GameManager>();
		if (manager == null)
		{
			SceneManager.LoadScene(5, LoadSceneMode.Additive);
			
		}
		
	}

	void Start()
	{
		GameManager manager = FindObjectOfType<GameManager>();
		begin.onClick.AddListener(() => Begin(manager));
	}

	private void Begin(GameManager gm)
	{
		gm.GameState = GameState.CreatingProfile;
	}
}
