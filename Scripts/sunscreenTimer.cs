using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sunscreenTimer : MonoBehaviour {
	public GameObject sunscreenActiveTimer;
	public GameObject temp_bar;
	public GameObject water_bar;
	float elapsedTime;
	float sec;
	bool start;
	float lifeTime;

	void Start () {
		sunscreenActiveTimer = GameObject.FindGameObjectWithTag("sunscreen_timer");
		temp_bar = GameObject.FindGameObjectWithTag ("temp_bar");
		water_bar = GameObject.FindGameObjectWithTag ("water_bar");
		start = false;
		scale (0.0f);
	}

	// Update is called once per frame
	void Update () {
		if (start) {
			if (elapsedTime >= lifeTime) { //done
				temp_bar.SendMessage("RegularTempIncrease"); //regulare increase
				water_bar.SendMessage("RegularDehydration"); //regular
				sec = 0.0f;
				start = false;
				scale (0.0f);
			} else if (elapsedTime >= sec) {
				sec++;
				sunscreenActiveTimer.GetComponent<Text>().text = (lifeTime-sec).ToString(); 
			}
			elapsedTime += Time.deltaTime;
		}
	}

	void StartTimer(float time){
		lifeTime = time;
		scale (1.0f); //make visible
		sunscreenActiveTimer.GetComponent<Text>().text = lifeTime.ToString();
		sec = 0.0f;
		start = true;
		elapsedTime = 0.0f;
		temp_bar.SendMessage ("SlowTempIncrease", 0.25f); //slow down
		water_bar.SendMessage("SlowDehydration", 0.25f); //slow down
	}
	void scale(float sc){ //make canvas visible/invisible
		transform.localScale = new Vector3 (sc, sc, sc);
		sunscreenActiveTimer.transform.localScale = new Vector3 (sc, sc, sc); 
	}
}
