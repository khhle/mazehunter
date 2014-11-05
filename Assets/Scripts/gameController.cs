using UnityEngine;
using System.Collections;
using System;
public class gameController : MonoBehaviour {

	public int turn = 1;
	RobotScript rob;
	//enemyScript enemy;
	public int getDirection;
	// Use this for initialization
	private int delay = 0;
	//private int delay2 = 0 ;
	//private bool isInit = false;
	public bool isMove = false;
	private int directionType = 0;
	//private int playerDirection = 0;
	private int lastAI;
	public Transform gameOverPanelPrefab;
	public Transform gameWinPanelPrefab;
	public bool shouldInitEnemy = false;
	void Start () {
		//enemy = GameObject.Find("enemy").GetComponent<enemyScript>();
		rob = GameObject.Find("robot").GetComponent<RobotScript>();
	}
	 
	// Update is called once per frame
	void Update () {

		if(rob == null)
			return;


		if (delay > 0)
		{
			delay--;
			//turn = 3;
		}
		else
		{
			rob.shouldMove = false;
			directionType = 0;
			turn = 1;
		}
		if(turn == 1)
		{
			//Debug.Log("1");
			bool up = Input.GetKeyDown ("up");
			if(up)
				directionType = 1;
			
			bool down = Input.GetKeyDown ("down");
			if(down)
				directionType = 2;
			
			bool left = Input.GetKeyDown ("left");
			if(left)
				directionType = 3;
			
			bool right = Input.GetKeyDown ("right");
			if(right)
				directionType = 4;

			if(directionType != 0)
			{
				rob.directionType = directionType;
				//playerDirection = directionType;
				rob.shouldMove = true;
				//Debug.Log("1.5");
				shouldInitEnemy = true;
				delay = 60;
				//isInit = true;
				turn = 2;
			}
		}



	
	}

	public void gameOver()
	{
		var gameOverPanelTransform = Instantiate(gameOverPanelPrefab) as Transform;
		
		// Assign position
		gameOverPanelTransform.position = new Vector3 (transform.position.x,
		                                               transform.position.y, 
		                                               -5);
	}

	public void gameWin()
	{
		var gameWinPanelTransform = Instantiate(gameWinPanelPrefab) as Transform;
		
		// Assign position
		gameWinPanelTransform.position = new Vector3 (transform.position.x,
		                                               transform.position.y, 
		                                               -5);
	}


	//type 1: up
	//type 2: down
	//type 3: left
	//type 4: right





}
