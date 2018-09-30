using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningToggle : MonoBehaviour {
	public bool isVisible;
	public bool blinkOn;
	float blinkInterval;
	float timer;

	// Use this for initialization
	void Start () {
		blinkOn = false;
		Disable();
		blinkInterval = 0.6f;
		timer = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		if (isVisible) {
			if (timer >= blinkInterval) {
				timer = 0;
				if (blinkOn) {
					transform.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
				} else {
					transform.localScale = new Vector3 (0.7f, 0.7f, 0.7f);
				}
				blinkOn = !blinkOn; //invert
			}
				timer += Time.deltaTime;
		}
	}
	public void Activate(){
		if (!isVisible) { //activate
			isVisible = true;
			transform.localScale = new Vector3 (0.7f, 0.7f, 0.7f);
		}
	}
	public void Disable(){
		isVisible = false;
		transform.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
	}
}