using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Cloud1Nav : MonoBehaviour {
	public GameObject [] destinations;
	int nextPos;
	// Use this for initialization
	void Start () {
		nextPos = Random.Range (0, destinations.Length);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Vector3.Distance(transform.position, destinations[nextPos].transform.position) <= 2.0f) { //dest reached
			int newDest = nextPos;
			while (newDest == nextPos){
				newDest = Random.Range(0, destinations.Length);
			}
			nextPos = newDest;
		}
		transform.position = Vector3.MoveTowards(transform.position, destinations[nextPos].transform.position, 0.035f);
	}
}

