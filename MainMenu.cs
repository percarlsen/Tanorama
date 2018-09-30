using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ExitListener ();
	}

	public void OnClickPlay(){
		SceneManager.LoadScene ("Tanorama");
	}
	public void OnClickControls(){
		SceneManager.LoadScene ("Controls");
	}
	public void OnClickTutorial(){
		SceneManager.LoadScene ("Tutorial");
	}
	public void OnClickAbout(){
		SceneManager.LoadScene ("About");
	}
	public void OnClickQuit(){
#if UNITY_EDITOR
		if(EditorApplication.isPlaying) EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
	void ExitListener(){
		if(Input.GetKeyDown(KeyCode.Escape)){
#if UNITY_EDITOR
		if(EditorApplication.isPlaying) EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
		}
	}
}
