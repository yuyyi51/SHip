using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public float damage;
    public float timetodestroy;
    public float speed;
    protected Vector3 direction;
    protected GameObject target;

    abstract public void Initial(float iniSpeed, Vector3 iniDirection, bool en, float ran = 0, GameObject obj = null);
}
