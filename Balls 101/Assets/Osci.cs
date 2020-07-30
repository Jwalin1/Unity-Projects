using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Osci : MonoBehaviour {

	private Vector2 v1,v2,norm;
	private float len,del=0f;

	// Use this for initialization
	void Start () {
		v1 = (Vector2)transform.position;
		v2 = new Vector2(v1.x+14,v1.y);
		len = (v2-v1).magnitude;
		norm = (v2-v1).normalized;
	}

	// Update is called once per frame
	void Update () {
			del = del + Time.deltaTime;
			transform.position = v1 + Mathf.PingPong (7f*del, len) * norm;
	}
}
