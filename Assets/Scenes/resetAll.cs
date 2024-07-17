using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetAll : MonoBehaviour
{
    public GameObject manager;
    // Update is called once per frame
    public void reset()
    {
        manager.SetActive(false);
    }
}
