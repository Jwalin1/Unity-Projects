using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BorderColor : MonoBehaviour {

    private Image border;

    void Awake()
    {
        TurnManager.OnChange += ChangeColor;
    }

    void Start()
    {
        border = GetComponent<Image>(); 
    }

    void ChangeColor()
    { 
        if (TurnManager.turn == 0)
        {
            border.color = Color.red;
        }
        else if (TurnManager.turn == 1)
        {
            border.color = Color.blue;
        }
    }
}
