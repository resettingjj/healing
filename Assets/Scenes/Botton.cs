using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Botton : MonoBehaviour
{
    public GameObject Magnify;
    public GameObject cloth;
    public bool click1 = false;
    public bool click2 = false;
    public bool click3 = false;
    public Button button1;
    public Button button2;
    public Button button3;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;

    public int Scroll;
    public int itemSelected = -1;
    public PlayerPosRotate rotater;

    
    public void OnClickButton1()
    {
        
        if (!click1)
        {
            click1 = true;
            if (Scroll != 0)
            {
                click2 = false;
                click3 = false;
                ColorChanging(button2,click2);
                ColorChanging(button3,click3);
                itemSelected = Scroll*3 -3;
            }
            else
                Magnify.SetActive(true);
        }
        else if (click1) 
        {
            click1 = false;
            if (Scroll != 0)
                itemSelected = -1;
            else
                Magnify.SetActive(false);
        }
        ColorChanging(button1,click1);
    }
    public void OnClickButton2()
    {
        if (!click2)
        {
            click2 = true;
            if (Scroll != 0)
            {
                click1 = false;
                click3 = false;
                ColorChanging(button1,click1);
                ColorChanging(button3,click3);
                itemSelected = Scroll*3-2;
            }
            else
                cloth.SetActive(false);
        }
        else if (click2)
        {
            click2 = false;
            if (Scroll != 0)
                itemSelected = -1;
            else
                cloth.SetActive(true);
        }
        ColorChanging(button2,click2);
    }
    public void DisableAllChildren(GameObject gameObject)
    {
        // 현재 게임 오브젝트의 모든 자식 오브젝트 가져오기
        Transform parentTransform = gameObject.transform;
        for (int i = 0; i < parentTransform.childCount; i++)
        {
            GameObject child = parentTransform.GetChild(i).gameObject;
            child.SetActive(false); // 각 자식 오브젝트 비활성화
        }
    }
    void ActivateSecondChildObject(GameObject gameObject)
    {
        // 현재 게임 오브젝트의 두 번째 자식 오브젝트 가져오기 (인덱스는 0부터 시작)
        if (gameObject.transform.childCount > Scroll) // 적어도 두 개 이상의 자식 오브젝트가 있어야 함
        {
            GameObject secondChild = gameObject.transform.GetChild(Scroll).gameObject;
            secondChild.SetActive(true); // 두 번째 자식 오브젝트 활성화
        }
        else
        {
            Debug.LogWarning("There are not enough children to activate the second child.");
        }
    }
    void SetActiveItem(GameObject gameObject)
    {
        // 현재 게임 오브젝트의 두 번째 자식 오브젝트 가져오기 (인덱스는 0부터 시작)
        if (gameObject.transform.childCount > itemSelected) // 적어도 두 개 이상의 자식 오브젝트가 있어야 함
        {
            GameObject secondChild = gameObject.transform.GetChild(itemSelected).gameObject;
            secondChild.SetActive(true); // 두 번째 자식 오브젝트 활성화
        }
        else
        {
            Debug.LogWarning("There are not enough children to activate the second child.");
        }
    }

    public void OnClickButton3()
    {
        if(Scroll != 0)
        {
            if (!click3)
            {
                click3 = true;
                click2 = false;
                click1 = false;
                ColorChanging(button2,click2);
                ColorChanging(button1,click1);
                itemSelected = Scroll*3-1;
            }
            else if (click3)
            {
                click3 = false;
                itemSelected = -1;
            }
            ColorChanging(button3,click3);
        }else
        {
            rotater.reposition();
        }
    }
    

    public void ColorChanging(Button button, bool click)
    {
        ColorBlock colorBlock = button.colors;

        // 선택 여부에 따라 색상 설정
        colorBlock.normalColor = click ? new Color(0, 1f, 0, 1f) : Color.white;
        colorBlock.selectedColor = click ? new Color(0, 1f, 0, 1f) : Color.white;

        button.colors = colorBlock;
    }

    public void slide_up()
    {
        Scroll += 1;
        scrolling();
    }
    public void slide_down()
    {
        Scroll += -1;
        scrolling();
    }
    public void scrolling()
    {
        click1 = false;
        click2 = false;
        click3 = false;
        ColorChanging(button1,click1);
        ColorChanging(button2,click2);
        ColorChanging(button3,click3);
        DisableAllChildren(obj1);
        DisableAllChildren(obj2);
        DisableAllChildren(obj3);
        ActivateSecondChildObject(obj1);
        ActivateSecondChildObject(obj2);
        ActivateSecondChildObject(obj3);

        if (Scroll == 0)
        {
            if (Magnify.activeSelf)
            {
                click1 = true;
                ColorChanging(button1 ,click1);
            }
            if(!cloth.activeSelf)
            {
                click2 = true;
                ColorChanging(button2 ,click2);
            }
        }
        else
        {
            if ((Scroll-1)*3 == itemSelected)
            {
                click1 = true;
                ColorChanging(button1 ,click1);
            }
            if((Scroll-1)*3 +1 == itemSelected)
            {
                click2 = true;
                ColorChanging(button2 ,click2);
            }
            if ((Scroll-1)*3 +2 == itemSelected)
            {
                click3 = true;
                ColorChanging(button3 ,click3);
            }
        }
        
    }
    
}
