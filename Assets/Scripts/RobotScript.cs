using UnityEngine;
using System.Collections;
using System;
public class RobotScript : MonoBehaviour {
	
	//type 1: up
	//type 2: down
	//type 3: left
	//type 4: right
	public int directionType;
	private MoveScript mov;
	//private int delay = 0;
	//private int delayTime = 60;
	public bool isMove = false;
	private enemyScript enemy;
	private gameController gameControl;
	public bool shouldMove = false;
	// Use this for initialization
	void Start () {
		mov =  GetComponent<MoveScript>();
		enemy = GameObject.Find("enemy").GetComponent<enemyScript>();
		gameControl = GameObject.Find("controller").GetComponent<gameController>();
		directionType = 0;
		mov.direction = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if(shouldMove == false)
		{
			directionType = 0;
			mov.direction = new Vector2(0, 0);
			isMove = false;
		}
		
		//enemy.shouldMove = false;

		else
		{

				



			if(directionType == 1)
			{
				mov.direction = new Vector2(0, 1);
				//delay = delayTime;
				isMove = true;
				//enemy.directionType = 2;
				gameControl.isMove = true;
				//enemy.delay = 30;
				//enemy.shouldMove = true;
			}
			else if(directionType == 2)
			{
				mov.direction = new Vector2(0, -1);
				//delay = delayTime;
				isMove = true;
				//enemy.directionType = 1;
				gameControl.isMove = true;

			}
			else if(directionType == 3)
			{
				mov.direction = new Vector2(-1, 0);
				//delay = delayTime;
				isMove = true;
				//enemy.directionType = 4;
				gameControl.isMove = true;

			}
			else if(directionType == 4)
			{
				mov.direction = new Vector2(1, 0);
				//delay = delayTime;
				isMove = true;
				//enemy.directionType = 3;
				gameControl.isMove = true;

			}
		}


	}





	
}