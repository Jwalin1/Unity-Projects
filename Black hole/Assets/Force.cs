using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour {

	private GameObject[] objs;
	public GameObject Planet;
	public static float EffectRadius=100f;
	private float mB;
	private Vector3 v,f;

	void Start()
	{
		mB = gameObject.GetComponent<Rigidbody>().mass;
	}

	void FixedUpdate () {

		Collider[] objs = Physics.OverlapSphere (transform.position, EffectRadius);
		foreach (var obj in objs) 
		{
			v = transform.position-obj.transform.position; 
			f = mB* (obj.GetComponent<Rigidbody>().mass) * Vector3.Normalize (v) / Mathf.Pow (v.magnitude, 2);
			if (f.magnitude > 0f) 
			{
				obj.GetComponent<Rigidbody>().AddForce (f);
			}
		}
	}
}
