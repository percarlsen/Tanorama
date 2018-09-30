using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameOverSound : MonoBehaviour {
	int playing;
	public AudioSource gameOverSound;
	// Use this for initialization
	void Start () {
		playing = 0;
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
