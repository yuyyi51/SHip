﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void In(){
		gameObject.transform.position = new Vector3(0,0,0);
	}

	public void Out(){
		gameObject.transform.position = new Vector3(0,50,0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
