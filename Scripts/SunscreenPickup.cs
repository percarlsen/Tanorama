using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunscreenPickup : MonoBehaviour {
	public Vector3 rotation;
	public GameObject Jasper;
	private float topStop;
	private float bottomStop;
	private float moveSpeed;
	private bool up;

	void Start () {
		rotation = new Vector3(0,2,0);
		Jasper = GameObject.FindGameObjectWithTag("Jasper");
		bottomStop = transform.position.y; //start pos
		topStop = transform.position.y + 0.5f;
		moveSpeed = 0.008f;
		up = true; //start going up
	}

	// Update is called once per frame
	void Update () {
		move ();
	}
	void OnTriggerEnter(Collider other){
		Jasper.SendMessage("ApplySunscreenPickup", gameObject);
	}
	void move(){
		transform.Rotate (rotation);
		if(transform.position.y >= topStop){
			up = false; //go down
		}else if(transform.position.y <= bottomStop){
			up = true; // go up
		}
		if (up) {
			transform.Translate (0, moveSpeed, 0);
		} else {
			transform.Translate (0, -moveSpeed, 0);
		}

	}
}
	
