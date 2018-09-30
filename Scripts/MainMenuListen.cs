using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuListen : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	public void GoToMainMenu(){
		print ("PROVER A GA TIL MAINMENU");
		SceneManager.LoadScene ("Main Menu");
	}
}