using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useItem : MonoBehaviour
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
        transform.position = t.second_camera_start;
        Quaternion rotation = Quaternion.LookRotation(-t.rayDirection);
        transform.rotation = rotation * Quaternion.Euler(new Vector3(90, 90, 90));
    }
}
