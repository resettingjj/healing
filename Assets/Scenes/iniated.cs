using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iniated : MonoBehaviour
{
    public GameObject player;
    public GameObject wound;
    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(player, new Vector3(0,0,0), Quaternion.identity);
        for (int i = 0; i < 10; i++)
        {
            Vector3 targetPosition = new Vector3(Random.Range(2.0f, 4.0f), 0, Random.Range(2.0f, 4.0f));
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
