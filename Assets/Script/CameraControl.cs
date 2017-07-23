using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 direction = ShipMove.instance.transform.position - transform.position;
        direction.z = 0f;
        transform.Translate(direction);
	}
}
