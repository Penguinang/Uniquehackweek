using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowdownCube : MonoBehaviour {

	public GameObject gameController;
	static bool _switch = false;
	void Start()
	{
		gameController = GameObject.Find ("gameController");
	}

	void slowDown()
	{
		gameController.GetComponent<gameController> ().slowDown ();
		GetComponent<basicCube> ().destroy ();
	}
	void OnMouseUp()
	{
		if (_switch)
		if (GetComponent<basicCube> ().getArriveState () || GetComponent<basicCube> ().indexY < 3) {
			audioManager.getInstance ().playFunction ();
			slowDown ();
		}
	}

	static public void turnOff()
	{
		_switch = false;
	}
	static public void turnOn()
	{
		_switch = true;
	}
}
