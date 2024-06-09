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
            // ���õ� ������ ���� ��ġ ���
            Vector3 targetPosition = Quaternion.Euler(0, angle, 0) * Vector3.forward * Random.Range(3f, 5f);

            Wound set = Instantiate(wound, targetPosition, Quaternion.identity);
            set.name = "wound"+ i;
            pain.Add(set);  
        }
        keyPain.Add("neck_pront", "��");
        keyPain.Add("neck_back", "��");
        keyPain.Add("head_pront", "��");
        keyPain.Add("head_back", "�޸Ӹ�");
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
