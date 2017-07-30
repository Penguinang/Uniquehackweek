using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punishCube : MonoBehaviour {
	basicCube basic;
	bool active = false;
	void Start () {
		basic = GetComponent<basicCube> ();
	}

	void Update () {
		if (active && basic.getArriveState ()&&basic.indexY == 0)
			explode ();
	}

	void explode()
	{
		print ("explode");
		for (int i = basic.indexX - 4; i < basic.indexX + 4&&i<7; i++)
			for (int j = basic.indexY - 4; j < basic.indexY + 4&&j<15; j++)
				if (i >= 0 && j >= 0 && basic.map [i] [j])
					basic.map [i] [j].GetComponent<basicCube> ().destroy ();
	}

	void punish()
	{
		basic.activatePunish ();
		active = true;
		print ("punish start");
	}

	void OnMouseUp()
	{
		if(!GetComponent<basicCube>().getArriveState())
			punish ();
	}
}
