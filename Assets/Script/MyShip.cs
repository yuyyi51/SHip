using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShip : MonoBehaviour {

	public GameObject explode;

	public float health;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log ("triggered");

		if (other.GetComponent<is_en_tag>().is_enemy != gameObject.GetComponent<is_en_tag>().is_enemy) {


			float damage = 0;

			if (other.GetComponent<Missile> () != null)
				damage = other.GetComponent<Missile> ().damage;
			if (other.GetComponent<Shell> () != null)
				damage = other.GetComponent<Shell> ().damage;


			health -= damage;

			if (health <= 0) {

				explode.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f); 


				Destroy (gameObject);

				Instantiate (explode, gameObject.transform.position, gameObject.transform.rotation);
			}


		}


	}
}
