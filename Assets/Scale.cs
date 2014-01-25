using UnityEngine;
using System.Collections;

public class Scale : MonoBehaviour {

	private float deltaScale;
	public float deltaScaleMax = 1.0f;

	private Vector3 originalScale;

	// Use this for initialization
	void Start () {
		originalScale = this.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 scale = this.transform.localScale;

		Player p = (Player)GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(Player));


		if (deltaScaleMax != 1.0f)
		{
			deltaScale = deltaScaleMax * p.Fear;
			scale.x = originalScale.x + deltaScale;
			scale.y = originalScale.y + deltaScale;
		}

		this.transform.localScale = scale;
	}
}
