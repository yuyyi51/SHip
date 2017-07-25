using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{


    public float fireRate;

    private float reload;

    public GameObject blast;
    public GameObject muzzle;

    // Use this for initialization
    void Start()
    {
        reload = 0;
    }

    // Update is called once per frame
    void Update()
    {
        reload += Time.deltaTime;

        if (reload >= fireRate)
        {

            blast.GetComponent<is_en_tag>().is_enemy = GetComponentInParent<is_en_tag>().is_enemy;

            GameObject bullet = Instantiate(blast, muzzle.transform.position, muzzle.transform.rotation);
            bullet.GetComponent<Shell>().range = 10;
            EnemyShipCrlt s = GetComponentInParent<EnemyShipCrlt>();
            bullet.GetComponent<Shell>().shipSpeed = s.getSpeed();
            bullet.GetComponent<Shell>().shipToward = s.gameObject.transform.up;

            reload = 0;
        }

    }
}
