using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour {

	public static bool music = true;
	public static bool sound = true;
	public AudioSource audioSource;

	void Start () {
		DontDestroyOnLoad (gameObject);
		audioSource = GetComponent<AudioSource> ();
	}
		
	void Update () {
		
	}

	public void switchMusic()
	{
		music = !music;
		if (music)
			play ();
		else
			pause ();
		print ("switch music");
	}
	public void switchSound()
	{
		sound = !sound;
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


}
