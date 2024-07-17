using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Wound : MonoBehaviour
{
    public float[] y;
    public int i;
    public string[] sick;
    public string pain;
    public string paintype;
    public Collider Collider1;
    private iniated manager;
    public Dictionary<string, int> status = new Dictionary<string, int>();
    // Start is called before the first frame update

    
    
    void Awake()
    {
        manager = GameObject.Find("manager").GetComponent<iniated>();
        if (!manager.isbokje)
        {
            i = Random.Range(0, y.Length / 2 - 1);
            transform.position = new Vector3(transform.position.x, Random.Range(y[i * 2], y[i * 2 + 1]), transform.position.z);
            LayerMask mask = LayerMask.GetMask("body");
            RaycastHit hit;
            if (Physics.Raycast(transform.position, new Vector3(0, transform.position.y, 0) - transform.position, out hit, 20f, mask))
            {
                transform.position = hit.point + hit.normal * 0.01f;
                pain = hit.collider.gameObject.name;
                if (transform.position.z > 0)
                   pain = pain + "_pront";
                else
                   pain = pain + "_back";
                int randomPaintype = Random.Range(0, 4);
                paintype = new List<string>(new string[] {"상처", "화상", "골절", "근육파열"})[randomPaintype];
                transform.GetChild(randomPaintype).gameObject.SetActive(true);
                status.Add("통증", Random.Range(1,10));
                status.Add("감염", Random.Range(-5, 23)/7);
                status.Add("면역력 약화", Random.Range(-2, 18)/3);
                status.Add("경직", Random.Range(-1, 10)/2);
                status.Add("근육 약화", Random.Range(0, 10)/3);


                transform.parent = hit.collider.gameObject.transform;
                transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            }
            else
            {
                Destroy(gameObject);
            }
            Collider1.enabled = true;
            
        }
        
    }
}

