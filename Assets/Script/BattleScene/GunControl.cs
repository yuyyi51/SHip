using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public float speed;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        target.z = 0f;
        target.Normalize();
        float euler = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg - 90f;
        Quaternion TargetRotation = Quaternion.Euler(0, 0, euler);
        Quaternion re = Quaternion.Slerp(transform.rotation, TargetRotation, Time.deltaTime * speed);
        transform.rotation = re;
    }
}
