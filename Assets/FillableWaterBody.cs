using UnityEngine;
using System.Collections;

public class FillableWaterBody : MonoBehaviour {
	
	Transform spriteTransform;
	public Vector3 spriteStartScale;
	 
	void Start () {
		spriteTransform = transform.Find("WaterSprite");
		spriteStartScale = spriteTransform.localScale;

		spriteTransform.localPosition -= new Vector3(0, 3.02f * spriteStartScale.y);
		spriteTransform.localScale = new Vector3(spriteStartScale.x, 0);
	}

	
	void Update () {
	
	}
}
