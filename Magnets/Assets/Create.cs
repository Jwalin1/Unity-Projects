using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour {

	public GameObject RCube;
	public GameObject BCube;
	private Vector3 v;

	// Use this for initialization
	void Start () {
		for (int x = -2; x < 2; x++) 
		{
			for (int y = 0; y < 4; y++) 
			{
				for (int z = -2; z < 2; z++) 
				{
					v=new Vector3(2*x,2*y,2*z);
					if (Random.Range (0, 2) == 0)
						Instantiate (BCube, v, Quaternion.identity);
					else
						Instantiate (RCube, v, Quaternion.identity);
				}
			}
		}
	}
}
