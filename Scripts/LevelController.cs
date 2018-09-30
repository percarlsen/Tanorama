using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {
	float elapsedTime;
	float decreaseInterval; //in sec
	float nextDecrease;
	float decreaseAmountPercent; //in percent of full bar
	float orgDecreaseAmount;
	GameObject jasper;
	GameObject warning_drink;


	public Image bar;
	float orgSize;


	void Start () {
		elapsedTime = 0.0f;
		decreaseInterval = 0.3f;
		decreaseAmountPercent = 1.3f; //1.5
		orgDecreaseAmount = decreaseAmountPercent;
		orgSize = bar.rectTransform.rect.height;
		jasper = GameObject.FindGameObjectWithTag ("Jasper");
		warning_drink = GameObject.FindGameObjectWithTag ("warning_drink");
	}

	// Update is called once per frame
	void Update () {
		if (elapsedTime >= nextDecrease) {
			nextDecrease += decreaseInterval;
			if (bar.rectTransform.rect.height-(orgSize*decreaseAmountPercent/100.0f) <= 0.0f) { //empty bar
				jasper.SendMessage ("GameOver", true);

			} else { //decrease bar
				bar.rectTransform.sizeDelta = new Vector2(bar.rectTransform.rect.width, bar.rectTransform.rect.height-(orgSize*decreaseAmountPercent/100.0f));
				if(bar.rectTransform.rect.height <= 0.3*orgSize){ //level low
					warning_drink.SendMessage("Activate");
				}
			}
			if(bar.rectTransform.rect.height >= 0.3*orgSize){ //level high
				warning_drink.SendMessage("Disable");
			}
		}

		elapsedTime += Time.deltaTime;
	}
	void FillUp(){
		bar.rectTransform.sizeDelta = new Vector2(bar.rectTransform.rect.width, orgSize);
	}
	void SlowDehydration(float speed){
		decreaseAmountPercent = speed;
	}
	void RegularDehydration(){
		decreaseAmountPercent = orgDecreaseAmount;
	}
}
