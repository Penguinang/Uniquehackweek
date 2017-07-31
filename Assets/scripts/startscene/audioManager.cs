using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour {

	static bool music = true;
	static bool sound = true;
	public AudioSource audioSource;
	public GameObject soundIcon;
	public GameObject musicIcon;

	void Start () {
		DontDestroyOnLoad (gameObject);
		audioSource = GetComponent<AudioSource> ();
	}
		
	void Update () {
		
	}

	public void switchMusic()
	{
		music = !music;
//		musicIcon.SetActive (!musicIcon.activeSelf);
		if (music)
			play ();
		else
			pause ();
		print ("switch music");
	}
	public void switchSound()
	{
		sound = !sound;
//		soundIcon.SetActive (!soundIcon.activeSelf);

		print ("switch sound");
	}

	public void pause()
	{
		audioSource.Pause ();
	}
	public void stop()
	{
		audioSource.Stop ();
	}
	public void play()
	{
		audioSource.Play ();
	}

	static public bool getSound()
	{
		return sound;
	}
	static public bool getMusic()
	{
		return music;
	}
}
