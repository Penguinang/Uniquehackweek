using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour {

	public GameObject settingLayer;
	public GameObject helpLayer;
	public GameObject beginLayer;

	void Start () {
		
	}

	void Update () {
		bool back = Input.GetKeyDown (KeyCode.Escape);

		if (back) {
			if (settingLayer.activeSelf||helpLayer.activeSelf)
				begin ();
			else if (beginLayer.activeSelf)
				exit ();				
		}
	}

	public void beginGame()
	{
		SceneManager.LoadScene ("play");
		basicCube.init ();
	}

	public void help()
	{
		if (helpLayer.activeSelf) {
			helpLayer.SetActive (false);
			beginLayer.SetActive (true);
		} else {
			settingLayer.SetActive (false);
			beginLayer.SetActive (false);
			helpLayer.SetActive (true);
		}
//
//		helpLayer.SetActive (true);
//		settingLayer.SetActive (false);
//		titleLayer.SetActive (false);
	}

	public void setting()
	{
		if (settingLayer.activeSelf) {
			settingLayer.SetActive (false);
			beginLayer.SetActive (true);
		} else {
			helpLayer.SetActive (false);
			beginLayer.SetActive (false);
			settingLayer.SetActive (true);
		}
	}

	public void begin()
	{
		helpLayer.SetActive (false);
		settingLayer.SetActive (false);
		beginLayer.SetActive (true);
	}

	public void exit()
	{
		Application.Quit ();
	}
}
