using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private const float EMOTION_CHANGE = 0.0075f;
	private const float NEGATIVE_EMOTION_CHANGE = 0.0075f;
	private const float EMOTION_DECAY = 0.0025f;
	private const float CONFUSION_DECAY = 0.005f;

	private float _anger, _fear, _sadness, _confusion;
	private Vector3 _initPos;
	private bool triggeredLastFrame = false;
	private Trigger.Emotions lastTriggered = Trigger.Emotions.SAD;

	public float Anger	{ get{ return _anger; } }
	public float Fear	{ get{ return _fear; } }
	public float Sadness	{ get{ return _sadness; } }
	public float Confusion	{ get{ return _confusion; } }

	private Animation faceAnim;

	// Use this for initialization
	void Start () {
		_anger = 0f;
		_fear = 0f;
		_sadness = 0f;
		_confusion = 0f;
		_initPos = transform.position;

		faceAnim = transform.Find("Face_Anim").animation;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void FixedUpdate ()
	{
		if (!triggeredLastFrame) {
			updateEmotions ();
			//Debug.Log("Anger: " + _anger);
		}
		triggeredLastFrame = false;
	}

	void updateEmotions()
	{
		/*
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
*/
		_anger = Mathf.Max (0, _anger - EMOTION_DECAY);
		_fear = Mathf.Max (0, _fear - EMOTION_DECAY);
		_sadness = Mathf.Max (0, _sadness - EMOTION_DECAY);
		_confusion = Mathf.Max (0, _confusion - CONFUSION_DECAY);
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

		triggeredLastFrame = true;

		if (emotion != lastTriggered) {
			/*
			if (lastTriggered == Trigger.Emotions.SAD && emotion == Trigger.Emotions.ANGER) {
				//faceAnim.Play("face");
			} else if (lastTriggered == Trigger.Emotions.ANGER && emotion == Trigger.Emotions.SAD) {

			} else if (lastTriggered == Trigger.Emotions.SAD && emotion == Trigger.Emotions.CONFUSION) {
				
			} else if (lastTriggered == Trigger.Emotions.CONFUSION && emotion == Trigger.Emotions.SAD) {
				
			} else if (lastTriggered == Trigger.Emotions.SAD && emotion == Trigger.Emotions.FEAR) {
				
			} else if (lastTriggered == Trigger.Emotions.FEAR && emotion == Trigger.Emotions.SAD) {
				
			} else if (lastTriggered == Trigger.Emotions.ANGER && emotion == Trigger.Emotions.CONFUSION) {
				
			} else if (lastTriggered == Trigger.Emotions.CONFUSION && emotion == Trigger.Emotions.ANGER) {
				
			} else if (lastTriggered == Trigger.Emotions.ANGER && emotion == Trigger.Emotions.FEAR) {
				
			} else if (lastTriggered == Trigger.Emotions.FEAR && emotion == Trigger.Emotions.ANGER) {
				
			} else if (lastTriggered == Trigger.Emotions.FEAR && emotion == Trigger.Emotions.CONFUSION) {
				
			} else if (lastTriggered == Trigger.Emotions.CONFUSION && emotion == Trigger.Emotions.FEAR) {
				
			} else {
				// Execution should never reach this point
			}
			*/

		}

		lastTriggered = emotion;
	}

	public void reset()
	{
		_anger = 0f;
		_fear = 0f;
		_sadness = 0f;
		_confusion = 0f;
		transform.position = _initPos;
	}
}
