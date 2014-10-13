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
		if (fence != null) {
			//Debug.Log("Cllide");
			//enemyScript enmy = this.transform.parent.gameObject.GetComponent<enemyScript>();
			enemyScript enmy = this.transform.parent.GetComponent<enemyScript>();
			if(enmy.shouldCheckStuck == true)
			{
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

}
