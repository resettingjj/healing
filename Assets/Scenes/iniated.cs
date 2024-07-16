using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class iniated : MonoBehaviour
{
    public GameObject player;
    public int status;
    public bool isbokje = false;
    public int i;
    public int difficulty = 0;
    public Wound wound;
    public List<Wound> pain = new List<Wound> ();
    public List<string> painList = new List<string>();
    public TextMeshProUGUI text;
    public GameObject chat;
    public  Dictionary<string, string> keyPain = new Dictionary<string, string> ();
    private string printer;
    private int k;
    private List<string> message;
    // Start is called before the first frame update
    void Awake()
    {
        status = 0;
        for (int i = 0; i < 10; i++)
        {
            float angle = Random.Range(0f, 360f);
            // ���õ� ������ ���� ��ġ ���
            Vector3 targetPosition = Quaternion.Euler(0, angle, 0) * Vector3.forward * Random.Range(3f, 5f);

            Wound set = Instantiate(wound, targetPosition, Quaternion.identity);
            set.name = "wound"+ i;
            pain.Add(set);  
        }
        keyPain.Add("neck_pront", "목");
        keyPain.Add("neck_back", "목");
        keyPain.Add("head_pront", "얼굴");
        keyPain.Add("head_back", "머리");
        keyPain.Add("right_Arm_pront", "오른팔");
        keyPain.Add("right_Arm2_pront", "오른팔");
        keyPain.Add("right_Arm_back", "오른팔");
        keyPain.Add("right_Arm2_back", "오른팔");
        keyPain.Add("right_hand_pront", "오른손");
        keyPain.Add("right_hand_back", "오른손");
        keyPain.Add("left_Arm_pront", "왼팔");
        keyPain.Add("left_Arm2_pront", "왼팔");
        keyPain.Add("left_Arm_back", "왼팔");
        keyPain.Add("left_Arm2_back", "왼팔");
        keyPain.Add("left_hand_pront", "왼손");
        keyPain.Add("left_hand_back", "왼손");
        keyPain.Add("right_leg_pront", "오른다리");
        keyPain.Add("right_leg2_pront", "오른다리");
        keyPain.Add("right_leg_back", "오른다리");
        keyPain.Add("right_leg2_back", "오른다리");
        keyPain.Add("right_foot_pront", "오른발");
        keyPain.Add("right_foot_back", "오른발");
        keyPain.Add("left_leg_pront", "왼다리");
        keyPain.Add("left_leg2_pront", "왼다리");
        keyPain.Add("left_leg_back", "왼다리");
        keyPain.Add("left_leg2_back", "왼다리");
        keyPain.Add("left_foot_pront", "왼발");
        keyPain.Add("left_foot_back", "왼발");
        keyPain.Add("chest_back", "등");
        keyPain.Add("chest_pront", "가슴");
        keyPain.Add("Abdomen_pront", "배");
        keyPain.Add("Abdomen_back", "허리");
    }

    private void Start()
    {
        isbokje = true;
        status = 1;
        pain.RemoveAll(obj => obj.pain == "");
        Instantiate(player, Vector3.zero, Quaternion.identity);
        pain.OrderByDescending(obj => obj.GetComponent<Wound>().status["통증"]).ToList();
        for (int i = 0;i < pain.Count;i++)
        {
            painList.Add(pain[i].GetComponent<Wound>().pain);
        }
    }
    private void Update()
    {
        if (i==166)
        {
            chat.SetActive(true);
            text.text = "";
            printer = keyPain[painList[k]] + "의 " + pain[k].GetComponent<Wound>().paintype; 
            if (Random.Range(0,3) == 0)
                printer+=new List<string>(new string[] { " 때문에 너무 아파요", " 때문에 잠도 잘 못자겠어요.", " 때문에 몸이 불편해요", " 때문에 죽겠어요", " 좀 치료해 주실 수 있나요?", " 때문에 일상생활이 힘들어요. 갈수록 악화되는 것 같아요.", " 모습이 너무 징그러워요." })[Random.Range(0, 7)];
            else
            {
                if (pain[k].GetComponent<Wound>().paintype == "상처")
                    printer += "가 ";
                else
                    printer += "이 ";
                printer += new List<string>(new string[] { "너무 쑤셔서 왔어요", "너무 아파서 견디질 못할 것 같아서 왔어요", "너무 심해요.", "잘 낫지를 않아요.", "갈수록 심해지고, 다른 곳도 너무 아파요", "너무 쑤셔서 왔어요", "아파서 검진을 받고 싶어요" })[Random.Range(0, 7)];
            }
            if (k != 3)
            {
                i += 1;
                k += 1;
            }
            else
            {
                chat.SetActive(false);
                i = 1000;
            }
        }
        if(i > 166 && i < 1000)
        {
            if (printer.Length > (i - 167))
                    text.text += printer[(i - 167)];
            else
                i = 116;
        }
        i += 1;

    }
}
