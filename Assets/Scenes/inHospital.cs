using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class inHospital : MonoBehaviour
{
    public GameObject Camera;
    Animator animator;
    public  float speed;
    public float dragspeed;
    private iniated statusController;
    public int stat;
    // Start is called before the first frame update
    private void Awake()
    {
        statusController = GameObject.Find("manager").GetComponent<iniated>();
        animator = GetComponentInChildren<Animator>();
        stat = statusController.status;
    }
    void Start()
    {
        if (stat == 1)
        {
            transform.parent = Camera.transform;
            Hospital();
        }
    }

    // Update is called once per frame
    void Hospital()
    {
        transform.localScale = Vector3.one * 10.0f;
        transform.transform.localPosition = new Vector3(-43.9f, -6.23f, 100.0f);
        // 자식 오브젝트의 모든 컴포넌트를 비활성화
        animator.Play("walk 0");
    }
    void Update()
    {
        if (stat == 1) 
        {
            transform.Translate(Vector3.forward*speed);
            if (statusController.i == 75)
                transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
            if(statusController.i == 110 && speed != 0)
                transform.rotation = Quaternion.Euler(Vector3.zero);
            if(statusController.i == 160 && speed != 0)
                transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
            if (statusController.i == 165 && speed != 0)
            {
                transform.position = new Vector3(transform.position.x, -1.53f, transform.position.z);
                transform.rotation = Quaternion.Euler(Vector3.zero);
                speed = 0;
                animator.Play("sit down");
            }
                
        }
        if (stat == 0)
        {
            if (Input.GetMouseButton(1))
            {
                transform.Rotate(0f, -Input.GetAxis("Mouse X") * dragspeed*15f, 0f, Space.World);
                transform.Rotate(-Input.GetAxis("Mouse Y") * dragspeed*15f, 0f, 0f);
            }
        }
    }
}
