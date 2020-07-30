using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov1 : MonoBehaviour 
{ 
	private float speed; 
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
		float x, z;
		x = 0.0f;
		z = 0.0f;
		if (Input.GetKey (KeyCode.UpArrow))
		{
			z = 1.0f;
		}
		else if (Input.GetKey (KeyCode.DownArrow))
		{
			z = -1.0f;
		}
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			x = -1.0f;
		}
		else if (Input.GetKey (KeyCode.RightArrow))
		{
			x = 1.0f;
		}
		Vector3 movement = new Vector3 (x, 0.0f, z); 
		rb.AddForce (movement * speed * Time.deltaTime);
	} 
}
