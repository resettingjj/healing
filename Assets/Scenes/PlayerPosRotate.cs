using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosRotate : MonoBehaviour
{
    public inHospital Animation;
    // Start is called before the first frame update

    // Update is called once per frame
    public void reposition()
    {
        Animation.stopAnimation = true;
        foreach (Transform child in transform)
        {
            // 자식 오브젝트에서 MyComponent 컴포넌트를 가져옵니다.
            setRotate[] myComponent = GetComponentsInChildren<setRotate>();

            // MyComponent 컴포넌트가 있는 경우 함수 호출
            foreach (setRotate component in myComponent)
            {
                component.settingRotate();
            }
        }
    }
}
