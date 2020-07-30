using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier_explicit : MonoBehaviour {

	public GameObject[] point;
	public bool mov,show;
	public float time;
	private GameObject path;
	private Vector2 v;
	private float t=0;
	private int size,n;
	private int[,] bino_coeff;

	int fact(int n)
	{
		if (n == 0) {
			return 1;
		}
		else {
			return n * fact (n - 1);
		}
	}

	int comb(int n,int r)
	{
		return (fact(n))/((fact(n-r))*(fact(r)));
	}

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
		bino_coeff = new int[size,size];
		for (int i = 0; i <= n; i++) 
		{
			bino_coeff[n,i]=comb (n, i);
		}
	}

	void FixedUpdate()
	{
		if (t <= 1) 
		{
			v = new Vector2 (0, 0);
			for (int i = 0; i <= n; i++) 
			{
				v = v + (Vector2)(bino_coeff [n, i] * Mathf.Pow (1 - t, n - i) * Mathf.Pow (t, i) * point [i].transform.position);
			}
			if (show == true) 
			{
				path.transform.position = v;
			}
			if (mov == true) 
			{
				transform.position = v;
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