using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clicktolink : MonoBehaviour {
	GameObject gameController;
	static bool _switch = false;
	bool selected = false;
	void Start () {
		gameController = GameObject.Find ("gameController");	
	}

	void OnMouseUp()
	{
		if(_switch&&!selected)
		if (GetComponent<basicCube> ().getArriveState ()) {
			select ();
			gameController.GetComponent<gameController> ().click (gameObject);
		}
	}

	public void select()
	{
		gameObject.transform.localScale = new Vector3 (0.7f,0.7f,0.7f);
		selected = true;
	}

	public void unselect()
	{
		gameObject.transform.localScale = new Vector3 (1,1,1);
		selected = false;
	}
	void OnDestroy()
	{
		unselect ();
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
