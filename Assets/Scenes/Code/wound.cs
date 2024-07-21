using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Wound : MonoBehaviour
{
    public string[] sick;
    public string pain;
    public string paintype;
    public Collider Collider1;
    private GameManager manager;
    public bool health;
    public Dictionary<string, float> status = new Dictionary<string, float>();
    private int randomPaintype;
    // Start is called before the first frame update

    
    
    void Awake()
    {
        manager = GameObject.Find("manager").GetComponent<GameManager>();
        if (!manager.isbokje)
        {
                randomPaintype = Random.Range(0, 4);
                paintype = new List<string>(new string[] {"상처", "화상", "골절", "근육파열"})[randomPaintype];
                transform.GetChild(randomPaintype).gameObject.SetActive(true);
                status.Add("통증", Random.Range(1,10));
                status.Add("감염", Random.Range(-5, 23)/7);
                status.Add("약화", Random.Range(-2, 18)/3);
                status.Add("경직", Random.Range(-1, 10)/2);
                Collider1.enabled = true;
        }
        
    }
    public void heal()
        {
            paintype = "치료됨";
            transform.GetChild(randomPaintype).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(true);
        }
}

