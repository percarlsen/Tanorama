using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ListenEsc : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		ExitListener ();
	}
	void ExitListener(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			SceneManager.LoadScene ("Main Menu"); 
		}
	}
}
