using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyListener : MonoBehaviour {
	public GameObject jasper;
	public GameObject sunscreen_active;
	// Use this for initialization
	void Start () {
		jasper = GameObject.FindGameObjectWithTag("Jasper");
		sunscreen_active = GameObject.FindGameObjectWithTag ("sunscreen_active");
	}
	
	// Update is called once per frame
	void Update () {
		WaterListener ();
		SunscreenListener ();
		ExitListener ();
	}

	void WaterListener(){ //M = use water
		if(Input.GetKeyDown(KeyCode.M)){
			jasper.SendMessage ("DrinkWater"); //canvas update
		}
	}
	void SunscreenListener(){ //N = use sunscreen
		if(Input.GetKeyDown(KeyCode.N)){
			jasper.SendMessage ("UseSunscreen"); //canvas update
		}
	}
	void ExitListener(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			jasper.SendMessage ("GameOver", false);
		}
	}
}
