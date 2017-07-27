using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMenu : MonoBehaviour {

	public GameObject NMenu;



	// Use this for initialization
	void Start()
	{
		
		gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
			{
				gameObject.GetComponentInParent<MenuMove>().Out();

				NMenu.GetComponent<MenuMove>().In();
			});
	}

	// Update is called once per frame  
	void Update()
	{
	}


}
