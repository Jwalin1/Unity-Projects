using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invi : MonoBehaviour {

	public GameObject player;
	public Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.enabled = false;
		player = GameObject.Find ("Sphere");
	}
	void Update()
	{
		if (Vector3.Distance (player.transform.position, transform.position) < 1.42f) 
		{
			rend.enabled = true;
		}
	}
}