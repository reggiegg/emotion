using UnityEngine;
using System.Collections;

public class Dust : MonoBehaviour {

	private bool fired = false;

	// Use this for initialization
	void Start () {
		particleSystem.Pause();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!fired && other.gameObject.tag == "Player")
		{
			particleSystem.Play();
			fired = true;
		}
	}
}
