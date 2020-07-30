using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour {
	
	private GameObject[] objs;
	private Color c;
	private Vector3 v,force;

	// Use this for initialization
	void Start () {
		c = GetComponent<Renderer> ().material.color;
	}
		
	void FixedUpdate () {
		
		Collider[] objs = Physics.OverlapSphere(transform.position, 5f);
		foreach (var obj in objs)
		{
			if (obj.gameObject.tag == "Magnet") 
			{
				v =  transform.position - obj.transform.position; 
				force = 100f * Vector3.Normalize (v) / Mathf.Pow (v.magnitude, 2);
				if (force.magnitude > 0f) 
				{
					if (c == Color.blue) 
					{
						if (obj.GetComponent<Renderer> ().material.color == Color.blue)
							obj.GetComponent<Rigidbody>().AddForce (force);
						else if (obj.GetComponent<Renderer> ().material.color == Color.red)
							obj.GetComponent<Rigidbody>().AddForce (-force);
					} 
					else if (c == Color.red) 
					{
						if (obj.GetComponent<Renderer> ().material.color == Color.blue)
							obj.GetComponent<Rigidbody>().AddForce (-force);
						else if (obj.GetComponent<Renderer> ().material.color == Color.red)
							obj.GetComponent<Rigidbody>().AddForce (force);
					}
				}
			}
		}
	}

}
