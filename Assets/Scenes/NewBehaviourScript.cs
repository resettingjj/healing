using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int percentage;
    // Start is called before the first frame update
    void Start()
    {
        if (percentage >= Random.Range(0,100))
            transform.GetChild(Random.Range(0, transform.childCount)).gameObject.SetActive(true);
    }
}
