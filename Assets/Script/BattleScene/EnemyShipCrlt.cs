using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipCrlt : MonoBehaviour {

	private float[] range;

	public float safeDis;

	public float turnSpd;			//转向速度
	public float accel;          	//加速度
	public float astern;        	//后退加速度
	public float maxSpeed;        	//最大速度
	public float maxAstSpeed;  		//最大后退速度

	public float spd;

	// Use this for initialization
	void Start () {
		/*
		foreach (float r in range) {
			r = GetComponentInChildren<EnemyGun> ().Range;
		}

		int ind = 0;

		GameObject[] canon;

		gameObject.GetComponentsInChildren<EnemyGun>().CopyTo(canon,ind) ;

		foreach(canon ) {
			
		}
		*/

	}


	
	// Update is called once per frame
	void Update () {

		GameObject en = BattleController.instance.FindClosestEnemy (gameObject.transform.position, 10000f, !gameObject.GetComponent<is_en_tag> ().is_enemy);//10000f代指正无穷

		if ((en.transform.position - gameObject.transform.position).magnitude > range [0]) { // 炮的射程按照从远到近排列

			Tools.TurnTowards (gameObject, en, turnSpd);

			if (spd + accel <= maxSpeed) {
				spd += accel;
			}

			transform.Translate(Vector3.up * spd * Time.deltaTime);



		}

		if ((en.transform.position - gameObject.transform.position).magnitude < safeDis) { 

			if (spd - astern >= maxAstSpeed) {
				spd -= astern;
			}   

			transform.Translate (Vector3.up * spd * Time.deltaTime);
		}
	}
}
