using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonManager : MonoBehaviour {

	List<ButtonScript> _buttons;
	int _curIndex;

	// Use this for initialization
	void Start () {
		GameObject[] buttons = GameObject.FindGameObjectsWithTag ("Button");
		ButtonScript cur;
		_buttons = new List<ButtonScript> ();
		for(int i = 0; i < buttons.Length; i++)
		{
			cur = (ButtonScript)buttons[i].GetComponent(typeof(ButtonScript));
			if(cur != null)
			{
				_buttons.Add(cur);
			}
		}
		_buttons.Sort (new ButtonComparer());
		_curIndex = 0;
		if (_buttons.Count != 0) {
			_buttons[_curIndex].changeState(ButtonScript.BtnState.OVER);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (_buttons.Count == 0) {
			return;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			_buttons[_curIndex].changeState(ButtonScript.BtnState.UP);
			if(++_curIndex >= _buttons.Count)
			{
				_curIndex = 0;
			}
			_buttons[_curIndex].changeState(ButtonScript.BtnState.OVER);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			_buttons[_curIndex].changeState(ButtonScript.BtnState.UP);
			if(--_curIndex < 0)
			{
				_curIndex = _buttons.Count - 1;
			}
			_buttons[_curIndex].changeState(ButtonScript.BtnState.OVER);
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			_buttons[_curIndex].changeState(ButtonScript.BtnState.DOWN);
		}
		else if (Input.GetKeyUp (KeyCode.Return)) {
			if(_buttons[_curIndex].CurState == ButtonScript.BtnState.DOWN)
			{
				_buttons[_curIndex].doAction();
			}
		}
	}

	public class ButtonComparer : IComparer<ButtonScript>
	{
		public int Compare(ButtonScript a, ButtonScript b)
		{
			if (a.transform.position.y != b.transform.position.y) //If they are not at the same height
			{
				return (int)(b.transform.position.y - a.transform.position.y);	//If a is higher, it should show up earlier in the list
						
			} 
			else if (a.transform.position.x != b.transform.position.x) 
			{
				return (int)(a.transform.position.x - b.transform.position.x);
			}
			return 0;
		}
	}
}
