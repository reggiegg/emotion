using UnityEngine;
using System.Collections;

public class Scale : MonoBehaviour {

	private float emotionScale = 0.0f;
	private float deltaScale;
	public float deltaScaleMax = 1.0f;

	private Vector3 originalScale;

	// Use this for initialization
	void Start () {
		originalScale = this.transform.localScale;
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

		Vector3 scale = this.transform.localScale;

		if (deltaScaleMax != 1.0f)
		{
			deltaScale = deltaScaleMax * emotionScale;
			scale.x = originalScale.x + deltaScale;
			scale.y = originalScale.y + deltaScale;
		}

		this.transform.localScale = scale;
	}
}
