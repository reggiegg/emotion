using UnityEngine;
using System.Collections;

public class ExitButtonScript : ButtonScript {

	public override void doAction ()
	{
		Application.Quit ();
	}
}
