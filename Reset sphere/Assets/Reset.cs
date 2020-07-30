using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {
	
	private Vector3[] v = new Vector3[2] ;
	private Rigidbody rb;

	void Start() {
		v[0]=new Vector3(0f,0.5f,-4.5f);
		v[1]=new Vector3(0f,-3.5f,5.61f);
		rb = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Danger") {
			gameObject.transform.position = v[Next.level];
			rb.velocity = new Vector3 (0, 0, 0);
		}
	}
}
