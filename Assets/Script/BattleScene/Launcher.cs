using System;
using System.Collections.Generic;
using UnityEngine;
class Launcher : Weapon
{
    override public void Fire(GameObject obj, Vector3 point, GameObject target)
    {
        if (!cd.ColdDownFinished())
        {
            return;
        }
        foreach (GameObject muzz in muzzle)
        {
            GameObject m = Instantiate(bullet, muzz.transform.position, muzz.transform.rotation);
            m.GetComponent<Missile>().Initial(target, GetComponentInParent<is_en_tag>().is_enemy);
        }
        cd.StartColdDown();
    }
    new void Update()
    {
        base.Update();
    }
}
