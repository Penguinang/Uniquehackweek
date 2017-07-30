using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyallCube : MonoBehaviour {

	public GameObject gameController;
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
		if(GetComponent<basicCube>().getArriveState())
			destroyall ();
	}
}
