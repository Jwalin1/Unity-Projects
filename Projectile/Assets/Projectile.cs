using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public GameObject[] pts;
	[Range(0f,90f)] public float VerticalAngle;
	private float Vangle;
	private Rigidbody rb;
	private Vector3 pos;
	private float u,d,h,g,Hangle;
	private int pts_len,count=0;
	public static bool next = true;

	// Use this for initialization
	void Start () {
		g = Physics.gravity.y;
		rb = GetComponent<Rigidbody> ();
		pts_len = pts.Length;
		Vangle = VerticalAngle * Mathf.Deg2Rad;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0) && next==true && count<pts_len) 
		{
			//make object face position
			pos = new Vector3 (pts[count].transform.position.x, pts[count].transform.position.y+1f, pts[count].transform.position.z); 
			transform.LookAt (pos);
			transform.eulerAngles = new Vector3 (0f, transform.eulerAngles.y-90f, 0f);

			//kinematic equation using height and distance
			d = Vector2.Distance (new Vector2(transform.position.x,transform.position.z),new Vector2(pos.x,pos.z));
			h = pos.y - transform.position.y;
			u = (d / Mathf.Cos (Vangle)) * Mathf.Sqrt ( g / (2*(h - d * Mathf.Tan (Vangle))) );

			//check if jump is possible with the given angle
			if (!float.IsNaN (u)) {
				Hangle = transform.eulerAngles.y * Mathf.Deg2Rad;
				rb.velocity = new Vector3 (u * Mathf.Cos (Vangle) * Mathf.Cos (Hangle), u * Mathf.Sin (Vangle), u * Mathf.Cos (Vangle) * -Mathf.Sin (Hangle));
			} 
			else 
			{
				print ("Not possible, try different angle");
			}
			count++;
			next = false;
		}
	}
}
