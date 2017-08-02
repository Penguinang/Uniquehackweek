using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyallCube : MonoBehaviour {

	public GameObject gameController;
	static bool _switch = false;
	void Start()
	{
		gameController = GameObject.Find ("gameController");
	}

	void Update () {
		
	}

	public void destroyall()
	{
		gameController.GetComponent<gameController> ().destroyAll ();
	}
	void OnMouseUp()
	{
		if (_switch && GetComponent<basicCube> ().getArriveState ()) {
			destroyall ();
			GetComponent<basicCube> ().destroy ();
		}
	}

	public static void turnOn()
	{
		_switch = true;
	}
	public static void turnOff()
	{
		_switch = false;
	}
}
