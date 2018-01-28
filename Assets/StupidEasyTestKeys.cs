using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidEasyTestKeys : MonoBehaviour {

	GameManager manager;

	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (manager.GameState.Equals(GameState.Recruiting))
			{
				manager.GameState = GameState.Swiping;
			}
			else
			{
				manager.GameState = GameState.Recruiting;
			}
		}
	}
}
