﻿using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float moveForce, jumpForce;
	public float maxSpeed;

	private bool jumping;

	// Use this for initialization
	void Start () {
		jumping = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {

		if (Mathf.Abs(rigidbody2D.velocity.x) < maxSpeed)
		{
			rigidbody2D.AddForce(new Vector3(Input.GetAxis("Horizontal") * moveForce, 0.0f));
		}

		if (jumping)
		{
			if (rigidbody2D.velocity.y < 0.001f && rigidbody2D.velocity.y > -0.001f)
				jumping = false;
		}

		if (Input.GetButton("Jump"))
		{
			if (!jumping)
			{
				jumping = true;
				rigidbody2D.AddForce(new Vector3(0.0f, jumpForce));
			}
		}
		Vector3 v = rigidbody2D.velocity;
		//Debug.Log("Player velocity: " + v);
	}
}