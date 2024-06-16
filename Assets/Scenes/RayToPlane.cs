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

    private void Start()
    {
        manager = GameObject.Find("manager").GetComponent<iniated>();
        Outline = GameObject.Find("notebook").transform;
    }
    void Update()
    {
        // ���콺 ���� ��ư�� Ŭ������ ��
        // ù ��° ī�޶󿡼� ���콺 ��ġ�� Ray�� ���ϴ�
        Ray firstRay = firstCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(firstRay.origin, firstRay.direction * 10.0f, Color.red);

        // ���� plane�� ���� ��ǥ�� �������� Ray�� ���ϴ�
        if (Physics.Raycast(firstRay, out hit))
        {
            if (hit.transform.CompareTag("Button"))
            {
                Outline = hit.transform;
                Outline.GetComponent<Outline>().OutlineWidth = 10;
            }
            else
            {
                Outline.GetComponent<Outline>().OutlineWidth = 5;
            }
            // ���� plane������ �浹 ������ ����ϴ�
            Vector3 localHitPoint = smallPlane.InverseTransformPoint(hit.point);
            float screenX = localHitPoint.x * (firstCamera.pixelWidth/2/5f);
            float screenY = localHitPoint.z * (firstCamera.pixelHeight/2/5f);

            // ���� plane�� ũ�⸦ ����Ͽ� ������ ���� �����մϴ�

            // ���� plane�� �߽� ��ǥ�� �������� ��ũ�� ��ǥ�� ����մϴ�
            Vector3 planeCenter = smallPlane.position;
            Vector3 planePositionOnScreen = firstCamera.WorldToScreenPoint(planeCenter);
            // ù ��° ī�޶��� ���� ��ǥ�� �� ��° ī�޶��� ��ũ�� ��ǥ�� ��ȯ�մϴ�
            Vector3 secondScreenPoint = secondCamera.WorldToScreenPoint(localHitPoint);

            // �� ��° ī�޶󿡼� �ش� ��ũ�� ��ǥ�� ���ο� Ray�� �����մϴ�
            Ray secondRay = secondCamera.ScreenPointToRay(new Vector2(-screenX+ (firstCamera.pixelWidth/2), -screenY+(firstCamera.pixelHeight / 1.9f)));
            RaycastHit secondHit;
            //Debug.DrawRay(secondRay.origin, secondRay.direction * 10.0f, Color.red);
            // �� ��° ī�޶��� Ray�� Collider�� ��Ҵ��� Ȯ���մϴ�
            if (Physics.Raycast(secondRay, out secondHit))
            {
                // �� ��° ī�޶󿡼��� �浹 ������ ����ϴ�
                if (secondHit.transform.CompareTag("Damaged"))
                {
                    painText.text = secondHit.transform.GetComponent<Wound>().paintype;
                        statusText.text ="���� : "+ secondHit.transform.GetComponent<Wound>().status["����"];
                    if (secondHit.transform.GetComponent<Wound>().status["����"] != 0)
                        statusText.text += "\n���� : " + secondHit.transform.GetComponent<Wound>().status["����"];
                    if (secondHit.transform.GetComponent<Wound>().status["�鿪�� ��ȭ"] != 0)
                        statusText.text += "\n�鿪�� ��ȭ : " + secondHit.transform.GetComponent<Wound>().status["�鿪�� ��ȭ"];
                    if (secondHit.transform.GetComponent<Wound>().status["����"] != 0)
                        statusText.text += "\n���� : " + secondHit.transform.GetComponent<Wound>().status["����"];
                    if (secondHit.transform.GetComponent<Wound>().status["���� ��ȭ"] != 0)
                        statusText.text += "\n���� ��ȭ : " + secondHit.transform.GetComponent<Wound>().status["���� ��ȭ"];
                    Canvas.SetActive(true);
                }
                else
                    Canvas.SetActive(false);
            }
        }
    }
}







