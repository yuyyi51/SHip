using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDbar : MonoBehaviour
{
    public Slider CDUI;
    public int number;
    // Use this for initialization
    void Start()
    {
        CDUI.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CDUI.value = 1f - fire.instance.cd[number].GetPercent();
    }
}
