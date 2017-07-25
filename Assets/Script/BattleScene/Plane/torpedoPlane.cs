using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torpedoPlane : Plane
{
    public GameObject launcher;
    public GameObject torpedo;
    public float cd = 5f;
    public float timer = 0;
    protected override void Control()
    {
        //leftclick to launch a torpado
        if (Input.GetKeyUp(KeyCode.Mouse0) && timer == 0)
        {
            torpedo.GetComponent<is_en_tag>().is_enemy = GetComponentInParent<is_en_tag>().is_enemy;
            Instantiate(torpedo, launcher.transform.position, launcher.transform.rotation);
            timer = cd;
        }
    }
    void Update()
    {
        Move();
        Control();
        if (timer > Time.deltaTime) timer -= Time.deltaTime;
        else timer = 0;
    }
}