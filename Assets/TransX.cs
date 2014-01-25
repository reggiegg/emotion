using UnityEngine;
using System.Collections;

public class TransX : MonoBehaviour {

	public float emotionScale = 0.0f;
	public int deltaLeft,  deltaLeftMax;
	public int deltaRight, deltaRightMax;

	private float originalX;

	// Use this for initialization
	void Start () {
		originalX = this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (emotionScale <= 1.0f)
			emotionScale += 0.01f;
		deltaLeft = (int)Mathf.Round(deltaLeftMax * emotionScale);
		Vector3 position = this.transform.position;
		position.x = originalX - deltaLeft;
		this.transform.position = position;
	}
}
