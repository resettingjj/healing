using UnityEngine;
using UnityEngine.UI;

public class MoveStat : MonoBehaviour
{
    // �̵���ų UI �̹����� RectTransform�� �����մϴ�.
    public RectTransform RectTransform;
    public Camera maincam;
    void Update()
    {
        RectTransform.anchoredPosition = new Vector3(Input.mousePosition.x - maincam.pixelWidth/2 + 100, Input.mousePosition.y - maincam.pixelHeight/2 + 90, Input.mousePosition.z - 100);
    }
}
