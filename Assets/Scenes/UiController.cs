using UnityEngine;
using UnityEngine.UI;

public class MoveImageToMouse : MonoBehaviour
{
    // 이동시킬 UI 이미지의 RectTransform을 참조합니다.
    public RectTransform RectTransform;

    void OnEnable()
    {
        RectTransform.anchoredPosition = new Vector3(Input.mousePosition.x - 400, Input.mousePosition.y - 300, Input.mousePosition.z - 100);
    }
}
