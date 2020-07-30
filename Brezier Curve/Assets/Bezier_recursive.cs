using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier_recursive : MonoBehaviour {

	public GameObject[] point;
	public bool mov,show;
	public float time;
	private GameObject path;
	private float t=0;
	private int size,n;
	private Vector2[,] v;

	void Start()
	{
		path = new GameObject();
		path.transform.position = point [0].transform.position;
		path.AddComponent <TrailRenderer>();
		path.GetComponent<TrailRenderer>().widthMultiplier=0.1f;
		path.GetComponent<TrailRenderer>().time=time;
		path.name = "show path";
		size = point.Length;
		n = size - 1;
		v = new Vector2[size,size];
		for(int i=0;i<=n;i++)
		{
			v[0,i] = point[i].transform.position;
		}
	}

	void FixedUpdate()
	{
		if (t <= 1) 
		{
			for (int i = 1; i <= n; i++) 
			{
				for (int j = 0; j <= n - i; j++) 
				{
					v[i,j]=((1-t)*v[i-1,j])+(t*v[i-1,j+1]);
				}
			}
			if (show == true) 
			{
				path.transform.position = v[n,0];
			}
			if (mov == true) 
			{
				transform.position = v[n,0];
			}
			t = t + Time.deltaTime/time;
		} 
		else 
		{
			t = 0;
			if (show == true) 
			{
				path.GetComponent<TrailRenderer> ().Clear ();
			}
		}
	}
}