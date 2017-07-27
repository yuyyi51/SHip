using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plane : MonoBehaviour
{
    public float maxhealth = 10;
    float health;
    public GameObject explode;
    protected GameObject target = null;
    protected GameObject moveTarget = null;
    protected GameObject motherShip;
    protected bool damaged;

    protected float sight = 50;
    protected float range;

    float speed;
    public float maxspeed = 6f;
    public float acc = .02f;
    public float dacc = .005f;
    float turning;
    public float maxturning = 30f;
    public float tacc = 1f;
    public float dtacc = 1f;

    // Use this for initialization
    protected void Awake()
    {
        health = maxhealth;
        damaged = false;

        speed = 0;
        turning = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<is_en_tag>().is_enemy != gameObject.GetComponent<is_en_tag>().is_enemy)
        {
            float damage = 0;

            if (other.GetComponent<Missile>() != null)
                damage = other.GetComponent<Missile>().damage;
            if (other.GetComponent<Shell>() != null)
                damage = other.GetComponent<Shell>().damage;
            health -= damage;

            if (health <= 0)
            {
                explode.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                Instantiate(explode, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    protected void setMotherShip(GameObject m)
    {
        motherShip = m;
    }

    protected void PosTrans(bool w,bool s,bool a,bool d)
    {
        //accelerate
        if (w)
        {
            if (speed < maxspeed) { speed += acc; }
            else { speed = maxspeed; }
        }
        else
        {
            if (speed > 0) { speed -= dacc; }
            else { speed = 0; }
        }

        //force decelerating
        if (s)
        {
            if (speed > acc) { speed -= acc; }
            else { speed = 0; }
        }

        //turn left
        if (a)
        {
            if (turning < maxturning) { turning += tacc; }
            else { turning = maxturning; }
        }
        else turning = 0;
        /*       else if(!Input.GetKeyDown(KeyCode.LeftArrow))
               {
                   if (turning > 0) turning -= dacc;
                   else turning = 0;
               }*/

        //turn right
        if (d)
        {
            if (turning > -maxturning) { turning -= tacc; }
            else { turning = -maxturning; }
        }
        else turning = 0;
        /*       else if(!Input.GetKeyDown(KeyCode.LeftArrow))
               {
                   if (turning < 0) turning += dacc;
                   else turning = 0;
               }*/

        transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.Rotate(0, 0, turning * Time.deltaTime);
    }

    protected void Move()
    {
        bool w, s, a, d;
        w = s = a = d = false;
        if (damaged || !target)
            moveTarget = motherShip;
        else
            moveTarget = target;
        Vector3 tarVec = moveTarget.transform.position - transform.position;
        Vector3 faceVec = transform.up;
        tarVec.z = faceVec.z = 0;
        float vertical = Vector3.Dot(tarVec, faceVec);
        float horizenal = Vector3.Cross(tarVec, faceVec).z;
        if (vertical > 0) w = true;
        if (horizenal > 0) a = true;
        if (horizenal < 0) d = true;
        PosTrans(w, s, a, d);
    }

    protected abstract void Control();

    protected void Update()
    {
        if (health < maxhealth * .2) damaged = true;
        target = BattleController.instance.FindClosestEnemy(transform.position, sight, GetComponent<is_en_tag>().is_enemy);
    }
}