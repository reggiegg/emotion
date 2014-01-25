using UnityEngine;
using System.Collections;

public class TransX : MonoBehaviour {

	private int deltaLeft, deltaRight;
	public int deltaLeftMax, deltaRightMax;

	private float originalX;

	// Use this for initialization
	void Start () {
		originalX = this.transform.position.x;
		// Prevent weird movment. Block can only move one direction on an axis
		// either left or right from its normal position (not including movement
		// for it to return to its original position
		if (deltaLeftMax > 0)
			deltaRightMax = 0;
		if (deltaRightMax > 0)
			deltaLeftMax = 0;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 position = this.transform.position;
		//float anger = ((Player)GameObject.FindGameObjectWithTag("Player")).Anger;
		//float anger = 0.0f;
		Player p = (Player)GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(Player));

		//Player p = MonoBehaviour.FindObjectOfType(Player);

		if (deltaLeftMax > 0)
		{
			deltaLeft = (int)Mathf.Round(deltaLeftMax * p.Anger);
			position.x = originalX - deltaLeft;
		}

		if (deltaRightMax > 0)
		{
			deltaRight = (int)Mathf.Round(deltaRightMax * p.Anger);
			position.x = originalX + deltaRight;

		}

		this.transform.position = position;
	}
}
