using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HpUI : MonoBehaviour
{




    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Slider>().maxValue = gameObject.transform.parent.transform.parent.GetComponent<Ship>().health;
        gameObject.GetComponent<Slider>().value = gameObject.transform.parent.transform.parent.GetComponent<Ship>().health;
        //Debug.Log (gameObject.GetComponent<Slider> ().value);
    }

    // Update is called once per frame
    void Update()
    {




        //Debug.Log (gameObject.GetComponent<Slider> ().value);
        gameObject.GetComponent<Slider>().value = gameObject.transform.parent.transform.parent.GetComponent<Ship>().health;
    }
}
