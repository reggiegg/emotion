using UnityEngine;
using System.Collections;

public class EmotionOverlay : MonoBehaviour {

	// Use this for initialization
	private Color _confusedColour;
	private const float CONFUSION_DELTA = 0.05f;
	public bool fadingToBlack, hasFadedToBlack;
	private bool _deathTransition, _resetting ;
	void Start () {
		transform.localScale = new Vector3 (Camera.main.pixelWidth * 50, Camera.main.pixelHeight * 50, 1);
		((SpriteRenderer)renderer).color = new Color (1.0f, 0, 0, 0f);
		transform.position = new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
		_confusedColour = new Color (0.5f, 0.5f, 0);
		_deathTransition = false;
		fadingToBlack = false;
	}

	// Update is called once per frame
	void Update () {
		Color c;
		if (_deathTransition) {
			if(fadingToBlack)
			{
				c = ((SpriteRenderer)renderer).color;
				c.r = Mathf.Max(0, c.r - 0.01f);
				c.g = Mathf.Max(0, c.g - 0.01f);
				c.b = Mathf.Max(0, c.b - 0.01f);
				c.a = Mathf.Min(1, c.a + 0.01f);
				((SpriteRenderer)renderer).color = c;
				fadingToBlack = !(c.r == 0 && c.g == 0 && c.b == 0 && c.a == 1);
				hasFadedToBlack = !fadingToBlack;
				transform.position = new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y, -0.5f);
			}
			else if(_resetting)
			{
				c = ((SpriteRenderer)renderer).color;

				c.a = Mathf.Max(0, c.a - 0.01f);
				((SpriteRenderer)renderer).color = c;
				_deathTransition = c.a != 0;
				hasFadedToBlack = _deathTransition;
				_resetting = _deathTransition;
			}
		} else {
			Player p = (Player)GameObject.FindGameObjectWithTag ("Player").GetComponent ("Player");
			if (p != null) {
				c = new Color (0, 0, 0, 0);
				c.r = p.Anger;
				c.b = p.Sadness;
				c = p.Fear * (new Color (0f, 0, 0)) + (1.0f - p.Fear) * c;

				if (p.Confusion > 0) {
					updateConfusionColour ();
					c = (1.0f - p.Confusion) * c + p.Confusion * _confusedColour;
				}

				c.a = Mathf.Min (0.6f, p.Anger + p.Fear + p.Confusion + p.Sadness);

				((SpriteRenderer)renderer).color = c;
			}
		}
	}

	void updateConfusionColour()
	{
		int add = Random.Range(0, 2);
		switch(Random.Range(0, 3))
		{
		case 0:
			if(add == 1)
			{
				_confusedColour.r = Mathf.Min (1, _confusedColour.r + CONFUSION_DELTA);
			}
			else
			{
				_confusedColour.r = Mathf.Max (0, _confusedColour.r - CONFUSION_DELTA);
			}
			break;
		case 1:
			if(add == 1)
			{
				_confusedColour.g = Mathf.Min (1, _confusedColour.g + CONFUSION_DELTA);
			}
			else
			{
				_confusedColour.g = Mathf.Max (0, _confusedColour.g - CONFUSION_DELTA);
			}
			break;
		case 2:
			if(add == 1)
			{
				_confusedColour.b = Mathf.Min (1, _confusedColour.b + CONFUSION_DELTA);
			}
			else
			{
				_confusedColour.b = Mathf.Max (0, _confusedColour.b - CONFUSION_DELTA);
			}
			break;
		}
	}

	public void fadeToBlack()
	{
		if (!_resetting) {
			fadingToBlack = true;
			_deathTransition = true;
		}
	}

	public void resetOverlay()
	{
		if (!fadingToBlack) {
			_resetting = true;
		}
	}
}
