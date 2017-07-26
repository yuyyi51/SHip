using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    public GameObject explode;
    public float health;
    //移动
    [SerializeField]
    private float speed;
    [SerializeField]
    private float turningSpeed;         //当前转向速度
    public float accel;                 //加速度
    public float astern;                //后退加速度
    public float maxSpeed;              //最大速度
    public float maxAstSpeed;           //最大后退速度
    public float turningAcc;            //转向加速度
    private bool stopped;               //是否停止
    //武器
    public GameObject[] weaponSet;

    public float Speed
    {
        get { return speed; }
    }

    void Fire(int id, Vector3 point, GameObject target)
    {
        weaponSet[id].GetComponent<Weapon>().Fire(gameObject, point, target);
    }

    void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.Rotate(0, 0, Time.deltaTime * turningSpeed);
    }

    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log ("triggered");
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
                BattleController.instance.DeleteFromObjects(gameObject);
                Destroy(gameObject);
            }
        }
    }
}