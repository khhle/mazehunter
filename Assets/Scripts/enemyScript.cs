using UnityEngine;
using System.Collections;
using System;
public class enemyScript : MonoBehaviour {
	
	//type 1: up
	//type 2: down
	//type 3: left
	//type 4: right
	public int directionType;
	private MoveScript mov;
	//public int delay = 0;
	//private int delayTime = 60;
	public bool isMove = false;
	public bool shouldMove = false;
	public bool canRight = true;
	public bool canLeft= true;
	public bool canUp= true;
	public bool canDown= true;
	public bool shouldReset = false;
	public bool shouldCheckStuck = false;
	public int delayTime;
	private RobotScript rob;
	private bool isInit = false;
	private gameController gm;
	private bool firstMoveStuck = false;
	private float xCurr;
	private float yCurr;
	private bool initSecondMove = false;
	private float oriX;
	private float oriY;
	private int enemyCase;
	//private int 
	// Use this for initialization
	void Start () {
		mov =  GetComponent<MoveScript>();
		rob = GameObject.Find("robot").GetComponent<RobotScript>();
		gm = GameObject.Find("controller").GetComponent<gameController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(rob == null)
		{
			mov.direction = new Vector2(0, 0);
			return;
		}
		if(gm.turn == 2 && isInit == false && gm.shouldInitEnemy)
		{
			oriX = rob.transform.position.x;
			oriY = rob.transform.position.y;
			isInit = true;
			shouldMove = true;
			//Debug.Log("init");
			enemyCase = caseLabel(rob.directionType,oriX,oriY);
			directionType = AI(rob.directionType);
			initSecondMove = false;
			//Debug.Log(directionType);
			delayTime = 30;
			//shouldCheckStuck = false;
			firstMoveStuck = false;
			gm.shouldInitEnemy = false;
			//delay2 = delayTime;
			//isInit = true;
			//turn = 4;

		}
		else if(gm.turn != 2)
		{
			shouldMove = false;
			isMove = false;
			mov.direction = new Vector2(0, 0);
			isInit = false;
			shouldCheckStuck = true;
			firstMoveStuck = false;
			return;
		}

		if(shouldMove == true)
		{
			if(directionType == 1 )
			{
				mov.direction = new Vector2(0, 1);
				isMove = true;

			}
			else if(directionType == 2)
			{
				mov.direction = new Vector2(0, -1);
				isMove = true;

					
			}
			else if(directionType == 3 )
			{
				mov.direction = new Vector2(-1, 0);
				isMove = true;

			}
			else if(directionType == 4 )
			{
				mov.direction = new Vector2(1, 0);
				isMove = true;

			}
			else
			{

				//Debug.Log("first move stuck");
				firstMoveStuck = true;

				mov.direction = new Vector2(0, 0);
				//return;
				delayTime = -1;
				isMove = false;

			}
			shouldMove = false;
			isInit = true;
			xCurr = this.transform.position.x;
			yCurr = this.transform.position.y;
			//delayTime = 60;
		}

		//if(delayTime > 0)
		//	delayTime--;
		if(delayTime == 15)
		{
			float xNow = this.transform.position.x;
			float yNow = this.transform.position.y;
			Debug.Log("now " + xNow +" " +yNow);
			Debug.Log("curr " + xCurr +" " +yCurr);
			if(directionType == 3 || directionType == 4)
				if(Math.Abs(xNow - xCurr) < 0.3)
				{
					Debug.Log("Stuck x");
					delayTime = 0;
					firstMoveStuck = true;
				} 
			if(directionType == 1 || directionType == 2)
				if(Math.Abs(yNow - yCurr) < 0.3)
				{
					//Debug.Log("Stuck y");
					//Debug.Log(yNow);
					//Debug.Log(yCurr);
					delayTime = 0;
					firstMoveStuck = true;
				}
			delayTime--;
			//Debug.Log("NOT STUCK");
		}
		else if( delayTime > 0)
			delayTime--;
		else{
			//Debug.Log("Get here");
			//shouldMove = false;
			canUp = canRight = canLeft = canDown = true;
			shouldMove = true;
			//if(!canUp || !canDown || !canRight || !canLeft)
			if(firstMoveStuck)
			{
				//Debug.Log("SFirst Move stuck");
				//return;
				//directionType = 0;
				isMove = false;
				//firstMoveStuck = false;
				shouldMove = false;
				mov.direction = new Vector2(0, 0);
			}
			else if(initSecondMove == false)
			{
				directionType = AI2(rob.directionType);
				initSecondMove = true;
				//Debug.Log("SAI2");
				//Debug.Log(directionType);
			}


			//directionType = 0;
			//delayTime = 30;
			//isInit = false;
		}

		/*
		if(shouldReset == true)
		{
			canUp = canRight = canLeft = canDown = true;
			shouldReset = false;
		}
		if (shouldMove == false)
		{
			mov.direction = new Vector2(0, 0);
			isMove = false;
			shouldCheckStuck = true;
		}


		else{
			if(directionType == 1)
			{
				mov.direction = new Vector2(0, 1);
				isMove = true;
				if(canUp == false)
					delayTime= 5;
				else
					delayTime = 30;
			}
			else if(directionType == 2)
			{
				mov.direction = new Vector2(0, -1);
				isMove = true;
				if(canDown == false)
					delayTime= 5;
				else
					delayTime = 30;
			}
			else if(directionType == 3)
			{
				mov.direction = new Vector2(-1, 0);
				isMove = true;
				if(canLeft == false)
					delayTime= 5;
				else
					delayTime = 30;
			}
			else if(directionType == 4)
			{
				mov.direction = new Vector2(1, 0);
				isMove = true;
				if(canRight == false)
					delayTime= 5;
				else
					delayTime = 30;
			}
			shouldCheckStuck = false;
			shouldReset = true;
		}*/
			

	}



