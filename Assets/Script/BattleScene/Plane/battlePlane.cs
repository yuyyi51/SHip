using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battlePlane : Plane
{
    public GameObject muzzle;
    public GameObject blast;
    public float cd = 0.2f;
    private float timer = 0;
    protected override void Control()
    {
        //hold leftmouse to blast
        if (Input.GetKey(KeyCode.Mouse0) && timer == 0)
        {
            blast.GetComponent<is_en_tag>().is_enemy = GetComponentInParent<is_en_tag>().is_enemy;
            Instantiate(blast, muzzle.transform.position, muzzle.transform.rotation);
            timer = cd;
        }
    }
    void Update()
    {
        Move();
        Control();
        if (timer > 0) timer -= Time.deltaTime;
        else timer = 0;
    }
}