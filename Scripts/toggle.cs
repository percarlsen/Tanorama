using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggle : MonoBehaviour {
	public bool isVisible;
	// Use this for initialization
	void Start () {
		SetInvisible ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SetVisible(){
		isVisible = true;
		transform.localScale = new Vector3 (0.7f, 0.7f, 0.7f);
	}

	public void SetInvisible(){
		isVisible = false;
		transform.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
	}
}
