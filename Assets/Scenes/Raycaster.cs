using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Raycaster : MonoBehaviour

{
    // Start is called before the first frame update
    public TextMeshProUGUI statusText;
    public GameObject Canvas;
    public Camera cam;
    public LineRenderer lineRenderer;
    void Start()
    {
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        lineRenderer.positionCount = 2; // ������ �������� ����
        lineRenderer.startWidth = 0.01f; // ���� �β�
        lineRenderer.endWidth = 0.01f;   // �� �β�

    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = cam.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        RaycastHit hit;

        // ���� �������� ����Ͽ� ���� �׸���
        //lineRenderer.SetPosition(0, ray.origin);
        //lineRenderer.SetPosition(1, ray.origin + ray.direction * 10.0f);

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.transform.CompareTag("Damaged"))
            {
                statusText.text = hit.transform.GetComponent<Wound>().pain + " ����\n���� : ";
                Canvas.SetActive(true);
            }
            else
                Canvas.SetActive(false);
        }
    }
}
