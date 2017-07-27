using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torpedoPlane : Plane
{
    public GameObject launcher;
    public GameObject torpedo;
    public float cd = 5f;
    public float timer = 0;

    void Start()
    {
        range = 20;
    }

    protected override void Control()
    {
        //leftclick to launch a torpado
        if (Vector3.Distance(transform.position, target.transform.position) < range && timer == 0)
        {
            torpedo.GetComponent<is_en_tag>().is_enemy = GetComponentInParent<is_en_tag>().is_enemy;
            Instantiate(torpedo, launcher.transform.position, launcher.transform.rotation);
            timer = cd;
        }
    }
    void LateUpdate()
    {
        Move();
        if (!damaged) Control();
        if (timer > Time.deltaTime) timer -= Time.deltaTime;
        else timer = 0;
    }
}