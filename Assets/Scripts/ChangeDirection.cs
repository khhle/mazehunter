using UnityEngine;

/// <summary>
/// 
/// </summary>
public class ChangeDirection : MonoBehaviour
{
	//type 1: up
	//type 2: down
	//type 3: left
	//type 4: right
	
	public int type;
	
	void Start () { 
		
	}
	
	
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a robot?
		RobotScript rob = otherCollider.gameObject.GetComponent<RobotScript>();
		if (rob != null)
		{
			rob.directionType = type;
			
			
		}
	}
}