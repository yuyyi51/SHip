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
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 target = mouse - ShipMove.instance.transform.position;
        target /= 3;
        direction += target;
        direction.z = 0f;
        transform.Translate(direction);
	}
}
