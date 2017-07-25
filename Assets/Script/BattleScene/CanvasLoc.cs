using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLoc : MonoBehaviour
{

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 v1 = transform.TransformDirection(Vector3.up);
        Vector3 v2 = Vector3.up;
        float angle = Vector3.Angle(v1, v2);
        float d = (Vector3.Dot(Vector3.forward, Vector3.Cross(v1, v2)) < 0 ? -1 : 1);
        transform.Rotate(0, 0, d * angle);
    }
}
