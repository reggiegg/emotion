using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {
	public enum Emotions
	{
		UNDEFINED,
		ANGER,
		FEAR,
		SAD,
		CONFUSION
	};

	public Emotions emotion;
	public bool addsEmotion;
	// Use this for initialization
	void Start () {
		//emotion = Emotions.UNDEFINED;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		Player p = (Player)coll.GetComponent (typeof(Player));
		if (p != null) {
			p.triggerEmotion (this.emotion, addsEmotion);
		}
	}

}
