﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools
{
    public static void TurnTowards(GameObject obj, Vector3 target, float vel)
    {
        Vector3 dir = target - obj.transform.position;
        dir.z = 0;
        float angle = Vector3.Angle(obj.transform.up, dir);
        float d = (Vector3.Dot(Vector3.forward, Vector3.Cross(obj.transform.up, dir)) < 0 ? -1 : 1);
        if (angle > vel * Time.deltaTime)
            obj.transform.Rotate(0, 0, d * vel * Time.deltaTime);
        else
            obj.transform.Rotate(0, 0, d * angle);
    }
    public static void TurnTowards(GameObject obj, GameObject target, float vel)
    {
        TurnTowards(obj, target.transform.position, vel);
    }
    public static void TurnLeft(GameObject obj, float vel)
    {
        obj.transform.Rotate(0, 0, Time.deltaTime * vel);
    }
    public static void TurnRight(GameObject obj, float vel)
    {
        obj.transform.Rotate(0, 0, -Time.deltaTime * vel);
    }
    public static void TurnTowardsDirectly(GameObject obj, Vector3 target)
    {
        Vector3 dir = target - obj.transform.position;
        float angle = Vector3.Angle(obj.transform.up, dir);
        float d = (Vector3.Dot(Vector3.forward, Vector3.Cross(obj.transform.up, dir)) < 0 ? -1 : 1);
        obj.transform.Rotate(0, 0, d * angle);
    }
    public static void TurnTowardsDirectly(GameObject obj, GameObject target)
    {
        TurnTowardsDirectly(obj, target.transform.position);
    }
    public static void TurnLeftDirectly(GameObject obj, float angle)
    {
        obj.transform.Rotate(0, 0, angle);
    }
    public static void TurnRightDirectly(GameObject obj, float angle)
    {
        obj.transform.Rotate(0, 0, -angle);
    }
}
