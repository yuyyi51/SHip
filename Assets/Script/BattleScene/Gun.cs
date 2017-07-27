using System;
using System.Collections.Generic;
using UnityEngine;
class Gun : Weapon
{
    override public void Fire(GameObject obj, Vector3 point, GameObject target)
    {
        if (!cd.ColdDownFinished())
        {
            return;
        }
        Vector3 v1 = point - transform.position;
        foreach (GameObject muzz in muzzle)
        {
            Vector3 v2 = muzz.transform.position - transform.position;
            Vector3 tar = v1 - v2;
            tar.z = 0;
            float range = tar.magnitude;
            GameObject bull = Instantiate(bullet, muzz.transform.position, muzz.transform.rotation);
            bull.GetComponent<is_en_tag>().is_enemy = GetComponentInParent<is_en_tag>().is_enemy;
            bull.GetComponent<Shell>().range = range;
            bull.GetComponent<Shell>().shipSpeed = obj.GetComponent<Ship>().Speed;
            bull.GetComponent<Shell>().shipToward = obj.transform.up;
        }
        cd.StartColdDown();
    }
    new void Update()
    {
        base.Update();
    }
}
