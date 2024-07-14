using Microsoft.Unity.VisualStudio.Editor;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RayFromOneCameraToAnother : MonoBehaviour
{
    public Camera firstCamera; // ù ��° ī�޶�
    public Camera secondCamera; // �� ��° ī�޶�
    public Transform smallPlane;
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI painText;
    public GameObject Canvas;
    public LineRenderer lineRenderer;
    private iniated manager;
    private Component Outline;
    public Vector3 second_camera_trandform;
    public Vector3 second_camera_start;
    public Vector3 rayDirection;
    public int Scroll;
    public List<string> HealTitle;
    public List<string> HealDescription;

    private void Start()
    {
        manager = GameObject.Find("manager").GetComponent<iniated>();
        Outline = GameObject.Find("notebook").transform;
        rayDirection = Vector3.forward;
    }
    void Update()
    {
        Ray firstRay = firstCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(firstRay.origin, firstRay.direction * 15.0f, Color.red);

        // ���� plane�� ���� ��ǥ�� �������� Ray�� ���ϴ�
        if (Physics.Raycast(firstRay, out hit))
        {
            if (hit.transform.CompareTag("Interacter"))
            {
                Outline = hit.transform;
                Outline.GetComponent<Outline>().OutlineWidth = 10;
            }
            else
            {
                Outline.GetComponent<Outline>().OutlineWidth = 5;
            }
            if (hit.transform.tag == "Button")
            {
                painText.rectTransform.sizeDelta = new Vector2(50.0f, 36.3f);
                statusText.rectTransform.sizeDelta = new Vector2(55.7f, 36.3f);
                painText.rectTransform.anchoredPosition = new Vector2(0.179997191f, 6.11000013f);
                statusText.rectTransform.anchoredPosition = new Vector2(0.179997191f, -3.2f);

                Canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(59.7f, 51.7f);
                Canvas.SetActive(true);
                if (hit.transform.name == "Button")
                {
                    painText.text = "�������� �̼�";
                    statusText.text = "�ɰ��� ������ ����Ǿ��ų�,\nġ���ϱ� ����� ����,\n������ �ʹ� ���Ұ��\n�������� �̼��մϴ�.\n\n���� ���� �� �����ϴ�.";
                }
                if (hit.transform.name == "Button1")
                {
                    painText.text = HealTitle[Scroll * 3];
                    statusText.text = HealDescription[Scroll * 3].Replace("\\n", "\n");
                }
                if (hit.transform.name == "Button2")
                {
                    painText.text = HealTitle[Scroll * 3 +1];
                    statusText.text = HealDescription[Scroll * 3 +1].Replace("\\n", "\n");
                }
                if (hit.transform.name == "Button3")
                {
                    painText.text = HealTitle[Scroll * 3 +2];
                    statusText.text = HealDescription[Scroll * 3 +2].Replace("\\n", "\n");
                }
            }
            else
                Canvas.SetActive(false);


            // ���� plane������ �浹 ������ ����ϴ�
            if (hit.transform.name == "Plane")
            {
                Cursor.visible = false;

                Vector3 localHitPoint = smallPlane.InverseTransformPoint(hit.point);
                float screenX = localHitPoint.x * (firstCamera.pixelWidth / 2 / 5f);
                float screenY = localHitPoint.z * (firstCamera.pixelHeight / 2 / 5f);
                Ray secondRay = secondCamera.ScreenPointToRay(new Vector2((-screenX + (firstCamera.pixelWidth / 2f)) / firstCamera.pixelWidth * secondCamera.pixelWidth, (-screenY + (firstCamera.pixelHeight / 2f)) / firstCamera.pixelWidth * secondCamera.pixelWidth));
                RaycastHit[] secondhit;
                secondhit = Physics.RaycastAll(secondRay, 15);
                Debug.DrawRay(secondRay.origin, secondRay.direction * 15.0f, Color.red);
                int k = 0;
                foreach (RaycastHit secondHit in secondhit)
                {
                    switch (secondHit.transform.tag)
                    {

                        case "PlaneCollider":
                            second_camera_trandform = secondHit.point;
                            rayDirection = secondRay.direction;
                            break;

                        case "Damaged":
                            if (k == 0)
                            {
                                k = 1;
                                painText.rectTransform.sizeDelta = new Vector2(31.39f, 36.3f);
                                statusText.rectTransform.sizeDelta = new Vector2(33.1f, 36.3f);
                                painText.rectTransform.anchoredPosition = new Vector2(0.179997191f, 2.83f);
                                statusText.rectTransform.anchoredPosition = new Vector2(0.179997191f, -6.833f);
                                Canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(36.37f, 42.6f);

                                Canvas.SetActive(true);
                                painText.text = secondHit.transform.GetComponent<Wound>().paintype;
                                statusText.text = "���� : " + secondHit.transform.GetComponent<Wound>().status["����"];
                                if (secondHit.transform.GetComponent<Wound>().status["����"] != 0)
                                    statusText.text += "\n���� : " + secondHit.transform.GetComponent<Wound>().status["����"];
                                if (secondHit.transform.GetComponent<Wound>().status["�鿪�� ��ȭ"] != 0)
                                    statusText.text += "\n�鿪�� ��ȭ : " + secondHit.transform.GetComponent<Wound>().status["�鿪�� ��ȭ"];
                                if (secondHit.transform.GetComponent<Wound>().status["����"] != 0)
                                    statusText.text += "\n���� : " + secondHit.transform.GetComponent<Wound>().status["����"];
                                if (secondHit.transform.GetComponent<Wound>().status["���� ��ȭ"] != 0)
                                    statusText.text += "\n���� ��ȭ : " + secondHit.transform.GetComponent<Wound>().status["���� ��ȭ"];
                            }
                            break;

                        case "body":
                            break;

                        default:
                            break;


                    }
                    if (k != 1)
                        Canvas.SetActive(false);
                }
            }
            else
                Cursor.visible = true;

            
        }else
            Cursor.visible = true;
    }
}







