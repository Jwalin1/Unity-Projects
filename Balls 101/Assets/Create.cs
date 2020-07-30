using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour {

	public Rigidbody2D Ball;
	public int b,h;
	private Vector2 v;

	// Use this for initialization
	void Start () {
		for (int x = 0; x < b; x++) 
		{
			for (int y = 0; y < h; y++) 
			{
				v = new Vector2 (x*.5f, y*.5f);
				v = v + new Vector2(-2f,3f);
				Instantiate (Ball, v, Quaternion.identity);
				BallControl.balls++;
			}
		}
	}
}
