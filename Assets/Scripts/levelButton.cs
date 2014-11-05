using UnityEngine;
using System.Collections;

public class levelButton : MonoBehaviour {
	private Color mouseOverColor = Color.gray;
	private Color originalColor ;
	public string level;
	
	void OnMouseEnter()
	{
		originalColor = gameObject.renderer.material.GetColor ("_Color");
		gameObject.renderer.material.color = mouseOverColor;
		
	}
	
	void OnMouseExit()
	{
		gameObject.renderer.material.color = originalColor;
		
	}
	
	void OnMouseDown()
	{
		//GameObject.FindGameObjectWithTag ("Sound Player").GetComponent<SoundPlayerScript> ().switchToMenuMusic ();
		Application.LoadLevel ("s" + level);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
