using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera mainCamera;
    public float zoomSpeed = 3.0f;
    public float limit;
    public float scrollSpeed = 5f; // 스크롤 속도
    public float minX = -10f;      // X 축 최소값
    public float maxX = 10f;       // X 축 최대값
    public float minZoom = 3.7f;
    public float maxZoom = 8.7f;
    private iniated manager;
    private Vector3 dragOrigin;


    void Start()
    {
        mainCamera = GetComponent<Camera>();
        manager = GameObject.Find("manager").GetComponent<iniated>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.i == 165)
            mainCamera.transform.position = new Vector3(0, 0, 4);
        if (manager.i > 165)
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;

            // 카메라의 현재 위치 가져오기
            Vector3 cameraPosition = mainCamera.transform.position;

            // 카메라의 z축 위치 조정
            cameraPosition.z += scrollInput;

            // z축 위치를 최소 및 최대 값으로 제한
            cameraPosition.z = Mathf.Clamp(cameraPosition.z, minZoom, maxZoom);

            // 조정된 위치를 카메라에 적용
            mainCamera.transform.position = cameraPosition;
            if (Input.GetMouseButtonDown(2))
            {
                // 드래그 시작 위치 저장
                dragOrigin = Input.mousePosition;
            }

            // 마우스 휠 버튼이 클릭된 상태에서만 드래그
            if (Input.GetMouseButton(2))
            {
                float zoomin = mainCamera.transform.position.z;
                // 드래그 방향과 속도 계산
                Vector3 dragDelta = Input.mousePosition - dragOrigin;
                Vector3 move = new Vector3(dragDelta.x, -dragDelta.y, 0) * 0.1f * Time.deltaTime * zoomin / 4;

                // 카메라 위치 업데이트
                transform.Translate(move, Space.World);

                // 카메라 위치 제한
                Vector3 clampedPosition = transform.position;
                float wheel = 1 / (mainCamera.transform.position.z - 2.7f);
                clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX * zoomin, maxX * zoomin);
                clampedPosition.y = Mathf.Clamp(clampedPosition.y, minX * zoomin, maxX * zoomin);
                transform.position = clampedPosition;

                // 드래그 시작 위치 갱신
                dragOrigin = Input.mousePosition;
            }
        }
        
    }


}
