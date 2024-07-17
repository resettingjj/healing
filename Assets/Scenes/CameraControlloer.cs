using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CameraController : MonoBehaviour
{
    public RayFromOneCameraToAnother plane;
    // Start is called before the first frame update
    private Camera mainCamera;
    public float zoomSpeed = 3.0f;
    public float limit;
    public float scrollSpeed = 5f; // ��ũ�� �ӵ�
    public float minX = -10f;      // X �� �ּҰ�
    public float maxX = 10f;       // X �� �ִ밪
    public float minZoom = 3.7f;
    public float maxZoom = 8.7f;
    private iniated manager;
    private Vector3 dragOrigin;
    public GameObject canvas;
    public GameObject tutorial;
    public TextMeshProUGUI woundstat;
    public TextMeshProUGUI resultheal;
    public TextMeshProUGUI resultmoney;
    private float startpainsum;
    public int resultMoney;



    void Start()
    {
        mainCamera = GetComponent<Camera>();
        manager = GameObject.Find("manager").GetComponent<iniated>();
    }
    public void finishCamera()
    {
        mainCamera.transform.position = new Vector3(0, 0, -10);
        canvas.SetActive(true);
        woundstat.text = "\n 상처 치료 : ("+ manager.completeWound + "/" + manager.pain.Count + ")\n치명적인 상처 : ("+ manager.sumCheck + "/3)\n상처 감염도 : " + Mathf.FloorToInt(manager.infectionSum) + "\n\n 통증 완화 : (" + Mathf.FloorToInt(manager.painSum) + "/" + startpainsum +")\n스트레스 수치 : (" + Mathf.FloorToInt(manager.stress) + "/100)";
        resultheal.text = "\n";
        resultMoney = 0;
        evaluation(manager.completeWound/manager.pain.Count);
        evaluation(manager.sumCheck/3);
        if (manager.infectionSum >= 9)
        {
            resultheal.text += "worst\n";
            resultMoney += -50;
        }else if(manager.infectionSum >= 7)
        {
            resultheal.text += "bad\n";
            resultMoney += -20;
        }else if(manager.infectionSum >= 5)
        {
            resultheal.text += "soso\n";
            resultMoney += 5;
        }else if(manager.infectionSum >= 3)
        {
            resultheal.text += "good\n";
            resultMoney += 5;
        }
        else if(manager.infectionSum >= 1)
        {
            resultheal.text += "nice\n";
            resultMoney += 30;
        }else{
            resultheal.text += "perpect\n";
            resultMoney += 30;
        }
        resultheal.text += "\n";
        evaluation((startpainsum-manager.painSum)/startpainsum);
        evaluation((manager.stress)/100);
        resultmoney.text = "정산 금액 : " + resultMoney+"$";
        plane.money += resultMoney;
    }
    void evaluation(float ratio)
    {
        if (ratio == 1)
        {
            resultheal.text += "perpect\n";
            resultMoney += 50;
        }else if(ratio == 0){
            resultheal.text += "worst\n";
            resultMoney += -50;
        }else if(ratio <= 0.25){
            resultheal.text += "bad\n";
            resultMoney += -20;
        }else if(ratio <= 0.5){
            resultheal.text += "soso\n";
            resultMoney += 5;
        }else if(ratio <= 0.75){
            resultheal.text += "nice\n";
            resultMoney += 20;
        }else{
            resultheal.text += "nice\n";
            resultMoney += 30;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (manager.i == 1001)
        {
            manager.getWoundValue();
            startpainsum = manager.painSum;
            canvas.SetActive(false);
            tutorial.SetActive(false);
            mainCamera.transform.position = new Vector3(0, 0, 2);
        }

        if (manager.i > 1000)
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;

            // ī�޶��� ���� ��ġ ��������
            Vector3 cameraPosition = mainCamera.transform.position;

            // ī�޶��� z�� ��ġ ����
            cameraPosition.z += scrollInput;

            // z�� ��ġ�� �ּ� �� �ִ� ������ ����
            cameraPosition.z = Mathf.Clamp(cameraPosition.z, minZoom, maxZoom);

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
                float zoomin = mainCamera.transform.position.z;
                // �巡�� ����� �ӵ� ���
                Vector3 dragDelta = Input.mousePosition - dragOrigin;
                Vector3 move = new Vector3(dragDelta.x, -dragDelta.y, 0) * 0.1f * Time.deltaTime * zoomin / 4;

                // ī�޶� ��ġ ������Ʈ
                transform.Translate(move, Space.World);

                // ī�޶� ��ġ ����
                Vector3 clampedPosition = transform.position;
                float wheel = 1 / (mainCamera.transform.position.z - 2.7f);
                clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX * zoomin, maxX * zoomin);
                clampedPosition.y = Mathf.Clamp(clampedPosition.y, minX * zoomin, maxX * zoomin);
                transform.position = clampedPosition;

                // �巡�� ���� ��ġ ����
                dragOrigin = Input.mousePosition;
            }
        }
        
    }


}
