using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov3 : MonoBehaviour 
{ 
	private float speed; 
	public GameObject p1;
	private Rigidbody rb; 

	// Use this for initialization 
	void Start () 
	{ 
		speed=500f; 
		rb = GetComponent<Rigidbody> (); 
	} 
	// Update is called once per frame 
	void FixedUpdate () 
	{
		Vector3 movement = p1.transform.position-transform.position;
		movement = Vector3.Normalize(movement);
		rb.AddForce (movement * speed * Time.deltaTime);
	} 
}
