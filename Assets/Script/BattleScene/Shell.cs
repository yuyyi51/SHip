using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : Bullet
{
    public float minRange = 3;
    public float maxRange = 15;
    public float range;
    private Vector3 direction;
    public float maxDispersion;

    public Vector3 shipToward;
    public float shipSpeed;

    public GameObject explode;

    override public void Initial(float iniSpeed, Vector3 iniDirection, bool en, float ran = 7, GameObject obj = null)
    {
        range = ran;
        shipSpeed = iniSpeed;
        shipToward = iniDirection;
        gameObject.GetComponent<is_en_tag>().is_enemy = en;
    }

    public void Initial(float sSpeed, Vector3 sToward, bool en, float ran = 7)
    {
        range = ran;
        shipSpeed = sSpeed;
        shipToward = sToward;
        gameObject.GetComponent<is_en_tag>().is_enemy = en;
    }

    // Use this for initialization
    void Start()
    {
        if (range > maxRange)
            range = maxRange;
        else if (range < minRange)
            range = minRange;
        Vector3 v1 = transform.up * range;

        float dispersion = Random.Range(0f, 1f);
        float angle = Random.Range(0f, 360f);
        dispersion *= maxDispersion;
        Vector3 v2 = new Vector3();
        v2.x = Mathf.Cos(angle);
        v2.y = Mathf.Sin(angle);
        v2.z = 0;
        v2 *= dispersion;
        v1 += v2;
        timetodestroy = v1.magnitude / speed;
        v1.Normalize();
        v1 *= speed;

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
    }

    // Update is called once per frame
    void Update()
    {
        timetodestroy = timetodestroy - Time.deltaTime;
        gameObject.transform.Translate(direction * speed * Time.deltaTime);
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
