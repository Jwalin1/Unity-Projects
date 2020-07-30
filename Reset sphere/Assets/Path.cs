using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

	public Vector3[] pos;

	int len,count=0;
	float speed=5f;

	void Start()
	{
		len = pos.Length;
	}

	void Update () 
	{
			transform.position = Vector3.MoveTowards (transform.position,pos[count],speed*Time.deltaTime);
			if (transform.position == pos[count]) {
				count=(count+1)%len;
			}
	}

}