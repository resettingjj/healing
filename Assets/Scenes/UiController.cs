using UnityEngine;
using UnityEngine.UI;

public class MoveImageToMouse : MonoBehaviour
{
    // �̵���ų UI �̹����� RectTransform�� �����մϴ�.
    public RectTransform RectTransform;
    public Camera maincam;
    void OnEnable()
    {
        RectTransform.anchoredPosition = new Vector3(Input.mousePosition.x - maincam.pixelWidth/2 + 60, Input.mousePosition.y - maincam.pixelHeight/2 + 60, Input.mousePosition.z - 100);
    }
}
