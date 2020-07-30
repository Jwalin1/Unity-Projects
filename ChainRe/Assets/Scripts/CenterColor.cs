using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CenterColor : MonoBehaviour {

    public GameObject bg;
    private ColorBlock c;
    private Color bgcolor;

    // Use this for initialization
	void Start () {
        bgcolor = bg.GetComponent<Image>().color; 
        c = GetComponent<Button> ().colors;
        c.normalColor = bgcolor;
        GetComponent<Button> ().colors = c;
	}
}
