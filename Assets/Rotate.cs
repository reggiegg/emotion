using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public const float MAX_ROTATION = 360;
	private float prevConfusion;


	// Use this for initialization
	void Start () {
		prevConfusion = 0f;
	}

	// Update is called once per fram
	void Update() {
		Player p = (Player)GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(Player));
		float confusionDiff = p.Confusion - prevConfusion;
		Camera.main.transform.Rotate(0f, 0f, MAX_ROTATION*confusionDiff);
		p.gameObject.rigidbody2D.AddForce(new Vector3 (-Mathf.Sin(Mathf.Deg2Rad*(p.Confusion * MAX_ROTATION)) * -9.81f, Mathf.Cos(Mathf.Deg2Rad*(p.Confusion * MAX_ROTATION))*-9.81f, 0));
		p.transform.Rotate(0f,0f,(0.7f*MAX_ROTATION*confusionDiff));
		prevConfusion = p.Confusion;

	}
}
