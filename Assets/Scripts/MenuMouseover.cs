using UnityEngine;
using System.Collections;

public class MenuMouseover : MonoBehaviour 
{
	public Vector3 position;
	private Rect buttonRect;
	private Color colour = new Color(67, 150, 255);


	void Start()
	{
		position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		buttonRect = new Rect (position.x, position.y, 60, 30);
	}


	void Update()
	{
		Vector2 mousePos = Input.mousePosition;
		var textArr = GameObject.FindGameObjectsWithTag ("StartButton");
		var textObject = textArr [0];
		//if (buttonRect.Contains(mousePos)){
		textObject.renderer.material.SetColor("_Blue", this.colour);
		}
	}
}