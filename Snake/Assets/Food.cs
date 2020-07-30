using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

	public static bool food_set=false;

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D coll) 
	{
		transform.position = new Vector2 (0.5f + Random.Range (-25, 25), 0.5f + Random.Range (-8, 8));
	}

	void OnTriggerExit2D(Collider2D coll) 
	{
		food_set = true;
	}
}
