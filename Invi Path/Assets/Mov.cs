using UnityEngine;
using System.Collections;

public class Mov : MonoBehaviour
{
	public float moveSpeed;
	public float turnSpeed;

	void Start()
	{
		moveSpeed = 2f;
		turnSpeed = 50f;
	}

	void Update ()
	{
		if(Input.GetKey(KeyCode.UpArrow))
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

		if(Input.GetKey(KeyCode.DownArrow))
			transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

		if(Input.GetKey(KeyCode.LeftArrow))
			transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

		if(Input.GetKey(KeyCode.RightArrow))
			transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
	}
}