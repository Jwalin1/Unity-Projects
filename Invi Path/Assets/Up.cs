using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour {

	public GameObject player;
	private float offset;
	private Vector3 up;
	private Vector3 origin;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Sphere");
		origin = transform.position;
		offset = transform.position.y + 10.0f;
		up = new Vector3(transform.position.x, offset, transform.position.z);
	}
	void Update()
	{
		if (Vector3.Distance (player.transform.position, transform.position) < 1.2f) {
			transform.position = Vector3.MoveTowards (transform.position, up, 0.7f * Time.deltaTime);
		} 
		else 
		{
			transform.position = Vector3.MoveTowards (transform.position, origin, 0.7f * Time.deltaTime);
		}
	}
}