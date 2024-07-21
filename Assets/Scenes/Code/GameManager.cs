using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
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
    public TextMeshProUGUI checkList;
    public string fainThreeList;
    public  GameObject originPlayer;
    private GameObject copyPlayer;
    public float stress = 100;
    public float stressful = 1;
    public Slider slice;
    public float painSum;
    public float completeWound;
    public float infectionSum;
    public List<bool> checking;
    public float sumCheck;
    public int stage;
    public RayFromOneCameraToAnother plane;
    public TextMeshProUGUI woundstat;
    public TextMeshProUGUI resultheal;
    public TextMeshProUGUI resultmoney;
    private int resultMoney;
    private float startpainsum;
    // Start is called before the first frame update

    public void settingGame()
    {
        originPlayer = Instantiate(player, Vector3.zero, Quaternion.identity);
        originPlayer.name = "originPlayer" + stage;
        status = 0;
        i=0;
        k=0;
        for (int c = 0; c < 6;)
        {
            float angle = Random.Range(0f, 360f);
            Vector3 targetPosition = Quaternion.Euler(0, angle, 0) * Vector3.forward * Random.Range(3f, 6f);
            targetPosition = new Vector3(targetPosition.x, Random.Range(-0.88f, 0.88f), targetPosition.z);
            LayerMask mask = LayerMask.GetMask("body");
            RaycastHit hit;
            if (Physics.Raycast(targetPosition, new Vector3(0,targetPosition.y,0) - targetPosition, out hit, 20f, mask))
            {
                Wound set = Instantiate(wound, hit.point + hit.normal * 0.01f, Quaternion.FromToRotation(Vector3.up, hit.normal));
                set.gameObject.transform.parent = hit.transform;
                set.name = "wound" + c;
                string woundPosName = hit.collider.gameObject.name;
                if (hit.point.z > 0)
                    woundPosName = woundPosName + "_pront";
                else
                    woundPosName = woundPosName + "_back";
                set.pain = woundPosName;
                pain.Add(set);
                c++;
            }
        }
        
        isbokje = true;
        status = 1;
        pain.RemoveAll(obj => obj.pain == "");
        pain = pain.OrderByDescending(obj => obj.status["통증"]).ToList();
        painList.Clear();
        for (int a = 0;a < pain.Count;a++)
        {
            painList.Add(pain[a].pain);
        }
        copyPlayer = Instantiate(originPlayer, new Vector3(100,100,100), Quaternion.identity);
        copyPlayer.name = "copyPlayer" + stage ;
        startpainsum = pain.Sum(dict => dict.status.ContainsKey("통증") ? dict.status["통증"] : 0);
    }
    public void resetGame()
    {
        infectionSum = pain.Sum(dict => dict.status.ContainsKey("감염") ? dict.status["감염"] : 0);
        painSum = pain.Sum(dict => dict.status.ContainsKey("통증") ? dict.status["통증"] : 0);
        completeWound = pain.Count(dict => dict.paintype == "치료됨");
        sumCheck = checking.Count(a => a == true);
        resultheal.text = "\n";
        resultMoney = 0;
        evaluation(completeWound / pain.Count);
        evaluation(sumCheck / 3.00f);
        if (infectionSum >= 9)
        {
            resultheal.text += "worst\n";
            resultMoney += -50;
        }
        else if (infectionSum >= 7)
        {
            resultheal.text += "bad\n";
            resultMoney += -20;
        }
        else if (infectionSum >= 5)
        {
            resultheal.text += "soso\n";
            resultMoney += 5;
        }
        else if (infectionSum >= 3)
        {
            resultheal.text += "nice\n";
            resultMoney += 2;
        }
        else if (infectionSum >= 1)
        {
            resultheal.text += "good\n";
            resultMoney += 30;
        }
        else
        {
            resultheal.text += "perpect\n";
            resultMoney += 50;
        }
        resultheal.text += "\n";
        evaluation((startpainsum - painSum) / startpainsum);
        evaluation((stress) / 66);
        resultmoney.text = "정산 금액 : " + resultMoney + "$";
        woundstat.text = "\n 상처 치료 : (" + completeWound + "/" + pain.Count + ")\n치명적인 상처 : (" + sumCheck + "/3)\n상처 감염도 : " + Mathf.FloorToInt(infectionSum) + "\n\n 통증 완화 : (" + Mathf.FloorToInt(painSum) + "/" + startpainsum + ")\n스트레스 수치 : (" + Mathf.FloorToInt(stress) + "/100)";

        plane.money += resultMoney;
        checking[0] = false;
        checking[1] = false;
        checking[2] = false;
        copyPlayer.SetActive(false);
        originPlayer.SetActive(false);
        pain.Clear();
        painList.Clear();
        status = 0;
        fainThreeList = "";
        isbokje = false;
        stage += 1;
        settingGame();

    }
    
    
    void evaluation(float ratio)
{
    if (ratio >= 1)
    {
        resultheal.text += "perpect\n";
        resultMoney += 50;
    }
    else if (ratio == 0)
    {
        resultheal.text += "worst\n";
        resultMoney += -50;
    }
    else if (ratio < 0.25)
    {
        resultheal.text += "bad\n";
        resultMoney += -20;
    }
    else if (ratio < 0.5)
    {
        resultheal.text += "soso\n";
        resultMoney += 5;
    }
    else if (ratio < 0.75)
    {
        resultheal.text += "nice\n";
        resultMoney += 20;
    }
    else
    {
        resultheal.text += "good\n";
        resultMoney += 30;
    }
}
private void Start()
    {
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
        settingGame();
    }
    private void Update()
    {
        
        
        slice.value = stress;
        if (i==166)
        {
            
            stress = 100;
            chat.SetActive(true);
            text.text = "";
            printer = keyPain[painList[k]] + "의 " + pain[k].GetComponent<Wound>().paintype;
            fainThreeList += "ㅁ" + printer +"\n";
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
            k+=1;
        }  
        if(i > 166 && i < 1000)
        {
            if (printer.Length > (i - 167))
                    text.text += printer[(i - 167)];
            else
            {
                i = 145;
                checkList.text = fainThreeList;
                if (k==3)
                {
                    chat.SetActive(false);
                    i = 1000;
                }
            }
                
        }
        i += 1;
        if(i > 1000)
        {
            if (i%25 == 0)
            stress += -0.1f*stressful;
            fainThreeList = "";
            for(int i = 0; i < 3; i++){
                printer = keyPain[painList[i]] + "의 " + pain[i].GetComponent<Wound>().paintype;
                if(pain[i].GetComponent<Wound>().paintype == "치료됨")
                {
                    checking[i] = true;
                    printer = "완료됨";
                }
                fainThreeList += "ㅁ" + printer +"\n";
            }
            checkList.text = fainThreeList;
        }
    }
}
