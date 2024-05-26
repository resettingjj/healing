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
    // Start is called before the first frame update

    
    
    void Awake()
    {
        i = Random.Range(0, y.Length / 2 - 1);
        pain=sick[i];
        transform.position =new Vector3(transform.position.x, Random.Range(y[i*2], y[i*2+1]), transform.position.z);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(0, transform.position.y, 0) - transform.position, out hit, 20f))
        {
            transform.position = hit.point + hit.normal * 0.01f;
            transform.parent = hit.collider.gameObject.transform;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }else
        {
            gameObject.SetActive(false);
        }
        Collider1.enabled = true;
    }
    
}

