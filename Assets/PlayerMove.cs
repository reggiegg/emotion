using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float moveForce, jumpForce;
	public float maxSpeed;

	private bool jumping;

	private bool facingRight = true;

	// Use this for initialization
	void Start () {
		jumping = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {

		float haxis = Input.GetAxis("Horizontal");

		if (Mathf.Abs(rigidbody2D.velocity.x) < maxSpeed)
		{
			rigidbody2D.AddForce(new Vector3(haxis * moveForce, 0.0f));
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

		// If the input is moving the player right and the player is facing left...
		if(haxis > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(haxis < 0 && facingRight)
			// ... flip the player.
			Flip();

		//Debug.Log("Player velocity: " + v);
	}
	
	void Flip ()
		{
			// Switch the way the player is labelled as facing.
			facingRight = !facingRight;
			
			// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.FindChild ("Player_Anim").transform.localScale;
			theScale.x *= -1;
		transform.FindChild("Player_Anim").transform.localScale = theScale;
		}
	}


