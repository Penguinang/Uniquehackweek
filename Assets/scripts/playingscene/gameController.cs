using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class gameController : MonoBehaviour {
	public List<List<GameObject>> map;
	public int[] top;
	public List<GameObject> clicks;
	public GameObject cubepool;
	public GameObject cubeSpawner;

	public GameObject line;
	public GameObject pauseLayer;
	public GameObject gameoverLayer;
	public GameObject cubeNumber;

	bool running = true;
	void Start () {
		init ();
	}

	void Update () {
		for (int i = 0; i < 7; i++) {
			if (top[i]>8&&running)
				gameOver ();
		}

		bool back = Input.GetKeyDown (KeyCode.Escape);
		if (back) {
			if (running)
				pause ();
			else
				_continue ();
		}
	}

	public void init()
	{
		for (int i = 0; i < clicks.Count; i++)
			clicks.RemoveAt (i);
		for (int i = 0; i < cubepool.transform.childCount; i++) {
				cubepool.transform.GetChild (i).GetComponent<basicCube> ().destroy ();
		}
		cubeSpawner.GetComponent<spawnCube> ().init ();
		basicCube.init ();
//		clicktolink.turnOn ();
		activateClickCube();
		running = true;
	}

	public void gameOver()
	{
		running = false;
		audioManager.getInstance ().playGG();
		gameoverLayer.SetActive(true);
		basicCube.pause ();
		cubeNumber.GetComponent<Text> ().text = "" + basicCube.getDestroyNumber ();
		inactivateClickCube ();
//		clicktolink.turnOff ();
	}

	public void pause()
	{
		running = false;
		cubeSpawner.GetComponent<spawnCube>().pause ();
		pauseLayer.SetActive (true);
		basicCube.pause ();
//		clicktolink.turnOff ();
		inactivateClickCube();
	}
	public void _continue()
	{
		running = true;
		cubeSpawner.GetComponent<spawnCube>().recover ();
		pauseLayer.SetActive (false);
		basicCube.recoverVelocity ();
//		clicktolink.turnOn ();
		activateClickCube();
	}

	void activateClickCube()
	{
		clicktolink.turnOn ();
		destroyallCube.turnOn ();
		destroyrowsCube.turnOn ();
		destroycolorCube.turnOn ();
		punishCube.turnOn ();
		slowdownCube.turnOn ();
	}

	void inactivateClickCube()
	{
		clicktolink.turnOff ();
		destroyallCube.turnOff ();
		destroyrowsCube.turnOff ();
		destroycolorCube.turnOff ();
		punishCube.turnOff ();
		slowdownCube.turnOff ();
	}

	public void restart()
	{
		audioManager.getInstance ().playStart ();
		init ();
		pauseLayer.SetActive (false);
		gameoverLayer.SetActive (false);
	}

	public void home()
	{
		SceneManager.LoadScene ("start");
		audioManager.getInstance ().playExit ();
	}

	public void slowDown()
	{
		basicCube.slowDown ();
		cubeSpawner.GetComponent<spawnCube> ().slowDown ();
		Invoke ("recover",5.0f);
	}

	public void recover()
	{
		basicCube.recoverVelocity ();
		cubeSpawner.GetComponent<spawnCube> ().recoverSpeed ();
	}

	public void destroyAll()
	{
		for (int i = 0; i < cubepool.transform.childCount; i++) {
			basicCube cube = cubepool.transform.GetChild (i).GetComponent<basicCube> ();
			if(cube.indexY<7)
				cube.destroy ();
		}
//		for (int i = 0; i < 7; i++)
//			for (int j = 0; j < 10; j++)
//				if (map [i] [j])
//					map [i] [j].GetComponent<basicCube>().destroy ();
				
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
//		for (int i = 0; i < 7; i++)
//			for (int j = 0; j < 10; j++)
//				if (map [i] [j]&&map[i][j].tag == color)
//					map [i] [j].GetComponent<basicCube>().destroy ();

		for (int i = 0; i < cubepool.transform.childCount; i++) {
			basicCube cube = cubepool.transform.GetChild (i).GetComponent<basicCube> ();
			if (cube.indexY < 7 && cube.gameObject.tag == color) 
				cube.destroy ();
		}
	}

	public void click(GameObject cube)
	{
		clicks.Add (cube);
		for (int i = 0; i < clicks.Count; i++)
			if (!clicks[i])
				clicks.RemoveAt (i);
		if (clicks.Count >= 2)
			Link ();
	}

	public void Link()
	{
		GameObject start = clicks [0];
		int startX = start.GetComponent<basicCube> ().indexX;
		int startY = start.GetComponent<basicCube> ().indexY;

		GameObject end = clicks [1];
		int endX = end.GetComponent<basicCube> ().indexX;
		int endY = end.GetComponent<basicCube> ().indexY;

		if (start.tag != end.tag) {
			start.GetComponent<clicktolink> ().unselect ();
			clicks.RemoveAt (0);
			return;
		}

		List<int []> starts = new List<int[]>();
		List<int[]> ends = new List<int[]> ();
		starts.Add (new int[2]{startX,startY});
		ends.Add (new int[2]{endX,endY});

		for (int i = startY+1; i < 15&&!map [startX] [i]; i++) 
			starts.Add (new int[2] {startX, i});		
		if(startY == 0)
			starts.Add (new int[2] {startX, -1});

		for (int i = startX + 1; i <= 7 && (i==7||!map [i] [startY]); i++)
			starts.Add (new int[2] {i,startY});
		for (int i = startX - 1; i >= -1 && (i==-1||!map [i] [startY]); i--)
			starts.Add (new int[2] {i,startY});

		for (int i = endY+1; i < 15&&!map [endX] [i]; i++) 
			ends.Add (new int[2] {endX, i});		
		if(endY == 0)
			ends.Add (new int[2] {endX, -1});

		for (int i = endX + 1; i <= 7 && (i==7||!map [i] [endY]); i++)
			ends.Add (new int[2] {i,endY});
		for (int i = endX - 1; i >= -1 && (i==-1||!map [i] [endY]); i--)
			ends.Add (new int[2] {i,endY});
			
		bool found = false;
		int s = 0, e = 0;
		for(int i=0;i<starts.Count&&!found;i++)
			for (int j = 0; j < ends.Count&&!found; j++) {
				if (starts [i] [0] == ends [j] [0]) {
					found = true;
					int min = starts [i] [1] < ends [j] [1] ? starts [i] [1] : ends [j] [1];
					int max = starts [i] [1] >= ends [j] [1] ? starts [i] [1] : ends [j] [1];
					for (int k = min+1; k < max; k++)
						if (starts [i] [0]>=0&&starts [i] [0]<=6&&k>=0&&k<=14&&map [starts [i] [0]] [k]) {
							found = false;
							break;
						}
						
					if (found) {
						s = i;
						e = j;
						break;
					}
				}
				else if (starts [i] [1] == ends [j] [1]) {
					found = true;
					int min = starts [i] [0] < ends [j] [0] ? starts [i] [0] : ends [j] [0];
					int max = starts [i] [0] >= ends [j] [0] ? starts [i] [0] : ends [j] [0];
					for (int k = min+1; k < max; k++)
						if (starts[i][1]>=0&&starts[i][1]<=14&&k>=0&&k<=6&&map [k] [starts [i] [1]]) {
							found = false;
							break;
						}
					
					if (found) {
						s = i;
						e = j;
						break;
					}
				}
			}


		if (found) {
			print ("found");
			GameObject _line = Instantiate(line);
			_line.GetComponent<LineRenderer> (). SetPosition (0,new Vector3((startX-3)*1.2f,0.625f + (startY-6)*1.25f,-1));
			_line.GetComponent<LineRenderer> ().SetPosition (1,new Vector3((starts[s][0]-3)*1.2f,0.625f +  (starts[s][1]-6)*1.25f,-1));
			_line.GetComponent<LineRenderer> ().SetPosition (2,new Vector3((ends[e][0]-3)*1.2f,0.625f + (ends[e][1]-6)*1.25f,-1));
			_line.GetComponent<LineRenderer> (). SetPosition (3,new Vector3((endX-3)*1.2f,0.625f + (endY-6)*1.25f,-1));

			start.GetComponent<clicktolink> ().unselect ();
			end.GetComponent<clicktolink> ().unselect ();
			start.GetComponent<basicCube> ().destroy ();
			end.GetComponent<basicCube> ().destroy ();
			audioManager.getInstance ().playDestroy ();
			clicks.RemoveAt (1);
			clicks.RemoveAt (0);
		} else {
			print ("no way");
			audioManager.getInstance ().playWarn ();
			start.GetComponent<clicktolink> ().unselect ();
			clicks.RemoveAt (0);
		}
	}
}
