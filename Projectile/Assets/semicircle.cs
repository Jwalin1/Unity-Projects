using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semicircle : MonoBehaviour {


	public GameObject[] pts;
	private Vector3 startPos,midPos,endPos;
	private float r,distance,ang,t=0;
	private int pts_len,count=0;
	public static bool moving = false;

	private void Start()
	{
		pts_len = pts.Length;
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && moving==false)
		{
			startPos = transform.position;
			endPos = new Vector3 (pts[count].transform.position.x, pts[count].transform.position.y, pts[count].transform.position.z);
			midPos = new Vector3((transform.position.x + endPos.x)/2,(transform.transform.position.y + endPos.y)/2,(transform.position.z + endPos.z)/2);
			r = Vector3.Distance (startPos,endPos)/2;
			ang = Mathf.Atan2 (endPos.z - startPos.z, endPos.x - startPos.x);
			moving=true;
			t = Mathf.Asin ((startPos.y - midPos.y) / r);
			count++;
		}
		if (moving == true && count <= pts_len) 
		{
			transform.position = midPos+(r*new Vector3(-Mathf.Cos(t)*Mathf.Cos(ang),Mathf.Sin(t),-Mathf.Cos(t)*Mathf.Sin(ang)));
			t = t + 0.05f;
		}
	}
}