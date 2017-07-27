using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour {

	public Slider SpeedUI;
    public GameObject ship;

	// Use this for initialization
	void Start () { 
		SpeedUI.value = 0.5f;

	}
	
	// Update is called once per frame
	void Update () {
		if (ship.GetComponent<Ship>().Speed >= 0) {
			float percent = 0.5f * ship.GetComponent<Ship>().Speed / ship.GetComponent<Ship>().maxSpeed + 0.5f;

			//Debug.Log (percent);

			SpeedUI.value = percent;

		}

		if (ship.GetComponent<Ship>().Speed < 0) {
			float percent = 0.5f - 0.5f * ship.GetComponent<Ship>().Speed / ship.GetComponent<Ship>().maxAstSpeed ;

			//Debug.Log (percent);

			SpeedUI.value = percent;
		}
	}
}
