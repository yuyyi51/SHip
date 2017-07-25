using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleController instance;
    private List<GameObject> objects;
    public GameObject enemy;
    public void DeleteFromObjects(GameObject obj)
    {
        objects.Remove(obj);
    }
    public GameObject FindClosestObject(Vector3 center, float radii)
    {
        GameObject result = null;
        float minDis = radii;
        foreach(GameObject obj in objects)
        {
            //Debug.Log(obj.transform.position);
            //Debug.Log(center);
            Vector3 t = obj.transform.position - center;
            t.z = 0;
            if (t.magnitude <= minDis)
            {
                minDis = t.magnitude;
                result = obj;
            }
        }
        return result;
    }
    public GameObject FindClosestEnemy(Vector3 center, float radii, bool isEnemy)
    {
        GameObject result = null;
        float minDis = radii;
        foreach (GameObject obj in objects)
        {
            //Debug.Log(obj.transform.position);
            //Debug.Log(center);
            Vector3 t = obj.transform.position - center;
            t.z = 0;
            if (isEnemy != obj.GetComponent<is_en_tag>().is_enemy && t.magnitude <= minDis)
            {
                minDis = t.magnitude;
                result = obj;
            }
        }
        return result;
    }
    void Awake()
    {
        instance = this;
        objects = new List<GameObject>();
        objects.Add(GameObject.Find("Shipbody"));
        objects.Add(GameObject.Find("testTarget"));
        Debug.Log("!!!");
    }
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Vector3 v = new Vector3();
            v.x = Random.Range(-10, 10);
            v.y = Random.Range(-10, 10);
            v.z = 0;
            Instantiate(enemy, v, new Quaternion());
        }
	}
}
