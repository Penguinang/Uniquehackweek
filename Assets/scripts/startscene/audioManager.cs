using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioManager : MonoBehaviour {
	
	bool _music = true;
	public bool music
	{
		get{ return _music; }
	}
	bool _sound = true;
	public bool sound
	{
		get{ return _sound;}
	}
	public AudioSource audioSourceBGM;
	public AudioSource audioSourceEffect;
	public GameObject soundIcon;
	public GameObject musicIcon;
	static audioManager Instance;

	public AudioClip start;
	public AudioClip exit;
	public AudioClip gameover;
	public AudioClip setting;
	public AudioClip function;
	public AudioClip destroy;
	public AudioClip warning;
	public AudioClip punish;

	void Start () {
		if (!Instance)
			Instance = this;
		else {
			Destroy (gameObject);
			musicIcon.GetComponent<Toggle> ().isOn = getInstance ()._music;
			soundIcon.GetComponent<Toggle> ().isOn = getInstance ()._sound;
			musicIcon.GetComponent<Toggle> ().onValueChanged.AddListener(new UnityEngine.Events.UnityAction<bool>(Instance.switchMusic));
			soundIcon.GetComponent<Toggle> ().onValueChanged.AddListener(new UnityEngine.Events.UnityAction<bool>(Instance.switchSound));
		}
		DontDestroyOnLoad (gameObject);
	}
		
	public static audioManager getInstance()
	{
		return Instance;
	}

	void Update () {
	}

	public void switchMusic(bool a)
	{
		print (a);
		playSetting();
		_music = a;
		if (music)
			play ();
		else
			pause ();
	}
	public void switchSound(bool a)
	{
		_sound = a;
		playSetting();
	}

	public void pause()
	{
		audioSourceBGM.Pause ();
	}
	public void stop()
	{
		audioSourceBGM.Stop ();
	}
	public void play()
	{
		audioSourceBGM.Play ();
	}

	void playEffect(AudioClip clip)
	{
		if (sound) {
			audioSourceEffect.clip = clip;
			audioSourceEffect.Play ();
		}
	}

	public void playStart()
	{
		playEffect(start);
	}
	public void playSetting()
	{
		playEffect(setting);
	}
	public void playExit()
	{
		playEffect(exit);
	}
	public void playGG()
	{
		playEffect (gameover);
	}
	public void playDestroy()
	{
		playEffect(destroy);
	}
	public void playFunction()
	{
		playEffect(function);
	}
	public void playWarn()
	{
		playEffect (warning);
	}
	public void playPunish()
	{
		playEffect (punish);
	}
}
