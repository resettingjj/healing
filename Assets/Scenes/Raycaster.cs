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
        lineRenderer.positionCount = 2; // 레이의 시작점과 끝점
        lineRenderer.startWidth = 0.01f; // 시작 두께
        lineRenderer.endWidth = 0.01f;   // 끝 두께

    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = cam.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        RaycastHit hit;

        // 라인 렌더러를 사용하여 레이 그리기
        //lineRenderer.SetPosition(0, ray.origin);
        //lineRenderer.SetPosition(1, ray.origin + ray.direction * 10.0f);

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.transform.CompareTag("Damaged"))
            {
                statusText.text = hit.transform.GetComponent<Wound>().pain + " 아픔\n통증 : ";
                Canvas.SetActive(true);
            }
            else
                Canvas.SetActive(false);
        }
    }
}
