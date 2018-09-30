using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class raycast : MonoBehaviour {
	
	public GameObject jasper;
	public bool insun;
	public GameObject temp_bar;


	// Use this for initialization
	void Start () {
		jasper = GameObject.FindGameObjectWithTag ("Jasper");
		temp_bar = GameObject.FindGameObjectWithTag ("temp_bar");
		insun = true;
	}

	// Update is called once per frame
	void Update () {
		RayCast ();
	}

	public void RayCast(){
		Vector3.Distance (jasper.transform.position, this.transform.position);
		var rayDirection = jasper.transform.position - transform.position;

			
		Debug.DrawRay (transform.position, rayDirection, Color.green); //for debug only
		RaycastHit hit;

		if (Physics.Raycast (transform.position, rayDirection, out hit, float.MaxValue)) {
			if (hit.transform.tag == "Jasper") { //jasper in sun
				jasper.SendMessage ("SetInSun"); //notify jasper
				temp_bar.SendMessage("SetInSun"); //update canvas 
				insun = true;
			} else if (hit.transform.tag == "Cloud") { //jasper in shadow
				jasper.SendMessage ("SetInShadow"); //notify jasper
				temp_bar.SendMessage ("SetInShadow"); //update canvas
				insun = false;
			}	
		}
	}
}
