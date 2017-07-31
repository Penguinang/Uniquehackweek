using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCube : MonoBehaviour {
	public Transform cubeSpawnPosition;
	public GameObject[] cubes;
	public GameObject gameController;
	public GameObject cubepool;
	List<List<GameObject>> map;
	float _internal = 0.3f;
	public float lowInternal = 0.9f;
	public float commonInternal = 0.3f;

	public int common = 10;
	public int slow = 6;
	public int color = 3;
	public int rows = 2;
	public int all = 1;
	public int punish = 2;

	int[] top;

	float timer = 0;
	void Start () {
//		map = new List<List<GameObject>> ();
//		for(int i = 0;i<7;i++)
//			map.Add (new List<GameObject> (new GameObject[15]));
//		top = new int[7];
//		init();
//		gameController.GetComponent<gameController> ().map = map;
//		gameController.GetComponent<gameController> ().top = top;

//		_internal = commonInternal;
	}

	void Update () {
		for (int i = 0; i < 7; i++) {
			if (top[i]>8)
				stop ();
		}
	}

	void FixedUpdate()
	{		
		timer += 0.01f;
		if (timer >= _internal) {
			timer = 0;
			int sum = common * 5 + slow + color * 5 + rows * 4 + all + punish;
			int[] rights = new int[]{ 
				common,common,common,common,common,
				slow,
				color,color,color,color,color,
				rows,rows,rows,rows,
				all,
				punish
			};

			int random = Random.Range (1, sum+1);
			int index = 0;
			int right = 0;
			for (int i = 0; i < 17; i ++) {
				right += rights [i];
				if (right >= random) {
					index = i;
					break;
				}
			}

			int xPos = Random.Range (0, 7);
			GameObject cube = Instantiate (cubes [index],new Vector3(1.25f*(xPos-3),cubeSpawnPosition.position.y,cubeSpawnPosition.position.z),cubeSpawnPosition.rotation);
			cube.transform.parent = cubepool.transform;
			cube.GetComponent<basicCube>().map = map;
			cube.GetComponent<basicCube>().top = top;
			cube.GetComponent<basicCube> ().indexX = xPos;
			cube.GetComponent<basicCube>().indexY = 9;
		}
	}

	public void init()
	{
		enabled = true;
		if (map!=null)
			for (int i = 0; i < 7; i++)
				for (int j = 0; j < 15; j++) {
					map [i] [j] = null;
				}
		else {
			map = new List<List<GameObject>> ();
			for(int i = 0;i<7;i++)
				map.Add (new List<GameObject> (new GameObject[15]));
		}
		
		if(top!=null)
			for (int i = 0; i < 7; i++)
				top [i] = 0;
		else
			top = new int[7];
		
		gameController.GetComponent<gameController> ().map = map;
		gameController.GetComponent<gameController> ().top = top;

		_internal = commonInternal;
	}
	public void stop()
	{
		enabled = false;
	}
	public void pause()
	{
		enabled = false;
	}
	public void recover()
	{
		enabled = true;
	}

	public void slowDown()
	{
		_internal = lowInternal;
	}
	public void recoverSpeed()
	{
		_internal = commonInternal;
	}
}
