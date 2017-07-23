using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {


	public float speed;

	public GameObject target;

	// Use this for initialization
	void Start () {
		target = GameObject.Find("Shipbody");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 forwardDIr = target.transform.position - transform.position;

		/*
		Quaternion lookAtRot = Quaternion.LookRotation (forwardDIr);

		Vector3 result = lookAtRot.eulerAngles;

		Debug.Log(result);
		*/
		float euler = Mathf.Atan2(forwardDIr.y, forwardDIr.x) * Mathf.Rad2Deg - 90f;
		Quaternion TargetRotation = Quaternion.Euler(0, 0, euler);
		Quaternion re = Quaternion.Slerp(transform.rotation, TargetRotation, Time.deltaTime * speed);
		transform.rotation = re;

	}
}
