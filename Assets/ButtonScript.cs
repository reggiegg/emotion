using UnityEngine;
using System.Collections;

public abstract class ButtonScript : MonoBehaviour {
	public enum BtnState
	{
		UP,
		OVER,
		DOWN
	};
	BtnState _curState;
	public BtnState CurState { get { return _curState; } }
	public Sprite upSprite, overSprite, downSprite;
	// Use this for initialization
	void Start () {
		_curState = BtnState.UP;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeState(BtnState state)
	{
		_curState = state;
		switch (_curState) {
		case BtnState.UP:
			((SpriteRenderer)renderer).sprite = upSprite;
			break;
		case BtnState.OVER:
			((SpriteRenderer)renderer).sprite = overSprite;
			break;
		case BtnState.DOWN:
			((SpriteRenderer)renderer).sprite = downSprite;
			break;
		}
	}

	public abstract void doAction();
}
