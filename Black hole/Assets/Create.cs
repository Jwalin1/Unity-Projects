using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour {

	public GameObject Planet;
	public int n;
	private float maxm=3, maxd=50, maxv = 10;
	private float tmp;
	private Color c;
	private GameObject p;

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < n; i++) 
		{
			p = Instantiate (Planet, new Vector3 (Random.Range (-maxd, maxd), Random.Range (-maxd, maxd), Random.Range (-maxd, maxd)), Quaternion.identity);
			p.GetComponent<Rigidbody> ().velocity = new Vector3 (Random.Range (-maxv, maxv), Random.Range (-maxv, maxv), Random.Range (-maxv, maxv));
			tmp = Random.Range (0.5f, maxm);
			p.GetComponent<Rigidbody> ().mass = tmp;
			p.transform.localScale = new Vector3 (tmp, tmp, tmp);
			c = new Color (Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f));
			p.GetComponent<MeshRenderer> ().material.color = c;
			p.GetComponent<TrailRenderer> ().material.color = c;
			p.GetComponent<TrailRenderer> ().widthMultiplier = 0;
		}
	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) 
		{ 
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				if (hit.transform.gameObject.tag == "Planet") {
					tmp = hit.transform.GetComponent<TrailRenderer> ().widthMultiplier;	
					hit.transform.GetComponent<TrailRenderer> ().widthMultiplier = 1+tmp*-1;				
				}
			}
		}
	}
}
