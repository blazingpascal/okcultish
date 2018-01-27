using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TestRunner : MonoBehaviour
{
	private System.Random random = new System.Random();
	// Use this for initialization
	void Start ()
	{
		User user1 = User.userGenerator ();
		ComplimentGenerator cg = new ComplimentGenerator ();
		for (int i = 0; i < 10; i++) {
			print (cg.generateCompliment (random));
		}
		print ("HELLO");
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}

