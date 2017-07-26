using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{


    private bool is_pause;

    // Use this for initialization
    void Start()
    {
        is_pause = false;
    }

    void Pause()
    {
		
         Time.timeScale = 0;
        is_pause = true;
    }

    void Go()
    {
        Time.timeScale = 1;
        is_pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !is_pause)
        {
            Pause();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && is_pause)
        {
            Go();
        }

    }
}
