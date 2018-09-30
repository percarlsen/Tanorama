using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour {
	public GameObject scoreCont;
	int score;
	// Use this for initialization
	void Start () {
		score = -1;
		scoreCont = GameObject.FindGameObjectWithTag ("score_controller");
	}
	
	// Update is called once per frame
	void Update () {
		score = PlayerPrefs.GetInt ("Score");
		scoreCont.GetComponent<Text>().text = "Score: "+score; 
		ExitListener ();
	}

	void ExitListener(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			SceneManager.LoadScene ("Main Menu");
		}
	}
}
