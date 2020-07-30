using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twist : MonoBehaviour {

	public GameObject p1,p2;

	// Update is called once per frame
	void FixedUpdate () {
		Quaternion target;
		target = Quaternion.Euler(p1.transform.position + p2.transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.time * 1f);
	}
}
