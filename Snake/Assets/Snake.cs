using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {

	public GameObject S;
	public float exec_speed = 1;
	public static bool game=true;
	private GameObject[] snake;
	private GameObject food;
	private int l=0,dir=2,pressed;
	private Vector2 v;
	private float t=0;

	// Use this for initialization
	void Start () {
		
		snake = new GameObject[100];

		snake[0]=Instantiate (S, new Vector3 (-0.5f, 0.5f, 0), Quaternion.identity);
		snake [0].tag = "head";
		snake [0].AddComponent<Coll>();
		snake [0].AddComponent<Rigidbody2D>();
		snake [0].GetComponent<Rigidbody2D>().isKinematic =true;
		snake [0].GetComponent<BoxCollider2D>().isTrigger =true;
		snake [0].GetComponent<BoxCollider2D>().size=new Vector2(0.9f,0.9f);

		snake[1]=Instantiate (S, new Vector3 (-1.5f, 0.5f, 0), Quaternion.identity);
		snake [1].tag = "touching";
		snake[2]=Instantiate (S, new Vector3 (-2.5f, 0.5f, 0), Quaternion.identity);
		snake [2].tag = "touching";
		food =Instantiate (S, new Vector3 (26.5f, 9.5f, 0), Quaternion.identity);

		food.tag = "food";
		food.AddComponent<Food>();
		food.AddComponent<Rigidbody2D>();
		food.GetComponent<Rigidbody2D>().isKinematic =true;
		food.GetComponent<BoxCollider2D>().isTrigger =true;
		food.GetComponent<BoxCollider2D>().size=new Vector2(0.9f,0.9f);

		l = 3;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (game == true) 
		{
			t = t + exec_speed * Time.deltaTime;
			if (t >= 0.1) 
			{
				for (int i = l - 1; i > 0; i--) 
				{
					snake [i].transform.position = snake [i - 1].transform.position;
				}
				if (dir == 2) 
				{
					v = new Vector2 (snake [0].transform.position.x + 1f, snake [0].transform.position.y);
				} 
				else if (dir == 0) 
				{
					v = new Vector2 (snake [0].transform.position.x - 1f, snake [0].transform.position.y);
				} 
				else if (dir == 1) 
				{
					v = new Vector2 (snake [0].transform.position.x, snake [0].transform.position.y + 1f);
				} 
				else if (dir == 3) {
					v = new Vector2 (snake [0].transform.position.x, snake [0].transform.position.y - 1f);
				}
				snake [0].transform.position = v;
				pressed = dir;
				t = 0;
			}
			if (Input.GetKeyDown (KeyCode.DownArrow) && pressed != 1) 
			{
				dir = 3;
			} 
			else if (Input.GetKeyDown (KeyCode.UpArrow) && pressed != 3) 
			{
				dir = 1;
			} 
			else if (Input.GetKeyDown (KeyCode.LeftArrow) && pressed != 2) 
			{
				dir = 0;
			} 
			else if (Input.GetKeyDown (KeyCode.RightArrow) && pressed != 0) 
			{
				dir = 2;
			}

			if (Coll.eaten == true) 
			{
				snake [l] = Instantiate (S, snake[l-1].transform.position, Quaternion.identity);
				l = l + 1;
				print ("score : " + (l - 3));
				Coll.eaten = false;
			}
		}
	}
}
