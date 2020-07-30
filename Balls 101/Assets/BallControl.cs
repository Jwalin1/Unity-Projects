using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

	public static int balls=0,score=0;

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Add") 
		{
			score++;
			transform.position = new Vector2(0,7f);
			print ("score : " + score +" balls : " + balls);
		}
	}

	void Update()
	{
		if (transform.position.y < -10) {
			Destroy (gameObject);
			balls--;
			print ("score : " + score +" balls : " + balls);
		}
	}
}
