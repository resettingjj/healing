using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setRotate : MonoBehaviour
{
    public float x;
    public float minRange;
    public float maxRange;
    // Start is called before the first frame update
    public void settingRotate()
    {
        transform.localEulerAngles   = new Vector3(x,0, Random.Range(minRange, maxRange));
    }
}
