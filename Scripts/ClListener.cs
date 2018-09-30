using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClListener : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		ExitListener ();
	}
	public void OnClickMainMenu(){
		SceneManager.LoadScene ("Main Menu");
	}
	void ExitListener(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			SceneManager.LoadScene ("Main Menu");
		}
	}
}
