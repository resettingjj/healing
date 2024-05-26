using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inHospital : MonoBehaviour
{
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = Camera.transform;
        transform.localScale = Vector3.one * 10.0f;
        transform.transform.localPosition = new Vector3(-33.2999992f, -4.69999981f, 49.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
