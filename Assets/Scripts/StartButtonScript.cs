using UnityEngine;
using System.Collections;

public class StartButtonScript : ButtonScript {

	public override void doAction()
	{
		Application.LoadLevel ("OfficeScene");
	}
}
