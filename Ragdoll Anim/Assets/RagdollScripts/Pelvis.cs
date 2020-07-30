using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelvis : MonoBehaviour {

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Ground")
		{
			RagdollManager.state = RagdollManager.states.fallen;
		}
	}
}
