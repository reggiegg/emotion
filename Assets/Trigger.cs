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
		if (emotion == Emotions.CONFUSION) {
			Color c = ((SpriteRenderer)renderer).color;
			int add = Random.Range(0, 2);
			switch(Random.Range(0, 3))
			{
			case 0:
				if(add == 1)
				{
					c.r = Mathf.Min (1, c.r + 0.01f);
				}
				else
				{
					c.r = Mathf.Max (0, c.r - 0.01f);
				}
				break;
			case 1:
				if(add == 1)
				{
					c.g = Mathf.Min (1, c.g + 0.01f);
				}
				else
				{
					c.g = Mathf.Max (0, c.g - 0.01f);
				}
				break;
			case 2:
				if(add == 1)
				{
					c.b = Mathf.Min (1, c.b + 0.01f);
				}
				else
				{
					c.b = Mathf.Max (0, c.b - 0.01f);
				}
				break;
			}
			((SpriteRenderer)renderer).color = c;
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		Player p = (Player)coll.GetComponent (typeof(Player));
		if (p != null) {
			p.triggerEmotion (this.emotion, addsEmotion);
		}
	}

}
