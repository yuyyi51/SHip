using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDbar1 : MonoBehaviour
{
    public Slider CD1UI;
    // Use this for initialization
    void Start ()
    {
        CD1UI.value = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        CD1UI.value = 1f - fire.instance.time1 / fire.instance.cd1;
	}
}
