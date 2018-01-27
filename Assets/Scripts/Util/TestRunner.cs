using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TestRunner : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		User user1 = User.userGenerator ();
		print ("HELLO");
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}

