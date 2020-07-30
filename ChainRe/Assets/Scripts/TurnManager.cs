using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    public static int turn=0,turns=0;
    private int turn1;

    public delegate void TurnChanged();
    public static event TurnChanged OnChange;

    void Start()
    {
        turn1 = turn;
    }

    void Update()
    {
        if (turn1 != turn)
        {
            turns++;
            turn1 = turn;
            if(OnChange != null)
                OnChange();
        }
    }

}
