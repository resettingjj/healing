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
    public float[] y;
    public int i;
    public string[] sick;
    public string pain;
    public Collider Collider1;
    private iniated manager;
    // Start is called before the first frame update

    
    
    void Awake()
    {
        manager = GameObject.Find("manager").GetComponent<iniated>();
        if (!manager.isbokje)
        {
            i = Random.Range(0, y.Length / 2 - 1);
            pain = sick[i];
            if (transform.position.z > -0.1 && transform.position.z < 0.04)
            {
                pain = pain + "糠率";
            }
            else
            {
                if (transform.position.z > 0)
                    pain = pain + "菊率";
                else
                    pain = pain + "第率";
            }
            transform.position = new Vector3(transform.position.x, Random.Range(y[i * 2], y[i * 2 + 1]), transform.position.z);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, new Vector3(0, transform.position.y, 0) - transform.position, out hit, 20f))
            {
                transform.position = hit.point + hit.normal * 0.01f;
                transform.parent = hit.collider.gameObject.transform;
                transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            }
            else
            {
                gameObject.SetActive(false);
            }
            Collider1.enabled = true;
            
        }
        
    }
    private void Update()
    {
        if (manager.i == 330)
        {

        }
    }
}

