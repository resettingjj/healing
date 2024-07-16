using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemListSelect : MonoBehaviour
{
    private Botton Button;
    // Start is called before the first frame update
    void Start()
    {
        Button = GameObject.Find("Display").GetComponent<Botton>();
    }

    // Update is called once per frame
    public void ItemUsed()
    {
        if(Button.itemSelected != -1)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false); // 각 자식 오브젝트 비활성화
            }
            transform.GetChild(Button.itemSelected).gameObject.SetActive(true);

        }
    }
}
