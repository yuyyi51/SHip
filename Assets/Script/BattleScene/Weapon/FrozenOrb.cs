using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenOrb : Bullet
{
    private Vector3 direction;

    public Vector3 shipToward;
    public float shipSpeed;

    public GameObject explode;

    public GameObject subBullet;

    private float launchAngle;
    public float deltaAngle;
    public float intervalTime = 0.1f;
    private float time;
    public float bulletNumber;

    new public void Initial(float iniSpeed, Vector3 iniDirection, bool en, float ran = 0, GameObject obj = null)
    {
        shipSpeed = iniSpeed;
        shipToward = iniDirection;
        gameObject.GetComponent<is_en_tag>().is_enemy = en;
        launchAngle = 0;
    }

    public void Initial(float sSpeed, Vector3 sToward, bool en)
    {
        shipSpeed = sSpeed;
        shipToward = sToward;
        gameObject.GetComponent<is_en_tag>().is_enemy = en;
        launchAngle = 0;
    }

    void Fire()
    {
        for (int i = 0; i != bulletNumber; ++i)
        {
            float angle = 360.0f / bulletNumber * i + lunchAngle + gameObject.transform.rotation.eulerAngles.z;
            angle %= 360;
            GameObject bull = Instantiate(subBullet, gameObject.transform.position, Quaternion.Euler(0, 0, angle));
            bull.GetComponent<Shell>().Initial(speed, transform.TransformVector(direction), gameObject.GetComponent<is_en_tag>().is_enemy);
        }
    }

    // Use this for initialization
    void Start()
    {
        Vector3 v1 = transform.up * speed;

        Vector3 shiptoward;
        float shipspeed;

        shiptoward = shipToward;
        shipspeed = shipSpeed;
        shiptoward.Normalize();
        //Debug.Log(shipspeed);
        shiptoward *= shipspeed;
        //Debug.Log(shiptoward);

        direction = v1 + shiptoward;
        speed = direction.magnitude;
        direction = transform.InverseTransformVector(direction);
        direction.Normalize();
        time = intervalTime;
    }

    // Update is called once per frame
    void Update()
    {
        timetodestroy = timetodestroy - Time.deltaTime;
        gameObject.transform.Translate(direction * speed * Time.deltaTime);
        if( time >= intervalTime )
        {
            Fire();
            launchAngle += deltaAngle;
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
        //Debug.Log(transform.position);

        if (timetodestroy < 0)
        {
            //explode.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

            //Instantiate(explode, gameObject.transform.position + Vector3.back, gameObject.transform.rotation);

            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<is_en_tag>().tag_kind == is_en_tag.kind.ship && other.GetComponent<is_en_tag>().is_enemy != gameObject.GetComponent<is_en_tag>().is_enemy)
        {
            //explode.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

            //Instantiate(explode, gameObject.transform.position + Vector3.back, gameObject.transform.rotation);



            Destroy(gameObject);

        }
    }
}
