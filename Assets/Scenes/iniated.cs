using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iniated : MonoBehaviour
{
    public GameObject wound;
    private GameObject pain;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            float angle = Random.Range(0f, 360f);
            // ���õ� ������ ���� ��ġ ���
            Vector3 targetPosition = Quaternion.Euler(0, angle, 0) * Vector3.forward * Random.Range(3f, 5f);

            pain = Instantiate(wound, targetPosition, Quaternion.identity);
            pain.name = "wound"+ i;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
