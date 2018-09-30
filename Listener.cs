using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Listener : MonoBehaviour {
	public GameObject scoreCont;
	int score;
	int bestScore;
	// Use this for initialization
	void Start () {
		score = -1;
		bestScore = 0;
		scoreCont = GameObject.FindGameObjectWithTag ("score_controller");
	}

	// Update is called once per frame
	void Update () {
		score = PlayerPrefs.GetInt ("Score");
		bestScore = PlayerPrefs.GetInt ("BestScore");
		scoreCont.GetComponent<Text>().text = "Your Tan Level: "+score+"\n\nBest Tan Level: "+bestScore; 

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