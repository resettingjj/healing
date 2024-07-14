using UnityEngine;
using UnityEngine.UI;

public class MoveImageToMouse : MonoBehaviour
{
    // �̵���ų UI �̹����� RectTransform�� �����մϴ�.
    public RectTransform RectTransform;

    void OnEnable()
    {
        RectTransform.anchoredPosition = new Vector3(Input.mousePosition.x - 400, Input.mousePosition.y - 300, Input.mousePosition.z - 100);
    }
}
