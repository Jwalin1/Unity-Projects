using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    //[SerializeField]
    public int count=0, color;

    public void ChangeCount()
    {
		if (GridManager.updating == false) 
		{
			if (TurnManager.turns >= 0) //turns = -1 represents game over
			{
				if (count == 0 || TurnManager.turn == color) 
				{
					GridManager.updating = true;
					count++;
					color = TurnManager.turn;
					GridManager.instance.UpdateGrid (); 
					StartCoroutine (GridManager.instance.display ()); 
					TurnManager.turn = (TurnManager.turn + 1) % 2;
				}
			}
		}
    }
}
