using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowdownCube : MonoBehaviour {

	public GameObject gameController;
	void Start()
	{
		gameController = GameObject.Find ("gameController");
	}

	void slowDown()
	{
		gameController.GetComponent<gameController> ().slowDown ();
	}
	void OnMouseUp()
	{
		if(GetComponent<basicCube>().getArriveState())
			slowDown ();
	}
}
