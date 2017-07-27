using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battlePlane : Plane
{
    public GameObject launcher;
    public GameObject bullet;
    public float cd = 0.2f;
    private float timer = 0;

    protected override void Control()
    {
        if (timer == 0) 
        {
            bullet.GetComponent<is_en_tag>().is_enemy = GetComponentInParent<is_en_tag>().is_enemy;
            Instantiate(bullet, launcher.transform.position, launcher.transform.rotation);
            timer = cd;
        }
    }
    void LateUpdate()
    {
        Move();
        if (!damaged && target) Control();
        if (timer > 0) timer -= Time.deltaTime;
        else timer = 0;
    }
}