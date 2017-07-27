using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
			{
				Application.Quit();
			});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
