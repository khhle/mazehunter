using UnityEngine;
using System.Collections;

public class ObjAnimation : MonoBehaviour {
	public Sprite[] spritesUp;
	public Sprite[] spritesDown;
	public Sprite[] spritesLeft;
	public Sprite[] spritesRight;
	public float framesPerSecond;
	public float timer;
	private int direcction;
	
	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		spriteRenderer = renderer as SpriteRenderer;
		
	}
	
	// Update is called once per frame
	void Update () {
		RobotScript rob = GetComponent<RobotScript>();
		if(rob)
			direcction = rob.directionType;
		else
		{
			enemyScript enemy = GetComponent<enemyScript>();
			direcction = enemy.directionType;
		}
		//direcction = rob.directionType;
		if (direcction == 1) {
			int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
			index = index % spritesUp.Length;
			spriteRenderer.sprite = spritesUp [index];
		}
		else if(direcction == 2) {
			int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
			index = index % spritesDown.Length;
			spriteRenderer.sprite = spritesDown [index];
		}
		else if(direcction == 3) {
			int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
			index = index % spritesLeft.Length;
			spriteRenderer.sprite = spritesLeft [index];
		}
		else if(direcction == 4) {
			int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
			index = index % spritesRight.Length;
			spriteRenderer.sprite = spritesRight [index];
		}
	}
}