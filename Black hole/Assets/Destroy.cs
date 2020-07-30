using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	private GameObject[] B;
	private Vector3[] Bpos;
	private float Brad=5, Blimit=Force.EffectRadius;
	private int i,Bnum;

	void Start()
	{
		B = GameObject.FindGameObjectsWithTag ("Blackhole");
		Bnum = B.Length;
		Bpos = new Vector3[Bnum];
		for (i = 0; i < Bnum; i++) 
		{
			Bpos [i] = B[i].transform.position;
		}
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag == "Blackhole")
		{
			Destroy (gameObject);
		}
	}

	void Update()
	{
		for (i = 0; i < Bnum; i++) 
		{
			if (Vector3.Distance (Bpos[i], transform.position) <= Brad || (Vector3.Distance (Bpos[i], transform.position) > Blimit)) 
			{
				break;
			}
		}
		if(i!=Bnum)
		{
			Destroy (gameObject);
		}
	}
}
