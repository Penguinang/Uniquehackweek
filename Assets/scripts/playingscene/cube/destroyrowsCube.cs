using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyrowsCube : MonoBehaviour {

	public int number = 0;
	public GameObject gameController;
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
		if(GetComponent<basicCube>().getArriveState())
			destroyrow ();
	}
}
