using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDbar : MonoBehaviour
{
    public Slider CDUI;
    public GameObject ship;
    private Weapon w;
    public int number;
    // Use this for initialization
    void Start()
    {
        CDUI.value = 0;
        w = ship.GetComponent<Ship>().weaponSet[number].GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        CDUI.value = 1f - w.cd.GetPercent();
    }
}
