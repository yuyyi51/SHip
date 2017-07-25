using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class is_en_tag : MonoBehaviour {

	public bool is_enemy;

	public enum kind : int
	{
		ship,
		shell,
		missile,
		plane,
	}

	public kind tag_kind;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
