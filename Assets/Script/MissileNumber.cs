using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileNumber : MonoBehaviour {
    public UnityEngine.UI.Text text;
	// Use this for initialization
	void Start ()
    {
        text.text = "";
    }
	
	// Update is called once per frame
	void Update ()
    {
        text.text = Missile.number.ToString();
	}
}
