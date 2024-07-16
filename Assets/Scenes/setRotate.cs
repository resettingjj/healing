using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setRotate : MonoBehaviour
{
    public float minRange;
    public float maxRange;
    // Start is called before the first frame update
    public void settingRotate()
    {
        transform.rotation = Quaternion.Euler(0,0, Random.Range(minRange, maxRange));
    }
}
