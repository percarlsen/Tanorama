using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour {
	int playing;
	public AudioSource gameOverSound;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void StartSound(){
		if (playing == 0) {
			gameOverSound.Play ();
		}
		playing++;
	}
}
