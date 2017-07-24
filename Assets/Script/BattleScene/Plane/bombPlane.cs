using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombPlane : Plane
{
    public GameObject launcher;
    public GameObject bomb;
    public float cd = 10f;
    float timer = 0;
    bool bombing = false;
    public float delay = 2f;
    float delaytimer;
    void Awake()
    {
        delaytimer = delay;
    }
    protected override void Control()
    {
        //leftclick to launch a bomb
        if (Input.GetKeyUp(KeyCode.Mouse0) && timer == 0)
        {
            bomb.GetComponent<is_en_tag>().is_enemy = GetComponentInParent<is_en_tag>().is_enemy;
            Instantiate(bomb, launcher.transform.position, launcher.transform.rotation);
            bombing = true;
            timer = cd;
        }
    }
    void Update()
    {
        if (bombing)
        {
            if (delaytimer > Time.deltaTime) delaytimer -= Time.deltaTime;
            else
            {
                bombing = false;
                delaytimer = delay;
            }
        }
        else
        {
            Move();
            Control();
        }
        if (timer > Time.deltaTime) timer -= Time.deltaTime;
        else timer = 0;
    }
}
