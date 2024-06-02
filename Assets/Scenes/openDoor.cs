using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    private iniated manager;
    Quaternion rotate;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("manager").GetComponent<iniated>();
        rotate = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (300 > manager.i && manager.i > 150)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0,180,0)), 2f * Time.deltaTime);
        if (manager.i > 300)
            transform.rotation = Quaternion.Lerp(transform.rotation, rotate, 2f * Time.deltaTime);
    }
}
