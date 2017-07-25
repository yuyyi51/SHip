using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    //单例类

    public static ShipMove instance;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float turningSpeedNow;
    public float accel;          //加速度
    public float astern;        //后退加速度
    public float maxSpeed;        //最大速度
    public float maxAstSpeed;     //最大后退速度
    public float turningSpeed;     //转向速度
    public int framesBeforeLaunch = 5;
    [SerializeField]
    private int framesHeld;
    private bool stopped;
    // Use this for initialization
    void Start()
    {
        instance = this;
        speed = 0;
        turningSpeedNow = 0;
        accel = 0.02f;
        astern = -0.015f;
        maxSpeed = 10f;
        maxAstSpeed = -3f;
        turningSpeed = 60f;
        framesHeld = 0;
        stopped = true;
    }

    //speed  get
    public float Speed
    {
        get { return speed; }
    }

    void Accelerate()
    {
        if ((speed + accel) * speed < 0)
        {
            stopped = true;
            speed = 0f;
        }
        else if (speed + accel <= maxSpeed + 0.01f)
        {
            speed += accel;
        }
    }
    void Astern()
    {
        if ((speed + astern) * speed < 0)
        {
            stopped = true;
            speed = 0f;
        }
        else if (speed + astern >= maxAstSpeed - 0.01f)
        {
            speed += astern;
        }
    }
    void TurnLeft()
    {
        if (turningSpeedNow < turningSpeed)
            turningSpeedNow += turningSpeed;
    }
    void TurnRight()
    {
        if (turningSpeedNow > -turningSpeed)
            turningSpeedNow -= turningSpeed;
    }
    void Control()
    {
        //W
        if (Input.GetKeyDown(KeyCode.W))
        {
            stopped = false;
            framesHeld = 0;
            Accelerate();
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (stopped == true && framesHeld <= framesBeforeLaunch)
            {
                framesHeld++;
            }
            else
            {
                framesHeld = 0;
                stopped = false;
                Accelerate();
            }

        }
        if (Input.GetKeyUp(KeyCode.W))
        {

        }
        //A
        if (Input.GetKeyDown(KeyCode.A))
        {
            TurnLeft();
        }
        if (Input.GetKey(KeyCode.A))
        {
            TurnLeft();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            turningSpeedNow = 0;
        }
        //S
        if (Input.GetKeyDown(KeyCode.S))
        {
            stopped = false;
            framesHeld = 0;
            Astern();
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (stopped == true && framesHeld <= framesBeforeLaunch)
            {
                framesHeld++;
            }
            else
            {
                framesHeld = 0;
                stopped = false;
                Astern();
            }

        }
        if (Input.GetKeyUp(KeyCode.S))
        {

        }
        //D
        if (Input.GetKeyDown(KeyCode.D))
        {
            TurnRight();
        }
        if (Input.GetKey(KeyCode.D))
        {
            TurnRight();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            turningSpeedNow = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Control();
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.Rotate(0, 0, Time.deltaTime * turningSpeedNow);
        //Debug.Log(transform.rotation.eulerAngles);
    }
}
