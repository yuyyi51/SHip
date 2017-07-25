using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{

    public static fire instance;

    public GameObject blast;

    public GameObject[] muzz;




    public float cd1 = 0.1f;
    //public float time1;
    public CDTime[] cd;

    public GameObject missile;
    public GameObject launcher;
    public float radii = 3f;
    public float cd2 = 0.2f;
    //public float time2;

    // Use this for initialization
    void Start()
    {
        instance = this;
        cd = new CDTime[2];
        cd[0] = new CDTime(cd1);
        cd[1] = new CDTime(cd2);
    }

    // Update is called once per frame
    void Update()
    {
        if (!cd[0].ColdDownFinished())
            cd[0].ColdDown(Time.deltaTime);
        if (!cd[1].ColdDownFinished())
            cd[1].ColdDown(Time.deltaTime);



        if (Input.GetKey(KeyCode.Mouse0) && cd[0].ColdDownFinished())
        {
            blast.GetComponent<is_en_tag>().is_enemy = GetComponentInParent<is_en_tag>().is_enemy;
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 v1 = mouse - transform.position;
            foreach (GameObject muzzle in muzz)
            {
                Vector3 v2 = muzzle.transform.position - transform.position;
                Vector3 tar = v1 - v2;
                tar.z = 0;
                float range = tar.magnitude;

                GameObject bullet = Instantiate(blast, muzzle.transform.position, muzzle.transform.rotation);
                bullet.GetComponent<Shell>().range = range;
                ShipMove s = GetComponentInParent<ShipMove>();
                //Debug.Log(s);
                bullet.GetComponent<Shell>().shipSpeed = s.Speed;
                bullet.GetComponent<Shell>().shipToward = s.gameObject.transform.up;
                Debug.Log(bullet.GetComponent<Shell>().shipSpeed);
                Debug.Log(bullet.GetComponent<Shell>().shipToward);

            }
            cd[0].StartColdDown();
        }


        if (Input.GetKey(KeyCode.Mouse1) && cd[1].ColdDownFinished())
        {
            missile.GetComponent<is_en_tag>().is_enemy = GetComponentInParent<is_en_tag>().is_enemy;
            GameObject m = Instantiate(missile, launcher.transform.position, launcher.transform.rotation);
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0;
            GameObject target = BattleController.instance.FindClosestEnemy(mouse, radii, GetComponentInParent<is_en_tag>().is_enemy);
            Debug.Log(target);
            m.GetComponent<Missile>().target = target;
            cd[1].StartColdDown();
        }

    }
}
