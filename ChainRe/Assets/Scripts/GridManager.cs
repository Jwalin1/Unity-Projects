using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GridManager : MonoBehaviour {

    public static GridManager instance;
    public GridLayoutGroup GLG;
    public GameObject One, Two, Three;
    public int Rows, Columns;
    private Transform[] Tiles; 
    private int TilesCount,CircleCount,Index,Index1;
    [SerializeField]
    private int RedCircles, BlueCircles;
	public static bool updating=false;
    private bool changed;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Tiles = new Transform[GLG.transform.childCount];
        TilesCount = Tiles.Length;
        for (int i = 0; i < TilesCount; i++)
        {
            Tiles[i] = GLG.transform.GetChild(i); 
        }
    }

    public IEnumerator display()
    {
        RedCircles = 0; BlueCircles = 0;
        for (int i = 0; i < TilesCount; i++)
        {
            //Set circles
            if (Tiles[i].childCount > 1)
            {
                if (Tiles[i].GetChild(1).childCount != Tiles[i].GetComponent<TileManager>().count)
                {
                    Destroy(Tiles[i].GetChild(1).gameObject); 
                }
            } 

            yield return new WaitForSeconds(0f);

            if (Tiles[i].childCount == 1)
            {
                if (Tiles[i].GetComponent<TileManager>().count == 1)
                {
                    Instantiate(One, Tiles[i].transform);
                }
                else if (Tiles[i].GetComponent<TileManager>().count == 2)
                {
                    Instantiate(Two, Tiles[i].transform);
                }
                else if (Tiles[i].GetComponent<TileManager>().count == 3)
                {
                    Instantiate(Three, Tiles[i].transform);
                }
            }

            //Set color
            if(Tiles[i].childCount > 1)
            {

                CircleCount = Tiles[i].GetChild(1).childCount;

                if (Tiles[i].GetComponent<TileManager>().color == 0)
                {  
                    RedCircles++;
                    for(int j=0;j<CircleCount;j++)
                    {
                        Tiles[i].GetChild(1).GetChild(j).GetComponent<SpriteRenderer>().color=Color.red;
                    }
                }
                else if (Tiles[i].GetComponent<TileManager>().color == 1)
                {
                    BlueCircles++;
                    for(int j=0;j<CircleCount;j++)
                    {
                        Tiles[i].GetChild(1).GetChild(j).GetComponent<SpriteRenderer>().color=Color.blue;
                    }
                }
            }
        }
        if (TurnManager.turns > 2)
        {
            if (RedCircles == 0)
            {
                Debug.Log("Blue wins"); 
                TurnManager.turns = -1;
            }
            else if (BlueCircles == 0)
            {
                Debug.Log("Red wins");
                TurnManager.turns = -1;
            }
        }
		updating = false;
    }
        

    public void UpdateGrid()
    {
        do
        {
            Index = 0;
            changed = false;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Index = i*Columns+j;

                    CircleCount = Tiles[Index].GetComponent<TileManager>().count;

                    //checking conditions to check if anything is changed
                    if(CircleCount==2 && ( (i==0&&j==0) || (i==0&&j==Columns-1) || (i==Rows-1&&j==0) || (i==Rows-1&&j==Columns-1) ))
                    {
                        changed = true;
                    }

                    else if(CircleCount==3 && ( (i==0) || (i==Rows-1) || (j==0) || (j==Columns-1) ))
                    {
                        changed = true;
                    }

                    else if(CircleCount==4)
                    {
                        changed = true;
                    }

                    //updating the changes accordingly
                    if(changed)
                    {
                        Tiles[Index].GetComponent<TileManager>().count=0;
                        int p,q;

                        p=i-1; q=j;
                        Index1 = p*Columns + q;
                        if(p>=0&&p<Rows&&q>=0&&q<Columns)
                        {
                            Tiles[Index1].GetComponent<TileManager>().count++;
                            Tiles[Index1].GetComponent<TileManager>().color = Tiles[Index].GetComponent<TileManager>().color;
                            if(Tiles[Index1].GetComponent<TileManager>().count>4)
                                Tiles[Index1].GetComponent<TileManager>().count=4;
                        }
                        p=i+1; q=j;
                        Index1 = p*Columns + q;
                        if(p>=0&&p<Rows&&q>=0&&q<Columns)
                        {
                            Tiles[Index1].GetComponent<TileManager>().count++;
                            Tiles[Index1].GetComponent<TileManager>().color = Tiles[Index].GetComponent<TileManager>().color;
                            if(Tiles[Index1].GetComponent<TileManager>().count>4)
                                Tiles[Index1].GetComponent<TileManager>().count=4;
                        }
                        p=i; q=j-1;
                        Index1 = p*Columns + q;
                        if(p>=0&&p<Rows&&q>=0&&q<Columns)
                        {
                            Tiles[Index1].GetComponent<TileManager>().count++;
                            Tiles[Index1].GetComponent<TileManager>().color = Tiles[Index].GetComponent<TileManager>().color;
                            if(Tiles[Index1].GetComponent<TileManager>().count>4)
                                Tiles[Index1].GetComponent<TileManager>().count=4;
                        }
                        p=i; q=j+1;
                        Index1 = p*Columns + q;
                        if(p>=0&&p<Rows&&q>=0&&q<Columns)
                        {
                            Tiles[Index1].GetComponent<TileManager>().count++;
                            Tiles[Index1].GetComponent<TileManager>().color = Tiles[Index].GetComponent<TileManager>().color;
                            if(Tiles[Index1].GetComponent<TileManager>().count>4)
                                Tiles[Index1].GetComponent<TileManager>().count=4;
                        }

                        //to break out of both loops
                        i=Rows;
                        j=Columns;

                    }
                }  
            }
        }
        while (changed);
    }

}
