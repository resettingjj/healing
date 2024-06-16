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
        keyPain.Add("neck_pront", "��");
        keyPain.Add("neck_back", "��");
        keyPain.Add("head_pront", "��");
        keyPain.Add("head_back", "�Ӹ�");
        keyPain.Add("right_Arm_pront", "������");
        keyPain.Add("right_Arm2_pront", "������");
        keyPain.Add("right_Arm_back", "������");
        keyPain.Add("right_Arm2_back", "������");
        keyPain.Add("right_hand_pront", "������");
        keyPain.Add("right_hand_back", "������");
        keyPain.Add("left_Arm_pront", "����");
        keyPain.Add("left_Arm2_pront", "����");
        keyPain.Add("left_Arm_back", "����");
        keyPain.Add("left_Arm2_back", "����");
        keyPain.Add("left_hand_pront", "�޼�");
        keyPain.Add("left_hand_back", "�޼�");
        keyPain.Add("right_leg_pront", "�����ٸ�");
        keyPain.Add("right_leg2_pront", "�����ٸ�");
        keyPain.Add("right_leg_back", "�����ٸ�");
        keyPain.Add("right_leg2_back", "�����ٸ�");
        keyPain.Add("right_foot_pront", "������");
        keyPain.Add("right_foot_back", "������");
        keyPain.Add("left_leg_pront", "�޴ٸ�");
        keyPain.Add("left_leg2_pront", "�޴ٸ�");
        keyPain.Add("left_leg_back", "�޴ٸ�");
        keyPain.Add("left_leg2_back", "�޴ٸ�");
        keyPain.Add("left_foot_pront", "�޹�");
        keyPain.Add("left_foot_back", "�޹�");
        keyPain.Add("chest_back", "��");
        keyPain.Add("chest_pront", "����");
        keyPain.Add("Abdomen_pront", "��");
        keyPain.Add("Abdomen_back", "�㸮");
    }

    private void Start()
    {
        isbokje = true;
        status = 1;
        pain.RemoveAll(obj => obj.pain == "");
        Instantiate(player, Vector3.zero, Quaternion.identity);
        pain.OrderByDescending(obj => obj.GetComponent<Wound>().status["����"]).ToList();
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
            printer = keyPain[painList[k]] + "�� " + pain[k].GetComponent<Wound>().paintype; 
            if (Random.Range(0,3) == 0)
                printer+=new List<string>(new string[] { " ������ �ʹ� ���Ŀ�", " ������ �ᵵ �� ���ڰھ��.", " ������ ���� �����ؿ�", " ������ �װھ��", " �� ġ���� �ֽ� �� �ֳ���?", " ������ �ϻ��Ȱ�� ������. ������ ��ȭ�Ǵ� �� ���ƿ�.", " ����� �ʹ� ¡�׷�����." })[Random.Range(0, 7)];
            else
            {
                if (pain[k].GetComponent<Wound>().paintype == "��ó")
                    printer += "�� ";
                else
                    printer += "�� ";
                printer += new List<string>(new string[] { "�ʹ� ���ż� �Ծ��", "�ʹ� ���ļ� �ߵ��� ���� �� ���Ƽ� �Ծ��", "�ʹ� ���ؿ�.", "�� ������ �ʾƿ�.", "������ ��������, �ٸ� ���� �ʹ� ���Ŀ�", "�ʹ� ���ż� �Ծ��", "���ļ� ������ �ް� �;��" })[Random.Range(0, 7)];
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
