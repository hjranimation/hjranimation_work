using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioController : MonoBehaviour {
	//public AudioSource explosion;
	public List<AudioSource> allAudio;

	public enum AudioType
		{
		explosion = 0,
		fire = 1,
		enemy_laser = 2,
		enemy_hit = 3,
		power_up = 4, 
		health = 5
		}
	public static AudioController instance = null;

	void Awake ()
	{
		//Check if there is already an instance of SoundManager
		if (instance == null)
			//if not, set it to this.
			instance = this;
		//If instance already exists:
		else if (instance != this)
			//Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
			Destroy (gameObject);

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);
	}


	public void PlaySound(AudioType type)
	{
		allAudio [(int)type].Play ();
		}
}
