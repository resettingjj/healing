using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class wound : MonoBehaviour
{
    public float[] y;
    public int i;
    public GameObject parentObject;
    public string[] sick;
    public List<string> pain;
    public GameObject childObject;
    public Collider Collider1;
    // Start is called before the first frame update
    void Awake()
    {
        i = Random.Range(0, y.Length / 2 - 1);
        pain.Add(sick[i]);
        transform.position =new Vector3(transform.position.x, Random.Range(y[i*2], y[i*2+1]), transform.position.z);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(0, transform.position.y, 0) - transform.position, out hit, 20f))
        {
            transform.position = hit.point;
            transform.parent = parentObject.transform;
        }else
        {
            Destroy(this);
        }
        Collider1.enabled = true;
    }

     void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        // Raycast를 통해 마우스 위치에서 화면을 향해 광선을 쏘고, 충돌한 객체가 있는지 확인
        if (Physics.Raycast(ray, out hit))
        {
            // 충돌한 객체의 이름 출력
            if (!childObject.activeSelf&& hit.collider.gameObject.name=="wound")
                childObject.SetActive(true);
            // 여기서 추가적인 작업 수행 가능
        }else
        {
            if(childObject.activeSelf)
                childObject.SetActive(false);
        }


    }
}

