using UnityEngine;
using System.Collections;

public class WaterCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		PlayerMove p = (PlayerMove)coll.GetComponent(typeof(PlayerMove));
		if (p != null) {
			p.inWater = true;
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		PlayerMove p = (PlayerMove)coll.GetComponent(typeof(PlayerMove));
		if (p != null) {
			p.inWater = false;
		}
	}
}
