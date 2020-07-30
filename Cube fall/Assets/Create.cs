using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour {

	public GameObject Cube;
	public int b,h;
	private Vector3 v;

	// Use this for initialization
	void Start () {
		for (int x = -b; x <= b; x++) 
		{
			for (int y = 0; y <= h; y++) 
			{
				for (int z = -b; z <= b; z++) 
				{
					if (Mathf.Abs (x) == b || Mathf.Abs (z) == b) 
					{
						v = new Vector3 (x, y, z);
						v.y = v.y + 20;
						Instantiate (Cube, v, Quaternion.identity);
					}
				}
			}
		}
	}
}
