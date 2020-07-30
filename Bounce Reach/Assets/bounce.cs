using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour {

	public Transform FinalPoint,ground;
	public bool discriminant;
	private float x, y, x1, y1, g, u;

	// Use this for initialization
	void Start () {
		x = transform.position.x;
		y = transform.position.y - ground.transform.position.y;
		x1 = FinalPoint.transform.position.x;
		y1 = FinalPoint.transform.position.y - ground.transform.position.y;
		g = -Physics2D.gravity.y;
		if(discriminant)
			u = (x1 - x) / (Mathf.Sqrt (2 / g) * (2 * Mathf.Sqrt (y) - Mathf.Sqrt (y - y1)));
		else
			u = (x1 - x) / (Mathf.Sqrt (2 / g) * (2 * Mathf.Sqrt (y) + Mathf.Sqrt (y - y1)));
		Debug.Log (u);

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (u, 0);
	}
}
