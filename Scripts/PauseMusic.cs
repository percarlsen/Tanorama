using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMusic : MonoBehaviour {
	public AudioSource gameOverSound;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void StopMusic(){
		gameOverSound.Pause ();
	}
}
