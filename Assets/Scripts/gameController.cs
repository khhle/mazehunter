using UnityEngine;
using System.Collections;
using System;
public class gameController : MonoBehaviour {

	public int turn = 1;
	RobotScript rob;
	enemyScript enemy;
	public int getDirection;
	// Use this for initialization
	private int delay = 0;
	private int delay2 = 0 ;
	private bool isInit = false;
	public bool isMove = false;
	private int directionType = 0;
	private int playerDirection = 0;
	private int lastAI;
	void Start () {
		enemy = GameObject.Find("enemy").GetComponent<enemyScript>();
		rob = GameObject.Find("robot").GetComponent<RobotScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if(delay > 0 && turn == 3)
		{
			//Debug.Log("minus");
			delay--;
		}
		else if(delay <= 0 && turn == 3)
		{
			//Debug.Log("saA");
			rob.shouldMove = false;
			directionType = 0;
			turn = 2;	
			isInit = false;
		}

		if(delay2 > 0 && turn == 4)
			delay2--;
		else if(delay2 <= 0 && turn == 4)
		{
			enemy.shouldMove = false;
			turn = 5;	
			isInit = false;
		}

		if(delay2 > 0 && turn == 6)
			delay2--;
		else if(delay2 <= 0 && turn == 6)
		{
			enemy.shouldMove = false;
			turn = 1;	
			isInit = false;
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
				playerDirection = directionType;
				rob.shouldMove = true;
				//Debug.Log("1.5");
			
				delay = 60;
				isInit = true;
				turn = 3;
			}
		}
		if(turn == 2)
		{
			//Debug.Log("2");
			enemy.shouldMove = true;
			lastAI = AI(playerDirection);
			enemy.directionType = lastAI;
			delay2 = enemy.delayTime;
			isInit = true;
			turn = 4;
		}
		if(turn == 5)
		{
			enemy.shouldMove = true;
			enemy.directionType = AI2(lastAI,playerDirection);
			delay2 = 30;
			isInit = true;
			turn = 6;
		}


	
	}



	//type 1: up
	//type 2: down
	//type 3: left
	//type 4: right


	int AI(int directionP)
	{
		int up = 1;
		int down = 2;
		int left = 3;
		int right = 4;

		float yE = enemy.transform.position.y;
		float xE = enemy.transform.position.x;



		float xP = rob.transform.position.x;
		float yP = rob.transform.position.y;
		//Debug.Log("xP" + xP);
		xP = (float)Math.Round (xP);
		yP = (float)Math.Round (yP);;

		//Debug.Log("xP" + xP);
		//Debug.Log("xE" + xE);
		if(xE == xP)
		{
			//Debug.Log("=====");
			float isUp = Mathf.Abs( (yE+1)- yP );
			float isDown =  Mathf.Abs( (yE-1)- yP );
			
			if(isUp < isDown)
				return up;
			else
				return down;

		}

		if(yE == yP)
		{
			float isLeft = Mathf.Abs( (xE-1)- xP );
			float isRight = Mathf.Abs( (xE+1)- xP );
			
			if(isLeft < isRight)
				return left;
			else
				return right;
		}

		if(directionP == up || directionP == down)
		{
			float isUp = Mathf.Abs( (yE+1)- yP );
			float isDown =  Mathf.Abs( (yE-1)- yP );

			if(isUp < isDown)
				return up;
			else
				return down;
		}

		if(directionP == left || directionP == right)
		{
			float isLeft = Mathf.Abs( (xE-1)- xP );
			float isRight = Mathf.Abs( (xE+1)- xP );
			
			if(isLeft < isRight)
				return left;
			else
				return right;
		}


		return 0;

	}

	int AI2(int last,int directionP)
	{
		int up = 1;
		int down = 2;
		int left = 3;
		int right = 4;
		
		float yE = enemy.transform.position.y;
		float xE = enemy.transform.position.x;
		
		float xP = rob.transform.position.x;
		float yP = rob.transform.position.y;

		if(yE == yP || xE == xP)
			return last;
		if(directionP == up || directionP == down)
		{
			float isLeft = Mathf.Abs( (xE-1)- xP );
			float isRight = Mathf.Abs( (xE+1)- xP );
			
			if(isLeft < isRight)
				return left;
			else
				return right;
		}
		
		if(directionP == left || directionP == right)
		{
			float isUp = Mathf.Abs( (yE+1)- yP );
			float isDown =  Mathf.Abs( (yE-1)- yP );
			
			if(isUp < isDown)
				return up;
			else
				return down;
		}

		return 0;

	}



}
