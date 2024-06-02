using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iniated : MonoBehaviour
{
    public GameObject wound;
    public GameObject player;
    public int status;
    private GameObject pain;
    public bool isbokje = false;
    public int i;
    // Start is called before the first frame update
    void Awake()
    {
        status = 0;
        for (int i = 0; i < 10; i++)
        {
            float angle = Random.Range(0f, 360f);
            // 선택된 각도에 따른 위치 계산
            Vector3 targetPosition = Quaternion.Euler(0, angle, 0) * Vector3.forward * Random.Range(3f, 5f);

            pain = Instantiate(wound, targetPosition, Quaternion.identity);
            pain.name = "wound"+ i;
        }
        
    }
    private void Start()
    {
        isbokje = true;
        status = 1;
        Instantiate(player, Vector3.zero, Quaternion.identity);
    }
    private void Update()
    {
        i += 1;
    }
}
