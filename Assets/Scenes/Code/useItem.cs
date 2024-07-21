using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class useItem : MonoBehaviour
{
    public GameObject plane;
    public GameObject Cam;
    public float StartingItemDistace;
    public Vector3 rotate;
    private RayFromOneCameraToAnother t;
    // Start is called before the first frame update
    void Start()
    {
        t = plane.GetComponent<RayFromOneCameraToAnother>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Cam.transform.position;
        Quaternion rotation = Quaternion.LookRotation(-t.rayDirection);
        transform.Translate(Vector3.down * StartingItemDistace);
        transform.rotation = rotation * Quaternion.Euler(rotate);

    }
}
