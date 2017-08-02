﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroycolorCube : MonoBehaviour {

//	public GameObject sample;
	public GameObject gameController;
	static public bool _switch = false;
	void Start()
	{
		gameController = GameObject.Find ("gameController");
	}

	void destroycolor()
	{
		gameController.GetComponent<gameController> ().destroyColor(tag);
	}
	void OnMouseUp()
	{
		if (_switch && GetComponent<basicCube> ().getArriveState ()) {
			destroycolor();
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
