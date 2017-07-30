using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {
	public List<List<GameObject>> map;
	public int[] top;

	void Start () {
		
	}

	void Update () {
		for (int i = 0; i < 7; i++) {
			if (top[i]>9)
				gameOver ();
		}
	}

	public void gameOver()
	{
		print ("gameOver");
		SceneManager.LoadScene ("start");
	}

	public void slowDown()
	{
		basicCube.slowDown ();
		Invoke ("recover",5.0f);
	}

	public void recover()
	{
		basicCube.recoverVelocity ();
	}

	public void destroyAll()
	{
		for (int i = 0; i < 7; i++)
			for (int j = 0; j < 10; j++)
				if (map [i] [j])
					map [i] [j].GetComponent<basicCube>().destroy ();
				
	}

	public void destroyRows(int rowsNumber)
	{
		for (int i = 0; i < 7; i++)
			for (int j = 0; j < rowsNumber; j++)
				if (map [i] [j])
					map [i] [j].GetComponent<basicCube>().destroy ();
	}

	public void destroyColor(string color)
	{
		for (int i = 0; i < 7; i++)
			for (int j = 0; j < 10; j++)
				if (map [i] [j]&&map[i][j].tag == color)
					map [i] [j].GetComponent<basicCube>().destroy ();
	}
}
