using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(Input.mousePosition.x + 35, Input.mousePosition.y+40, Input.mousePosition.z);
    }
}