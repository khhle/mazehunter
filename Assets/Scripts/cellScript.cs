using UnityEngine;
using System.Collections;

public class cellScript : MonoBehaviour {

	public int directionType;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//type 1: up
	//type 2: down
	//type 3: left
	//type 4: right
	void   OnTriggerEnter2D( Collider2D otherCollider){ 
		fenceScript fence = otherCollider.gameObject.GetComponent<fenceScript>();
		//Debug.Log("get collision");
		if (fence != null) {
			//Debug.Log("Cllide");
			//enemyScript enmy = this.transform.parent.gameObject.GetComponent<enemyScript>();
			enemyScript enmy = this.transform.parent.GetComponent<enemyScript>();
			//if(enmy)
				//Debug.Log("get enemy");
			if(enmy.isMove == false)
			{
				//enmy.canUp = enmy.canDown = enmy.canRight = enmy.canLeft = true;
				Debug.Log("get here");
				if(directionType == 1) 
				{
					Debug.Log("Can't up");
					enmy.canUp = false;
				}
				if(directionType == 2)
				{
					Debug.Log("Can't down");
					enmy.canDown = false;
				}
				if(directionType == 3)
				{
					Debug.Log("Can't left");
					enmy.canLeft = false;
				}
				if(directionType == 4)
				{
					Debug.Log("Can't right");
					enmy.canRight = false;
				}
			}

		}
	}

	void OnTriggerStay2D(Collider2D otherCollider){ 
		fenceScript fence = otherCollider.gameObject.GetComponent<fenceScript>();
		//Debug.Log("get collision");
		if (fence != null) {
			//Debug.Log("Cllide");
			//enemyScript enmy = this.transform.parent.gameObject.GetComponent<enemyScript>();
			enemyScript enmy = this.transform.parent.GetComponent<enemyScript>();
			//if(enmy)
				//Debug.Log("get enemy2");
			if(enmy.isMove == false)
			{
				//enmy.canUp = enmy.canDown = enmy.canRight = enmy.canLeft = true;
				//Debug.Log("get here3");
				if(directionType == 1) 
				{
					//Debug.Log("Can't up2");
					enmy.canUp = false;
				}
				if(directionType == 2)
				{
					//Debug.Log("Can't down2");
					enmy.canDown = false;
				}
				if(directionType == 3)
				{
					//Debug.Log("Can't left2");
					enmy.canLeft = false;
				}
				if(directionType == 4)
				{
					//Debug.Log("Can't right2");
					enmy.canRight = false;
				}
			}
			
		}

	}
	void OnTriggerExit2D(Collider2D otherCollider){ 
		fenceScript fence = otherCollider.gameObject.GetComponent<fenceScript>();
		//Debug.Log("get collision");
		if (fence != null) {
			//Debug.Log("Cllide");
			//enemyScript enmy = this.transform.parent.gameObject.GetComponent<enemyScript>();
			enemyScript enmy = this.transform.parent.GetComponent<enemyScript>();
			//if(enmy)
			//Debug.Log("get enemy2");
			//if(enmy.isMove == false)
			//{
				//enmy.canUp = enmy.canDown = enmy.canRight = enmy.canLeft = true;
				//Debug.Log("get here3");
				if(directionType == 1) 
				{
					//Debug.Log("Can't up2");
					enmy.canUp = true;
				}
				if(directionType == 2)
				{
					//Debug.Log("Can't down2");
					enmy.canDown = true;
				}
				if(directionType == 3)
				{
					//Debug.Log("Can't left2");
					enmy.canLeft = true;
				}
				if(directionType == 4)
				{
					//Debug.Log("Can't right2");
					enmy.canRight = true;
				}
			//}
			
		}
	}

}
