using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipCrlt : MonoBehaviour {

	private float[] range;

	public float safeDis;



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

	void move(Vector3 pos){
		
	}
	
	// Update is called once per frame
	void Update () {

		const GameObject en = BattleController.instance.FindClosestEnemy (gameObject.transform.position, 10000f, !gameObject.GetComponent<is_en_tag> ().is_enemy);//10000f代指正无穷

		if ((en.transform.position - gameObject.transform.position).magnitude > range [0]) { // 炮的射程按照从远到近排列

			

		}
	}
}
