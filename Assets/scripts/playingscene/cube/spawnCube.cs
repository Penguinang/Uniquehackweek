using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCube : MonoBehaviour {
	public Transform cubeSpawnPosition;
	public GameObject[] cubes;
	public GameObject gameController;
	List<List<GameObject>> map;

	int[] top;

	float timer = 0;
	void Start () {
		map = new List<List<GameObject>> ();
		for(int i = 0;i<7;i++)
			map.Add (new List<GameObject> (new GameObject[15]));
		top = new int[7];
		gameController.GetComponent<gameController> ().map = map;
		gameController.GetComponent<gameController> ().top = top;
	}

	void Update () {
		for (int i = 0; i < 7; i++) {
			if (top[i]>9)
				stop ();
		}
	}

	void FixedUpdate()
	{
		timer += 0.02f;
		if (timer >= 1) {
			timer = 0;
			int index = Random.Range (0, cubes.Length);
			int xPos = Random.Range (0, 7);
			GameObject cube = Instantiate (cubes [index],new Vector3(1.2f*(xPos-3),cubeSpawnPosition.position.y,cubeSpawnPosition.position.z),cubeSpawnPosition.rotation);
			cube.GetComponent<basicCube>().map = map;
			cube.GetComponent<basicCube>().top = top;
			cube.GetComponent<basicCube> ().indexX = xPos;
			cube.GetComponent<basicCube>().indexY = 14;
		}
	}

	void stop()
	{
		enabled = false;
	}
}
