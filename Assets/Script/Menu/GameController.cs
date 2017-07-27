using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
	static public GameController instance;

	public GameObject pause;

    private bool is_pause;

    // Use this for initialization
    void Start()
    {
		//if(instance == null) instance = new GameController;
        is_pause = false;

    }

    public void Pause()
    {
		
        Time.timeScale = 0;
        is_pause = true;
    }

    public void Go()
    {
		
        Time.timeScale = 1;
        is_pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !is_pause)
        {
			pause.GetComponent<MenuMove> ().In ();

            Pause();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && is_pause)
        {
			pause.GetComponent<MenuMove> ().Out ();
            Go();
        }

    }
}
