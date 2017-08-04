using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public float damage;
    public float timetodestroy;
    public float speed;
    private Vector3 direction;
    private GameObject obj;

    abstract public void Initial(float iniSpeed, Vector3 iniDirection, bool en, float ran = 0, GameObject obj = null);
}
