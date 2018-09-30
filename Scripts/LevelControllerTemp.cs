using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelControllerTemp : MonoBehaviour {
	float elapsedTime;
	float decreaseInterval; //in sec
	float nextDecrease;
	float decreaseAmountPercent; //in percent of full bar
	float increaseAmountPercent;
	float increaseAmountOrg;
	bool inSun;
	GameObject jasper;


	public Image bar_img;
	float orgSize;
	GameObject warning_temp;

	void Start () {
		decreaseInterval = 0.3f;
		nextDecrease = 0.0f;
		elapsedTime = 0.0f;
		decreaseAmountPercent = 0.8f;
		increaseAmountPercent = 1.7f;
		increaseAmountOrg = increaseAmountPercent;
		orgSize = bar_img.rectTransform.rect.height;
		inSun = false;
		bar_img.rectTransform.sizeDelta = new Vector2(bar_img.rectTransform.rect.width, 0.0f);
		jasper = GameObject.FindGameObjectWithTag ("Jasper");
		warning_temp = GameObject.FindGameObjectWithTag ("warning_temp");
	}

	// Update is called once per frame
	void Update () {
		if (elapsedTime >= nextDecrease) {
			nextDecrease += decreaseInterval;
			if (bar_img.rectTransform.rect.height >= orgSize) { //full bar
				jasper.SendMessage ("GameOver", true);
			} else if (inSun == true) { //increase bar
				if(bar_img.rectTransform.rect.height >= 0.8*orgSize){ //level high
					warning_temp.SendMessage("Activate");
				}
				bar_img.rectTransform.sizeDelta = new Vector2 (bar_img.rectTransform.rect.width, bar_img.rectTransform.rect.height + (orgSize * increaseAmountPercent / 100.0f));
			} else if(bar_img.rectTransform.rect.height >= 0.0f){ //in shadow, decrease bar
				if(bar_img.rectTransform.rect.height < 0.8*orgSize){ //not high anymore
					warning_temp.SendMessage("Disable");
				}
				bar_img.rectTransform.sizeDelta = new Vector2 (bar_img.rectTransform.rect.width, bar_img.rectTransform.rect.height - (orgSize * decreaseAmountPercent / 100.0f));
			}
		}

		elapsedTime += Time.deltaTime;
	}
	void FillUp(){
		bar_img.rectTransform.sizeDelta = new Vector2(bar_img.rectTransform.rect.width, orgSize);
	}
	void HeatDecreasedWithWater(){
		float tmp;
		if (bar_img.rectTransform.rect.height - orgSize * 0.3f < 0.0f) { //make sure bar does not get negative val
			tmp = 0.0f;
		} else {
			tmp = bar_img.rectTransform.rect.height - orgSize * 0.3f;
		}
		bar_img.rectTransform.sizeDelta = new Vector2 (bar_img.rectTransform.rect.width, tmp);
	}
	void SetInSun(){
		inSun = true;
	}
	void SetInShadow(){
		inSun = false;
	}
	void SlowTempIncrease(float speed){
		increaseAmountPercent = speed;
	}
	void RegularTempIncrease(){
		increaseAmountPercent = increaseAmountOrg;
	}
}
