using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeDsty : MonoBehaviour {

	public float timeTodsty;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, timeTodsty);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
