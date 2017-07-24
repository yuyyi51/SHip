using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLoc : MonoBehaviour {

	private float turningSpeed;

	private float turningSpeedNow;


	// Use this for initialization
	void Start () {
		turningSpeed = GetComponentInParent<ShipMove> ().turningSpeed;
	}


	void TurnLeft()
	{
		if(turningSpeedNow < turningSpeed)
			turningSpeedNow += turningSpeed;
	}
	void TurnRight()
	{
		if(turningSpeedNow > -turningSpeed)
			turningSpeedNow -= turningSpeed;
	}

	void Control()
	{
		
		//D
		if (Input.GetKeyDown(KeyCode.D))
		{
			TurnLeft();
		}
		if (Input.GetKey(KeyCode.D))
		{
			TurnLeft();
		}
		if (Input.GetKeyUp(KeyCode.D))
		{
			turningSpeedNow = 0;
		}

		//A
		if (Input.GetKeyDown(KeyCode.A))
		{
			TurnRight();
		}
		if (Input.GetKey(KeyCode.A))
		{
			TurnRight();
		}
		if (Input.GetKeyUp(KeyCode.A))
		{
			turningSpeedNow = 0;
		}
	}



		


	// Update is called once per frame
	void Update () {

		/*
		gameObject.transform.LookAt (Vector3.up);

		Quaternion re = gameObject.transform.localRotation;

		re.y = 0f;

		gameObject.transform.localRotation = re;
		*/

		Control();

		transform.Rotate(0, 0, Time.deltaTime * turningSpeedNow);

		//Debug.Log (gameObject.transform.localRotation );


	}
}
