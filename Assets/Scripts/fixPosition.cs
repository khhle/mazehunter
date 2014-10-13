using UnityEngine;
using System.Collections;
using System;
public class fixPosition : MonoBehaviour {

	private bool isFix = false;
	private bool isMove;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float x1 = this.transform.position.x;
		float y1 = this.transform.position.y;
		float z1 = this.transform.position.z;
		RobotScript rob = GetComponent<RobotScript> ();
		if(rob)
			isMove = rob.isMove;
		else
		{
			enemyScript enemy = GetComponent<enemyScript>();
			isMove = enemy.isMove;
		}
		//bool isMove = rob.isMove;
		if(x1*10%10 != 0)
		{
			x1 = (float)Math.Round (x1);
			isFix = true;
		}
		if(y1*10%10 != 0)
		{
			y1 = (float)Math.Round (y1);
			isFix = true;
		}
		if (isFix && isMove == false)
			this.transform.position = new Vector3 (x1, y1, z1);
	
	}
}
