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

    private void Start()
    {
        manager = GameObject.Find("manager").GetComponent<iniated>();
        Outline = GameObject.Find("notebook").transform;
    }
    void Update()
    {
        Ray firstRay = firstCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(firstRay.origin, firstRay.direction * 15.0f, Color.red);

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
            Ray secondRay = secondCamera.ScreenPointToRay(new Vector2((-screenX+ (firstCamera.pixelWidth/2f))/firstCamera.pixelWidth*secondCamera.pixelWidth, (-screenY+(firstCamera.pixelHeight / 2f)) / firstCamera.pixelWidth * secondCamera.pixelWidth));
            RaycastHit[] secondhit;
            secondhit = Physics.RaycastAll(secondRay, 15);
            Debug.DrawRay(secondRay.origin, secondRay.direction * 15.0f, Color.red);
            int k = 0;
            foreach (RaycastHit secondHit in secondhit)
            {
                switch(secondHit.transform.tag)
                {
                    case "Starter" :
                        second_camera_start = secondHit.point;
                        break;

                    case "PlaneCollider" :
                        second_camera_trandform = secondHit.point;
                        rayDirection = secondRay.direction;
                        break;

                    case "Damaged":
                        if (k==0)
                        {
                            k = 1;
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
                if(k!=1)
                    Canvas.SetActive(false);
            }
        }
    }
}







