using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollManager : MonoBehaviour {

    public enum states {standing,falling,bounced,fallen};
    public static states state;
    public Rigidbody Head,Spine;

    public Transform RK, LK, ground;
    private Vector2 c, rv, lv;

    private float dist;

    // Use this for initialization
	void Start () {
        state = states.standing;
	}
	
	// Update is called once per frame
	void Update () {

        c = new Vector2(Head.gameObject.transform.position.x, Head.gameObject.transform.position.z);
        rv = new Vector2 (RK.transform.position.x,RK.transform.position.z);
        lv = new Vector2 (LK.transform.position.x,LK.transform.position.z);

        dist = Vector3.Distance(rv, lv) + .3f;
        if ((state == states.standing) && (dist < Vector2.Distance(rv, c) && dist < Vector2.Distance(lv, c)))
            state = states.falling;
        else if ((state == states.falling||state == states.bounced) && (dist >= Vector2.Distance(rv, c) || dist >= Vector2.Distance(lv, c)))
            state = states.standing;
        if ((state == states.standing)&&(RK.position.y - ground.position.y > 1.25f && LK.position.y - ground.position.y > 1.25f))
            state = states.falling;
        else if ((state == states.falling)&&(RK.position.y - ground.position.y <= 1.25f && LK.position.y - ground.position.y <= 1.25f))
            state = states.standing;
        
        
        if (state == states.fallen)
        {
            Head.AddForce(0f, 27.5f, 0f, ForceMode.VelocityChange);
            Spine.AddForce(0f, 27.5f, 0f, ForceMode.VelocityChange);
            state = states.bounced;
        }
        else if (state == states.standing)
            Head.AddForce(0f, 2.25f, 0f, ForceMode.VelocityChange);

        Debug.Log(state); 
	}
}
