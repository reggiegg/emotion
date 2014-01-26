using UnityEngine;
using System.Collections;

public class TransY : MonoBehaviour {

	private float emotionScale = 0.0f;
	private int deltaUp, deltaDown;
	public int deltaUpMax, deltaDownMax;

	private float originalY;

	// Use this for initialization
	void Start () {
		originalY = this.transform.position.y;
		// Prevent weird movment. Block can only move one direction on an axis
		// either left or right from its normal position (not including movement
		// for it to return to its original position
		if (deltaUpMax > 0)
			deltaDownMax = 0;
		if (deltaDownMax > 0)
			deltaUpMax = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 position = this.transform.position;
		//float anger = ((Player)GameObject.FindGameObjectWithTag("Player")).Anger;
		//float anger = 0.0f;
		Player p = (Player)GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(Player));
		
		//Player p = MonoBehaviour.FindObjectOfType(Player);
		
		if (deltaUpMax > 0)
		{
			deltaUp = (int)Mathf.Round(deltaUp * p.Anger);
			position.y = originalY - deltaUp;
		}
		
		if (deltaDownMax > 0)
		{
			deltaDown = (int)Mathf.Round(deltaDownMax * p.Anger);
			position.y = originalY + deltaDown;
			
		}
		
		this.transform.position = position;
	}
}
