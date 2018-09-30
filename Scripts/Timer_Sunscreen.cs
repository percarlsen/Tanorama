using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_Sunscreen : MonoBehaviour {
	private float lifeTime = 45.0f;
	private float elapsedTime;
	public GameObject bottleWaypoint;

	void Start () {
		elapsedTime = 0.0f;
	}

	void Update () {
		if (elapsedTime >= lifeTime){
			Destroy(this.gameObject);
		}
		elapsedTime += Time.deltaTime;
	}
}