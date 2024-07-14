using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Botton : MonoBehaviour
{
    public GameObject Magnify;
    public GameObject cloth;
    public bool click1;
    public bool click2;

    private void Start()
    {
        click1 = false;
        click2 = false;
    }

    public void OnClickButton1()
    {
        if (!click1)
        {
            click1 = true;
            Magnify.SetActive(false);
        }
        if (click1) 
        {
            click1 = false;
            Magnify.SetActive(true);
        }
    }
    public void OnClickButton2()
    {
        if (!click2)
        {
            click2 = true;
            Magnify.SetActive(true);
        }
        if (click2)
        {
            click2 = false;
            Magnify.SetActive(false);
        }
    }
    public void OnClickButton3()
    {

    }
}
