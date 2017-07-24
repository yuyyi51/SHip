using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plane : MonoBehaviour {
    public float health;
    public GameObject explode;

    private float speed;
    public float maxspeed;
    public float acc;
    public float dacc;
    private float turning;
    public float maxturning;
    public float tacc;
    public float dtacc;
    
	// Use this for initialization
	protected void Start () {
        speed = 0;
        maxspeed = 6f;
        acc = 0.02f;
        dacc = 0.005f;
        turning = 0;
        maxturning = 30f;
        tacc = 1f;
        dtacc = 1f;
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

    protected void Move()
    {
        //hold W to accelerate
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (speed < maxspeed) { speed += acc; }
            else { speed = maxspeed; }
        }
        else
        {
            if (speed > 0) { speed -= dacc; }
            else { speed = 0; }
        }

        //press S to force decelerating
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (speed > acc) { speed -= acc; }
            else { speed = 0; }
        }

        //press A to turn left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (turning < maxturning) { turning += tacc; }
            else { turning = maxturning; }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) turning = 0;
 /*       else if(!Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (turning > 0) turning -= dacc;
            else turning = 0;
        }*/

        //press D to turn right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (turning > -maxturning) { turning -= tacc; }
            else { turning = -maxturning; }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) turning = 0;
        /*       else if(!Input.GetKeyDown(KeyCode.LeftArrow))
               {
                   if (turning < 0) turning += dacc;
                   else turning = 0;
               }*/

        transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.Rotate(0, 0, turning * Time.deltaTime);
    }

    protected abstract void Control();
	// Update is called once per frame
	void Update () {
        Move();
	}
}