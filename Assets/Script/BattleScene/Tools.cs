using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools
{
    public static void TurnTowards(GameObject obj, Vector3 target, float vel)
    {
        Vector3 dir = target - obj.transform.position;
        float angle = Vector3.Angle(obj.transform.up, dir);
        float d = (Vector3.Dot(Vector3.forward, Vector3.Cross(obj.transform.up, dir)) < 0 ? -1 : 1);
        obj.transform.Rotate(0, 0, d * vel * Time.deltaTime);
    }
	public static void TurnTowards(GameObject obj, GameObject target, float vel)
    {
        TurnTowards(obj, target.transform.position, vel);
    }
}
