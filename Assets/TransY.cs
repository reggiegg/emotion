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
		// Temp code before emotion system is in place
		if (Input.GetButton("Fire1"))
		{
			if (emotionScale <= 1.0f)
				emotionScale += 0.01f;
		}
		if (Input.GetButton("Fire2"))
		{
			if (emotionScale >= 0.01f)
				emotionScale -= 0.01f;
		}

		Vector3 position = this.transform.position;

		if (deltaUpMax > 0)
		{
			deltaUp = (int)Mathf.Round(deltaUpMax * emotionScale);
			position.y = originalY + deltaUp;
		}

		if (deltaDownMax > 0)
		{
			deltaDown = (int)Mathf.Round(deltaDownMax * emotionScale);
			position.y = originalY - deltaDown;

		}

		this.transform.position = position;
	}
}
