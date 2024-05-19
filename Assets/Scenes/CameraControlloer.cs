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
    public float scrollSpeed = 5f; // ��ũ�� �ӵ�
    public float minX = -10f;      // X �� �ּҰ�
    public float maxX = 10f;       // X �� �ִ밪
    private Vector3 dragOrigin;


    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;

        // ī�޶��� ���� ��ġ ��������
        Vector3 cameraPosition = mainCamera.transform.position;

        // ī�޶��� z�� ��ġ ����
        cameraPosition.z += scrollInput;

        // z�� ��ġ�� �ּ� �� �ִ� ������ ����
        cameraPosition.z = Mathf.Clamp(cameraPosition.z, 3.7f, 8.7f);

        // ������ ��ġ�� ī�޶� ����
        mainCamera.transform.position = cameraPosition;
        if (Input.GetMouseButtonDown(2))
        {
            // �巡�� ���� ��ġ ����
            dragOrigin = Input.mousePosition;
        }

        // ���콺 �� ��ư�� Ŭ���� ���¿����� �巡��
        if (Input.GetMouseButton(2))
        {
            // �巡�� ����� �ӵ� ���
            Vector3 dragDelta = Input.mousePosition - dragOrigin;
            Vector3 move = new Vector3(dragDelta.x, -dragDelta.y, 0) * 0.1f * Time.deltaTime;

            // ī�޶� ��ġ ������Ʈ
            transform.Translate(move, Space.World);

            // ī�޶� ��ġ ����
            Vector3 clampedPosition = transform.position;
            float wheel = 1/(mainCamera.transform.position.z - 2.7f);
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX/wheel, maxX / wheel);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, minX/2 / wheel, maxX/2 / wheel);
            transform.position = clampedPosition;

            // �巡�� ���� ��ġ ����
            dragOrigin = Input.mousePosition;
        }
    }


}
