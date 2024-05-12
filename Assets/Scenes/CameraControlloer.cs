using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera mainCamera;
    public float zoomSpeed = 3.0f;
    public float limit;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if (distance != 0)
        {
            mainCamera.fieldOfView += distance;
            if (mainCamera.fieldOfView > 100)
                mainCamera.fieldOfView = 100;
            if (mainCamera.fieldOfView < 5)
                mainCamera.fieldOfView = 5;
        }
    }
}
