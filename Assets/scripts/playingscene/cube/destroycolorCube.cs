using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroycolorCube : MonoBehaviour {

//	public GameObject sample;
	public GameObject gameController;
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
		if(GetComponent<basicCube>().getArriveState())
			destroycolor();
	}
}
