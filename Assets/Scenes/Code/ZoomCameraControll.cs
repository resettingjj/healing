using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCameraControll : MonoBehaviour
{
    public GameObject plane;
    private RayFromOneCameraToAnother t;
    // Start is called before the first frame update
    void Start()
    {
        t = plane.GetComponent<RayFromOneCameraToAnother>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = t.second_camera_trandform;
        Quaternion rotation = Quaternion.LookRotation(-t.rayDirection);
        transform.rotation = rotation;
    }
}
