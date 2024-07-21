using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    private GameManager manager;
    Quaternion rotate;
    private int a;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("manager").GetComponent<GameManager>();
        rotate = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (150 > manager.i && manager.i > 75 && a!=2)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 180, 0)), 2f * Time.deltaTime);
        }
        if (manager.i > 150)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotate, 2f * Time.deltaTime);
            a = 2;
        }
            
    }
}
