using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour {

	public GameObject cam;
	public static int level = 0;
	private Vector3 v = new Vector3 (0.0f, -5.78f, 12.0f);

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Next"&&level==0) {
			col.gameObject.GetComponent <BoxCollider> ().enabled = false;
			level = level + 1;
			cam.transform.position = cam.transform.position + v;
		}
		else if (col.gameObject.tag == "Next1"&&level==1) {
			col.gameObject.GetComponent <BoxCollider> ().enabled = false;
			level = level + 1;
			//cam.transform.position = cam.transform.position + v;
		}
	}
}
