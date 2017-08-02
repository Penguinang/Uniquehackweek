using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyrowsCube : MonoBehaviour {

	public int number = 0;
	public GameObject gameController;
	static bool _switch = false;
	void Start()
	{
		gameController = GameObject.Find ("gameController");
	}

	void destroyrow()
	{
		gameController.GetComponent<gameController> ().destroyRows (number);
	}
	void OnMouseUp()
	{
		if(_switch)
		if (GetComponent<basicCube> ().getArriveState ()||GetComponent<basicCube>().indexY<3) {
			audioManager.getInstance ().playFunction ();
			destroyrow ();
			GetComponent<basicCube> ().destroy ();
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
