using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int framesBeforeLaunch = 5;
    [SerializeField]
    private int framesHeld;
    public float radii = 3;                     //for weapons need to lock a target
    void KeyBoardControl(Ship s)
    {
        //W
        if (Input.GetKeyDown(KeyCode.W))
        {
            s.stopped = false;
            framesHeld = 0;
            s.Accelerate();
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (s.stopped == true && framesHeld <= framesBeforeLaunch)
            {
                framesHeld++;
            }
            else
            {
                framesHeld = 0;
                s.stopped = false;
                s.Accelerate();
            }

        }
        //A
        if (Input.GetKeyDown(KeyCode.A))
        {
            s.TurnLeft();
        }
        if (Input.GetKey(KeyCode.A))
        {
            s.TurnLeft();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            s.turningSpeed = 0;
        }
        //S
        if (Input.GetKeyDown(KeyCode.S))
        {
            s.stopped = false;
            framesHeld = 0;
            s.Astern();
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (s.stopped == true && framesHeld <= framesBeforeLaunch)
            {
                framesHeld++;
            }
            else
            {
                framesHeld = 0;
                s.stopped = false;
                s.Astern();
            }

        }
        //D
        if (Input.GetKeyDown(KeyCode.D))
        {
            s.TurnRight();
        }
        if (Input.GetKey(KeyCode.D))
        {
            s.TurnRight();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            s.turningSpeed = 0;
        }
    }
    void MouseControl(Ship s)
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        foreach (GameObject obj in s.weaponSet)
        {
            obj.GetComponent<Weapon>().TurnTowards(mouse);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            s.Fire(0, mouse);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            GameObject obj = BattleController.instance.FindClosestEnemy(mouse, radii, gameObject.GetComponent<is_en_tag>().is_enemy);
            s.Fire(1, mouse, obj);
        }
    }
    void Control()
    {
        Ship s = gameObject.GetComponent<Ship>();
        KeyBoardControl(s);
        MouseControl(s);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Control();
    }
}
