using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private float _anger, _fear, _sadness, _confusion;
	private Vector3 _curDest;
	private const float MAX_MOVE_SPEED = 5f, EMOTION_CHANGE = 0.05f, EMOTION_DECAY = 0.001f, NEGATIVE_EMOTION_CHANGE = 0.05f;

	public float Anger	{ get{ return _anger; } }
	public float Fear	{ get{ return _fear; } }
	public float Sadness	{ get{ return _sadness; } }
	public float Confusion	{ get{ return _confusion; } }

	// Use this for initialization
	void Start () {
		_anger = 0f;
		_fear = 0f;
		_sadness = 0f;
		_confusion = 0f;
		_curDest = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			_curDest.x -= MAX_MOVE_SPEED * Time.deltaTime;
		}
		
		if(Input.GetKey(KeyCode.RightArrow))
		{
			_curDest.x += MAX_MOVE_SPEED * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			_curDest.y -= MAX_MOVE_SPEED * Time.deltaTime;
		}
		
		if(Input.GetKey(KeyCode.UpArrow))
		{
			_curDest.y += MAX_MOVE_SPEED * Time.deltaTime;
		}

		updateEmotions ();

		//transform.position = dest;
		transform.position = Vector3.Lerp (transform.position, _curDest, Time.deltaTime);
	}

	void updateEmotions()
	{

		if (Input.GetKey (KeyCode.A)) 
		{
			_anger = Mathf.Min(1, _anger + EMOTION_CHANGE);
		}

		if(Input.GetKey(KeyCode.F))
		{
			_fear = Mathf.Min(1, _fear + EMOTION_CHANGE);
		}
		
		if (Input.GetKey (KeyCode.S)) 
		{
			_sadness = Mathf.Min(1, _sadness + EMOTION_CHANGE);
		}
		
		if(Input.GetKey(KeyCode.D))
		{
			_confusion = Mathf.Min(1, _confusion + EMOTION_CHANGE);
		}

		_anger = Mathf.Max (0, _anger - EMOTION_DECAY);
		_fear = Mathf.Max (0, _fear - EMOTION_DECAY);
		_sadness = Mathf.Max (0, _sadness - EMOTION_DECAY);
		_confusion = Mathf.Max (0, _confusion - EMOTION_DECAY);
	}

	public void triggerEmotion(Trigger.Emotions emotion, bool addsEmotion)
	{
		switch(emotion)
		{
		case Trigger.Emotions.ANGER:
			if(addsEmotion)
			{
				_anger = Mathf.Min(1, _anger + EMOTION_CHANGE);
			}
			else
			{
				_anger = Mathf.Min(1, _anger - NEGATIVE_EMOTION_CHANGE);
			}
			break;
		case Trigger.Emotions.SAD:
			if(addsEmotion)
			{
				_sadness = Mathf.Min(1, _sadness + EMOTION_CHANGE);
			}
			else
			{
				_sadness = Mathf.Min(1, _sadness - NEGATIVE_EMOTION_CHANGE);
			}
			break;
		case Trigger.Emotions.FEAR:
			if(addsEmotion)
			{
				_fear = Mathf.Min(1, _fear + EMOTION_CHANGE);
			}
			else
			{
				_fear = Mathf.Min(1, _fear - NEGATIVE_EMOTION_CHANGE);
			}
			break;
		case Trigger.Emotions.CONFUSION:
			if(addsEmotion)
			{
				_confusion = Mathf.Min(1, _confusion + EMOTION_CHANGE);
			}
			else 
			{
				_confusion = Mathf.Min(1, _confusion - NEGATIVE_EMOTION_CHANGE);
			}
			break;
		case Trigger.Emotions.UNDEFINED:

			break;
		default:

			break;
		}
	}
}
