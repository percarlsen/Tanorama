using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunscreenSpawner : MonoBehaviour {
	//public GameObject waterbottle;
	public GameObject [] spawnPoints;
	private float elapsedTime;
	private float nextSpawn;
	private int maxSunscreenOnMap;
	void Start () {
		elapsedTime = 0.0f; //start time
		nextSpawn = 60.0f; //spawn every x seconds
		//waterbottle = GameObject.FindGameObjectWithTag ("Bottle");
		maxSunscreenOnMap = 3;
		spawnNewSunscreen (maxSunscreenOnMap); //spawn x number of bottles when game starts
	}	


	void Update () {
		if (elapsedTime >= nextSpawn){ //create x new bottles
			spawnNewSunscreen((int)Random.Range(1,maxSunscreenOnMap));
			nextSpawn += 60.0f;
		}
		elapsedTime += Time.deltaTime;
	}

	void spawnNewSunscreen(int number){
		int [] spawnPointsTaken = new int[number];
		int rand;
		for(int i = 0; i < number; i++){
			rand = (int)Random.Range (0, 15);
			for(int j = 0; j < i; j++){
				if (spawnPointsTaken [j] == rand) {
					rand = (int)Random.Range (0, 15);
					j=-1;
				}
			}
			//all good, create bottle
			spawnPointsTaken [i] = rand;
			Transform t = spawnPoints[rand].transform;
			//waterbottle = (GameObject)Instantiate (waterbottle, t.position, t.rotation);
			GameObject waterbottle = (GameObject)Instantiate (Resources.Load("Sunscreen"), t.position, t.rotation);
		}
	}
}