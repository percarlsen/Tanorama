using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningTogglePursuit : MonoBehaviour {
	GameObject d,d1,d2,d3,d4;

	// Use this for initialization
	void Start () {
		d = GameObject.FindGameObjectWithTag ("Douglas");
		d1 = GameObject.FindGameObjectWithTag ("Douglas1");
		d2 = GameObject.FindGameObjectWithTag ("Douglas2");
		d3 = GameObject.FindGameObjectWithTag ("Douglas3");
		d4 = GameObject.FindGameObjectWithTag ("Douglas4");
	}

	// Update is called once per frame
	void Update () {
		if (d.GetComponent<SimpleFSM> ().curState == SimpleFSM.FSMState.Chase ||
		    d1.GetComponent<SimpleFSM> ().curState == SimpleFSM.FSMState.Chase ||
		    d2.GetComponent<SimpleFSM> ().curState == SimpleFSM.FSMState.Chase ||
		    d3.GetComponent<SimpleFSM> ().curState == SimpleFSM.FSMState.Chase ||
		    d4.GetComponent<SimpleFSM> ().curState == SimpleFSM.FSMState.Chase) {
			transform.localScale = new Vector3 (1.2f, 1.2f, 1.2f);
		} else {
			transform.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
		}
	}
		
}
