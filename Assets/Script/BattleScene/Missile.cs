using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Bullet
{
    public static int number = 0;
    public float minSpeed = 20;
    public float maxSpeed = 50;
    public float accel = 15;
    public float astern = 5;
    public float turnningSpeed = 180;
    public float minDegree = 30;
    public float beforeAccel = 1;
    private float time;
    public GameObject target;

    public GameObject explode;

    public float showangle;

    new public void Initial(float iniSpeed, Vector3 iniDirection, bool en, float ran = 0, GameObject obj = null)
    {
        target = obj;
        gameObject.GetComponent<is_en_tag>().is_enemy = en;
    }

    public void Initial(GameObject tar, bool en)
    {
        target = tar;
        gameObject.GetComponent<is_en_tag>().is_enemy = en;
    }

    // Use this for initialization
    void Start()
    {
        //target = GameObject.Find("testTarget");
        //speed = minSpeed;
        //speed += ShipMove.instance.Speed;
        time = 0f;
        number++;
    }

    void Move()
    {
        if (time < beforeAccel)
        {
            transform.Translate(speed * Vector3.up * Time.deltaTime);
            return;
        }
        if (target == null)
        {
            speed += accel * Time.deltaTime;
            transform.Translate(speed * Vector3.up * Time.deltaTime);
            return;
        }
        Vector3 dir = target.transform.position - transform.position;
        float angle = Vector3.Angle(transform.up, dir);
        showangle = angle;
        if (angle > minDegree)
        {

            if (speed > minSpeed)
            {
                speed -= astern * Time.deltaTime;
            }
        }
        else
        {
            if (speed < maxSpeed)
            {
                speed += accel * Time.deltaTime;
            }
        }
        float d = (Vector3.Dot(Vector3.forward, Vector3.Cross(transform.up, dir)) < 0 ? -1 : 1);
        transform.Rotate(0, 0, d * turnningSpeed * Time.deltaTime);
        //transform.LookAt(target.transform,Vector3.back);
        transform.Translate(speed * Vector3.up * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        timetodestroy = timetodestroy - Time.deltaTime;
        time += Time.deltaTime;
        Move();

        if (timetodestroy < 0)
        {
            explode.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

            Instantiate(explode, gameObject.transform.position + Vector3.back, gameObject.transform.rotation);
            Destroy(gameObject);
            number--;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<is_en_tag>().tag_kind == is_en_tag.kind.ship && other.GetComponent<is_en_tag>().is_enemy != gameObject.GetComponent<is_en_tag>().is_enemy)
        {

            explode.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

            Instantiate(explode, gameObject.transform.position + Vector3.back, gameObject.transform.rotation);

            Destroy(gameObject);

        }
    }
}
