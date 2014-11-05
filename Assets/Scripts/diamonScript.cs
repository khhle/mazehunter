using UnityEngine;
using System.Collections;

public class diamonScript : MonoBehaviour {


	private gameController gameControl;
	// Use this for initialization
	void Start () {
		gameControl = GameObject.Find("controller").GetComponent<gameController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a robot?
		RobotScript rob = otherCollider.gameObject.GetComponent<RobotScript>();
		if (rob != null )
		{
			gameControl.gameWin();
			Destroy(gameObject);
		}
	}
}
