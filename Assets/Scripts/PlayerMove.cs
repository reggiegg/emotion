using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{

	public float moveForce, jumpForce;
	public float maxSpeed;
	private bool jumping;
	private bool facingRight = true;
	private AudioSource[] audioSources;

	// Use this for initialization
	void Start ()
	{
		jumping = false;
		audioSources = GetComponents<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void FixedUpdate ()
	{

		float haxis = Input.GetAxis ("Horizontal");

		if (Mathf.Abs (rigidbody2D.velocity.x) < maxSpeed) {
			float dx = 0.0f;

			if (Mathf.Abs (rigidbody2D.velocity.x) < maxSpeed * 0.25f) {
				dx = moveForce * 8;
			} else if (Mathf.Abs (rigidbody2D.velocity.x) < maxSpeed * 0.5f) {
				dx = moveForce * 4;
			} else {
				dx = moveForce;
			}
			rigidbody2D.AddForce (new Vector3 (Input.GetAxis ("Horizontal") * dx, 0.0f));
		}

		if (jumping) {
			if (rigidbody2D.velocity.y < 0.001f && rigidbody2D.velocity.y > -0.001f) {
				jumping = false;
				audioSources [1].Play ();
			}
		}

		if (Input.GetButton ("Jump")) {
			if (!jumping) {
				jumping = true;
				rigidbody2D.AddForce (new Vector3 (0.0f, jumpForce));
				audioSources [0].Play ();
			}
		}
		Vector3 v = rigidbody2D.velocity;

		// If the input is moving the player right and the player is facing left...
		if (haxis > 0 && !facingRight)
			// ... flip the player.
			Flip ();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (haxis < 0 && facingRight) {
			// ... flip the player.
			Flip();

			//Debug.Log("Player velocity: " + v);
		}
	}

	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.FindChild ("Player_Anim").transform.localScale;
		theScale.x *= -1;
		transform.FindChild ("Player_Anim").transform.localScale = theScale;

		Vector3 faceScale = transform.FindChild ("Face_Anim").transform.localScale;
		faceScale.x *= -1;
		transform.FindChild ("Face_Anim").transform.localScale = faceScale;

	}
}


