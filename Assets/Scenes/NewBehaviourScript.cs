using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private iniated manager;


    public int percentage;
    // Start is called before the first frame update
    void OnEnable()
    {
        
        manager = GameObject.Find("manager").GetComponent<iniated>();
        if (!manager.isbokje)
        {
            for (int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).gameObject.SetActive(false); // 각 자식 오브젝트 비활성화
            if (percentage >= Random.Range(0, 100))
                transform.GetChild(Random.Range(0, transform.childCount)).gameObject.SetActive(true);
        }
    }
}
