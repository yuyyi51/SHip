using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour {

	public Slider SpeedUI;


	// Use this for initialization
	void Start () { 
		SpeedUI.value = 0.5f;

	}
	
	// Update is called once per frame
	void Update () {
		if (ShipMove.instance.Speed >= 0) {
			float percent = 0.5f * ShipMove.instance.Speed / ShipMove.instance.maxSpeed + 0.5f;

			//Debug.Log (percent);

			SpeedUI.value = percent;

		}

		if (ShipMove.instance.Speed < 0) {
			float percent = 0.5f - 0.5f * ShipMove.instance.Speed / ShipMove.instance.maxAstSpeed ;

			//Debug.Log (percent);

			SpeedUI.value = percent;
		}
	}
}
