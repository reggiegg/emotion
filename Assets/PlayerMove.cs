using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {

		rigidbody2D.AddForce(new Vector3(Input.GetAxis("Horizontal") * 10.0f, 0.0f));
		//Debug.Log(Input.GetAxis("Horizontal"));
	}
}
