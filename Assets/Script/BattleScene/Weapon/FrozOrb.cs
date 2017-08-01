using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozOrb : Weapon {

    // Use this for initialization
    override public void Fire(GameObject obj, Vector3 point, GameObject target)
    {
        if (!cd.ColdDownFinished())
        {
            return;
        }
        foreach (GameObject muzz in muzzle)
        {
            GameObject bull = Instantiate(bullet, muzz.transform.position, muzz.transform.rotation);
            bull.GetComponent<FrozenOrb>().Initial(obj.GetComponent<Ship>().Speed, obj.transform.up, GetComponentInParent<is_en_tag>().is_enemy);
        }
        cd.StartColdDown();
    }

    // Update is called once per frame
    new void Update ()
    {
        base.Update();
	}
}
