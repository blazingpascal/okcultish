using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TestRunner : MonoBehaviour
{
	private System.Random random = new System.Random();
	// Use this for initialization
	void Start ()
	{
		User user1 = User.UserGenerator (random);
		for (int i = 0; i < 10; i++) {
			print (MessageGenerator.GenerateCompliment (random));
		}
		print ("HELLO");
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}

