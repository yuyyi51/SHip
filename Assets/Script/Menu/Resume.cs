using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Resume : MonoBehaviour {

	public GameObject pause;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
			{
				Debug.Log(1);
				pause.GetComponent<MenuMove>().Out();
				pause.GetComponentInParent<GameController>().Go();
			});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
