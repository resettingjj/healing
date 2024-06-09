using TMPro;
using UnityEngine;

public class RayFromOneCameraToAnother : MonoBehaviour
{
    public Camera firstCamera; // 첫 번째 카메라
    public Camera secondCamera; // 두 번째 카메라
    public Transform smallPlane;
    public TextMeshProUGUI statusText;
    public GameObject Canvas;
    public LineRenderer lineRenderer;

    void Update()
    {
        // 마우스 왼쪽 버튼을 클릭했을 때
        // 첫 번째 카메라에서 마우스 위치로 Ray를 쏩니다
        Ray firstRay = firstCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(firstRay.origin, firstRay.direction * 10.0f, Color.red);

        // 작은 plane의 로컬 좌표를 기준으로 Ray를 쏩니다
        if (Physics.Raycast(firstRay, out hit))
        {
            // 작은 plane에서의 충돌 지점을 얻습니다
            Vector3 localHitPoint = smallPlane.InverseTransformPoint(hit.point);
            float screenX = localHitPoint.x * (firstCamera.pixelWidth/2/5f);
            float screenY = localHitPoint.z * (firstCamera.pixelHeight/2/5f);

            // 작은 plane의 크기를 고려하여 스케일 값을 조정합니다

            // 작은 plane의 중심 좌표를 기준으로 스크린 좌표를 계산합니다
            Vector3 planeCenter = smallPlane.position;
            Vector3 planePositionOnScreen = firstCamera.WorldToScreenPoint(planeCenter);
            print(localHitPoint);
            // 첫 번째 카메라의 월드 좌표를 두 번째 카메라의 스크린 좌표로 변환합니다
            Vector3 secondScreenPoint = secondCamera.WorldToScreenPoint(localHitPoint);

            // 두 번째 카메라에서 해당 스크린 좌표로 새로운 Ray를 생성합니다
            Ray secondRay = secondCamera.ScreenPointToRay(new Vector2(-screenX+ (firstCamera.pixelWidth/2), -screenY+(firstCamera.pixelHeight / 1.9f)));
            RaycastHit secondHit;
            Debug.DrawRay(secondRay.origin, secondRay.direction * 10.0f, Color.red);
            // 두 번째 카메라의 Ray가 Collider에 닿았는지 확인합니다
            if (Physics.Raycast(secondRay, out secondHit))
            {
                // 두 번째 카메라에서의 충돌 지점을 얻습니다
                if (secondHit.transform.CompareTag("Damaged"))
                {
                    statusText.text = secondHit.transform.GetComponent<Wound>().pain + " 아픔\n통증 : ";
                    Canvas.SetActive(true);
                }
                else
                    Canvas.SetActive(false);
            }
        }
    }
}







