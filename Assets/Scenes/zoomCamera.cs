using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    public Camera camera;
    private RayFromOneCameraToAnother plane;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camera.ScreenToWorldPoint(plane.second_camera_trandform);
    }
}
