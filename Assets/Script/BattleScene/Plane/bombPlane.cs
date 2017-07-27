using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombPlane : Plane
{
    public GameObject launcher;
    public GameObject boom;
    public float cd = 10f;
    float timer = 0;
    bool bombing = false;
    public float delay = 2f;
    float delaytimer;

    void Start()
    {
        delaytimer = delay;
        range = 5;
    }

    protected override void Control()
    {
        
        if (Vector3.Distance(transform.position, target.transform.position) < range && timer == 0)
        {
            boom.GetComponent<is_en_tag>().is_enemy = GetComponentInParent<is_en_tag>().is_enemy;
            Instantiate(boom, launcher.transform.position+Vector3.forward, launcher.transform.rotation);
            bombing = true;
            timer = cd;
        }
    }
    void LateUpdate()
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
            if (!damaged) Control();
        }
        if (timer > Time.deltaTime) timer -= Time.deltaTime;
        else timer = 0;
    }
}