	void OnCollisionEnter2D( Collision2D otherCollider){ 
		RobotScript rob = otherCollider.gameObject.GetComponent<RobotScript>();
		if (rob != null) {
			SpecialEffectsHelper.Instance.Explosion (transform.position);
			Destroy (rob.gameObject);
			gm.gameOver();



			//gameController.roverExploded = true;
			//gameController.gameOver ();
			//rob.transform.position = new Vector3 (0, 0, 0);
		}
	}

	int AI(int directionP)
	{
		int up = 1;
		int down = 2;
		int left = 3;
		int right = 4;


		
		if(directionP == left || directionP == right)
		{
			if(enemyCase == 1 || enemyCase == 4 || enemyCase == 7)
				return right;
			if(enemyCase == 3 || enemyCase == 6 || enemyCase == 9)
				return left;
			return directionP;

		}

		if(directionP == up || directionP == down)
		{
			if(enemyCase == 1 || enemyCase == 7)
				return right;
			if(enemyCase == 3 || enemyCase == 9)
				return left;
			if(enemyCase == 2)
				return down;
			if(enemyCase == 8)
				return up;
			return directionP;	
		}

		return 0;
	}

	int AI2(int directionP)
	{
		int up = 1;
		int down = 2;
		int left = 3;
		int right = 4;


			if(enemyCase == 1 || enemyCase == 2 || enemyCase == 3)
				return down;
			if(enemyCase == 7 || enemyCase == 8 || enemyCase == 9)
				return up;
			if(enemyCase ==4)
				return right;
			else
				return left;
			
		return 0;


	}


	int caseLabel(int directionP, float xP, float yP)
	{


		float xE = this.transform.position.x;
		float yE = this.transform.position.y;
		//if(directionP == left || directionP == right)
		//{
			if(yE == yP)
				if(xE < xP)
					return 4;
				else
					return 6;

			if(xE == xP)
				if(yE > yP)
					return 2;
				else
					return 8;

			if(xE < xP)
				if(yE > yP)
					return 1;
				else
					return 7;
			else
				if(yE > yP)
					return 3;
				else
					return 9;

		//}



		return 0;

	}

}



	