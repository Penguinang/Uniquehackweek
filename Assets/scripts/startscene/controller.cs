using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour {

	public GameObject settingLayer;
	public GameObject helpLayer;
	public GameObject titleLayer;

	void Start () {
		
	}

	void Update () {
		bool back = Input.GetKeyDown (KeyCode.Escape);

		if (back) {
			if (settingLayer.activeSelf)
				title ();
			else if (helpLayer.activeSelf)
				title ();
			else if (titleLayer.activeSelf)
				exit ();				
		}
	}

	public void beginGame()
	{
		SceneManager.LoadScene ("play");
	}

	public void help()
	{
		helpLayer.SetActive (true);
		settingLayer.SetActive (false);
		titleLayer.SetActive (false);
	}

	public void setting()
	{
		helpLayer.SetActive (false);
		settingLayer.SetActive (true);
		titleLayer.SetActive (false);
	}

	public void title()
	{
		helpLayer.SetActive (false);
		settingLayer.SetActive (false);
		titleLayer.SetActive (true);
	}

	public void exit()
	{
		Application.Quit ();
	}
}
