using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {

    public static fire instance;

	public GameObject blast;
	public GameObject muzzle;
    public float cd1 = 0.1f;
    public float time1;

    public GameObject missile;
    public GameObject launcher;
    public float cd2 = 0.2f;
    public float time2;

    // Use this for initialization
    void Start () {
        instance = this;
        time1 = 0;
        time2 = 0;
	}

	// Update is called once per frame
	void Update () {
        if (time1 > Time.deltaTime)
        {
            time1 -= Time.deltaTime;
        }
        else
        {
            time1 = 0;
        }
        if (time2 > Time.deltaTime)
        {
            time2 -= Time.deltaTime;
        }
        else
        {
            time2 = 0;
        }
        if (Input.GetKey(KeyCode.Mouse0) && time1 == 0)
        {
            blast.GetComponent<is_en_tag>().is_enemy = GetComponentInParent<is_en_tag>().is_enemy;
            Instantiate (blast, muzzle.transform.position , muzzle.transform.rotation);
            time1 = cd1;
		}

        if(Input.GetKey(KeyCode.Mouse1) && time2 == 0)
        {
            missile.GetComponent<is_en_tag>().is_enemy = GetComponentInParent<is_en_tag>().is_enemy;
            Instantiate(missile, launcher.transform.position, launcher.transform.rotation);
            time2 = cd2;
        }

    }
}
