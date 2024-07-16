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
    private Botton ButtonScroll;
    public List<string> HealTitle;
    public List<string> HealDescription;
    public GameObject maginfier;
    public GameObject Effecter;

    public Transform startPoint;// 라인 렌더러 컴포넌트

    private void Start()
    {
        manager = GameObject.Find("manager").GetComponent<iniated>();
        ButtonScroll = GameObject.Find("Display").GetComponent<Botton>();
        Outline = GameObject.Find("notebook").transform;
        rayDirection = Vector3.forward;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // 시작점과 끝점으로 구성된 라인
        lineRenderer.startWidth = 0.01f; // 시작 지점의 라인 너비
        lineRenderer.endWidth = 0.01f; // 끝 지점의 라인 너비

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
                    painText.text = "병원으로 이송";
                    statusText.text = "심각한 감염이 진행되었거나,\n치료하기 어려운 상태,\n통증이 너무 심할경우\n병원으로 이송합니다.\n\n돈을 받을 수 없습니다.";
                }
                if (hit.transform.name == "Button1")
                {
                    painText.text = HealTitle[ButtonScroll.Scroll * 3];
                    statusText.text = HealDescription[ButtonScroll.Scroll * 3].Replace("\\n", "\n");
                }
                if (hit.transform.name == "Button2")
                {
                    painText.text = HealTitle[ButtonScroll.Scroll * 3 +1];
                    statusText.text = HealDescription[ButtonScroll.Scroll * 3 +1].Replace("\\n", "\n");
                }
                if (hit.transform.name == "Button3")
                {
                    painText.text = HealTitle[ButtonScroll.Scroll * 3 +2];
                    statusText.text = HealDescription[ButtonScroll.Scroll * 3 +2].Replace("\\n", "\n");
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
                    
                    if (Input.GetMouseButtonUp(0))
                    {
                        Effecter.SetActive(false);
                        lineRenderer.enabled = false;
                    }
                    if (secondHit.transform.tag == "body")
                    {
                        if (Input.GetMouseButton(0))
                        {
                            Vector3 direction = (secondHit.point - startPoint.position).normalized;
                            float distance = Vector3.Distance(startPoint.position, secondHit.point);
                            lineRenderer.enabled = true;
                            Vector3 endPoint = startPoint.position + direction * distance;
                            // LineRenderer에 시작점과 끝점 설정
                            lineRenderer.SetPosition(0, startPoint.position);
                            lineRenderer.SetPosition(1, endPoint);
                            Effecter.transform.position = secondHit.point;
                            Effecter.SetActive(true);
                        }
                    }
                    else switch (secondHit.transform.tag)
                    {

                        case "PlaneCollider":
                            second_camera_trandform = secondHit.point;
                            rayDirection = secondRay.direction;
                            break;

                        case "Damaged":
                            if (k == 0 && maginfier.activeSelf)
                            {
                                k = 1;
                                painText.rectTransform.sizeDelta = new Vector2(31.39f, 36.3f);
                                statusText.rectTransform.sizeDelta = new Vector2(33.1f, 36.3f);
                                painText.rectTransform.anchoredPosition = new Vector2(0.179997191f, 2.83f);
                                statusText.rectTransform.anchoredPosition = new Vector2(0.179997191f, -6.833f);
                                Canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(36.37f, 42.6f);

                                Canvas.SetActive(true);
                                painText.text = secondHit.transform.GetComponent<Wound>().paintype;
                                statusText.text = "통증 : " + secondHit.transform.GetComponent<Wound>().status["통증"];
                                if (secondHit.transform.GetComponent<Wound>().status["감염"] != 0)
                                    statusText.text += "\n감염 : " + secondHit.transform.GetComponent<Wound>().status["감염"];
                                if (secondHit.transform.GetComponent<Wound>().status["면역력 약화"] != 0)
                                    statusText.text += "\n면역력 약화 : " + secondHit.transform.GetComponent<Wound>().status["면역력 약화"];
                                if (secondHit.transform.GetComponent<Wound>().status["경직"] != 0)
                                    statusText.text += "\n경직 : " + secondHit.transform.GetComponent<Wound>().status["경직"];
                                if (secondHit.transform.GetComponent<Wound>().status["근육 약화"] != 0)
                                    statusText.text += "\n근육 약화 : " + secondHit.transform.GetComponent<Wound>().status["근육 약화"];                            }
                            break;

                        default:
                            Vector3 direction = (secondHit.point - startPoint.position).normalized;
                            float distance = hit.distance;
                            Vector3 endPoint = startPoint.position + direction * distance;
                            // LineRenderer에 시작점과 끝점 설정
                            lineRenderer.SetPosition(0, startPoint.position);
                            lineRenderer.SetPosition(1, endPoint);
                            Effecter.SetActive(false);
                        lineRenderer.enabled = false;
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







