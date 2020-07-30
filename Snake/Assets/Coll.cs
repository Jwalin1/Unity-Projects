using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll : MonoBehaviour {

	public static bool eaten = false;

	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "food"&&Food.food_set==true) 
		{
			eaten = true;
			Food.food_set = false;
		}
		else if (coll.gameObject.tag != "touching") 
		{
			Snake.game = false;
		}
	}
}
