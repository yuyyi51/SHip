using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDbar2 : MonoBehaviour {
    public Slider CD2UI;
    // Use this for initialization
    void Start ()
    {
        CD2UI.value = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        CD2UI.value = 1f - fire.instance.time2 / fire.instance.cd2;
    }
}
