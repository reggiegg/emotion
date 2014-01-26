using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public const float MAX_ROTATION = 360;
	public const float GRAVITY = -20.03f;
	private float prevConfusion;

	private const float GRAVITY_MULTIPLIER = 2;

	// Use this for initialization
	void Start () {
		prevConfusion = 0f;
	}

	// Update is called once per fram
	void FixedUpdate() {
		Player p = (Player)GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(Player));
		var spriteArray = GameObject.FindGameObjectsWithTag ("Sprite");
		var sprite = spriteArray [0];
		float confusionDiff = p.Confusion - prevConfusion;

		//Rotate gravity
		//p.gameObject.rigidbody2D.AddForce(new Vector3 (-Mathf.Sin(Mathf.Deg2Rad*(p.Confusion * MAX_ROTATION)) * -9.81f, Mathf.Cos(Mathf.Deg2Rad*(p.Confusion * MAX_ROTATION)) * -9.81f, 0));
		p.rigidbody2D.AddForce(sprite.transform.up * GRAVITY);
		//Rotate camera
		Camera.main.transform.RotateAround(sprite.transform.position, Vector3.forward, MAX_ROTATION * confusionDiff);
		//Rotate sprite
		sprite.transform.Rotate(0f, 0f, (MAX_ROTATION * confusionDiff));
		prevConfusion = p.Confusion;

		//Rotate the head
		p.transform.Find ("Head").transform.RotateAround (sprite.transform.position, Vector3.forward, MAX_ROTATION * confusionDiff);
	}
}
