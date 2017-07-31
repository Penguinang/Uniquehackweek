using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour {

	public GameObject settingLayer;
	public GameObject helpLayer;
	public GameObject beginLayer;
	int helpIndex = 0;
	public GameObject[] helps;

	void Start () {
		
	}

	void Update () {
		bool back = Input.GetKeyDown (KeyCode.Escape);

		if (back) {
			if (settingLayer.activeSelf)
				setting ();
			else if (helpLayer.activeSelf)
				help ();
			else 
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
//		if (helpLayer.activeSelf) {
//			helpLayer.SetActive (false);
//			beginLayer.SetActive (true);
//		} else {
//			settingLayer.SetActive (false);
//			beginLayer.SetActive (false);
//			helpLayer.SetActive (true);
//		}
//
//		helpLayer.SetActive (true);
//		settingLayer.SetActive (false);
//		titleLayer.SetActive (false);

		helpLayer.SetActive (!helpLayer.activeSelf);
		helpIndex = 0;
		showHelp ();
	}
	public void right()
	{
		helpIndex++;
		if (helpIndex > 2)
			helpIndex = 2;
		showHelp ();
	}
	public void left()
	{
		helpIndex--;
		if (helpIndex < 0)
			helpIndex = 0;
		showHelp ();
	}
	void showHelp()
	{
		for (int i = 0; i < 3; i++)
			helps [i].SetActive (false);
		helps [helpIndex].SetActive (true);
	}

	public void setting()
	{
//		if (settingLayer.activeSelf) {
//			settingLayer.SetActive (false);
//			beginLayer.SetActive (true);
//		} else {
//			helpLayer.SetActive (false);
//			beginLayer.SetActive (false);
//			settingLayer.SetActive (true);
//		}
		settingLayer.SetActive(!settingLayer.activeSelf);
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
