using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter(Collision col)
	{
		col.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		col.transform.position = new Vector3 (transform.position.x, transform.position.y+1f, transform.position.z);
		col.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
		Projectile.next = true;
		semicircle.moving = false;
	}
}
