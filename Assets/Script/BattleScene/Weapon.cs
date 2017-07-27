using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject[] muzzle;
    public float cdTime;
    public CDTime cd;
    public float turningSpeed;

    void Awake()
    {
        cd = new CDTime(cdTime);
    }

    abstract public void Fire(GameObject obj, Vector3 point, GameObject target = null);
    public void TurnTowards(Vector3 target)
    {
        Tools.TurnTowards(gameObject, target, turningSpeed);
    }
    public void TurnLeft()
    {
        Tools.TurnLeft(gameObject, turningSpeed);
    }
    public void TurnRight()
    {
        Tools.TurnRight(gameObject, turningSpeed);
    }
}
