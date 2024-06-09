using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iniated : MonoBehaviour
{
    public GameObject player;
    public int status;
    public bool isbokje = false;
    public int i;
    public int difficulty = 0;
    public Wound wound;
    List<Wound> pain = new List<Wound> ();
    public List<string> painList = new List<string>(); 
    private Dictionary<string, string> keyPain = new Dictionary<string, string> ();
    // Start is called before the first frame update
    void Awake()
    {
        status = 0;
        for (int i = 0; i < 10; i++)
        {
            float angle = Random.Range(0f, 360f);
            // ¼±ÅÃµÈ °¢µµ¿¡ µû¸¥ À§Ä¡ °è»ê
            Vector3 targetPosition = Quaternion.Euler(0, angle, 0) * Vector3.forward * Random.Range(3f, 5f);

            Wound set = Instantiate(wound, targetPosition, Quaternion.identity);
            set.name = "wound"+ i;
            pain.Add(set);  
        }
        keyPain.Add("neck_pront", "¸ñ");
        keyPain.Add("neck_back", "¸ñ");
        keyPain.Add("head_pront", "¾ó±¼");
        keyPain.Add("head_back", "µÞ¸Ó¸®");
        keyPain.Add("right_Arm_pront", "¿À¸¥ÆÈ");
        keyPain.Add("right_Arm2_pront", "¿À¸¥ÆÈ");
        keyPain.Add("right_Arm_back", "¿À¸¥ÆÈ");
        keyPain.Add("right_Arm2_back", "¿À¸¥ÆÈ");
        keyPain.Add("right_hand_pront", "¿À¸¥¼Õ");
        keyPain.Add("right_hand_back", "¿À¸¥¼Õ");
        keyPain.Add("left_Arm_pront", "¿ÞÆÈ");
        keyPain.Add("left_Arm2_pront", "¿ÞÆÈ");
        keyPain.Add("left_Arm_back", "¿ÞÆÈ");
        keyPain.Add("left_Arm2_back", "¿ÞÆÈ");
        keyPain.Add("left_hand_pront", "¿Þ¼Õ");
        keyPain.Add("left_hand_back", "¿Þ¼Õ");
        keyPain.Add("right_leg_pront", "¿À¸¥´Ù¸®");
        keyPain.Add("right_leg2_pront", "¿À¸¥´Ù¸®");
        keyPain.Add("right_leg_back", "¿À¸¥´Ù¸®");
        keyPain.Add("right_leg2_back", "¿À¸¥´Ù¸®");
        keyPain.Add("right_foot_pront", "¿À¸¥¹ß");
        keyPain.Add("right_foot_back", "¿À¸¥¹ß");
        keyPain.Add("left_leg_pront", "¿Þ´Ù¸®");
        keyPain.Add("left_leg2_pront", "¿Þ´Ù¸®");
        keyPain.Add("left_leg_back", "¿Þ´Ù¸®");
        keyPain.Add("left_leg2_back", "¿Þ´Ù¸®");
        keyPain.Add("left_foot_pront", "¿Þ¹ß");
        keyPain.Add("left_foot_back", "¿Þ¹ß");
    }

    private void Start()
    {
        isbokje = true;
        status = 1;
        Instantiate(player, Vector3.zero, Quaternion.identity);
        for (int i = 0;i < 10;i++)
        {
            painList.Add(pain[i].GetComponent<Wound>().pain);
        }
        foreach (string i in painList)
        {
            if (i != null)
            {
                print(keyPain[i]);
            }
        }
    }
    private void Update()
    {
        if (i != 166)
            i += 1;
        if (i==166)
        {

        }

    }
}
