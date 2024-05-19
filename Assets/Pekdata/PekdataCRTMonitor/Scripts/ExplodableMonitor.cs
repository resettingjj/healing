using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodableMonitor : MonoBehaviour
{
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //mainCamera = GetComponent<Camera>();
    }
    void Update()
    {
        transform.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z-8.5f);
    }
}
