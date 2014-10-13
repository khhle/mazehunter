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
	public bool canRight;
	public bool canLeft;
	public bool canUp;
	public bool canDown;
	public bool shouldReset = false;
	public bool shouldCheckStuck = false;
	public int delayTime;
	// Use this for initialization
	void Start () {
		mov =  GetComponent<MoveScript>();
	}
	
	// Update is called once per frame
	void Update () {

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
		}
			

	}



	void OnCollisionEnter2D( Collision2D otherCollider){ 
		RobotScript rob = otherCollider.gameObject.GetComponent<RobotScript>();
		if (rob != null) {
			SpecialEffectsHelper.Instance.Explosion (transform.position);
			Destroy (rob.gameObject);
			//gameController.roverExploded = true;
			//gameController.gameOver ();
			//rob.transform.position = new Vector3 (0, 0, 0);
		}
	}
}