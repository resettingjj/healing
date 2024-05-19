using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Raycaster : MonoBehaviour

{
    // Start is called before the first frame update
    public TextMeshProUGUI statusText;
    public GameObject Canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("Damaged"))
            {
                statusText.text = hit.transform.GetComponent<Wound>().pain + " æ∆«ƒ\n≈Î¡ı : ";
                Canvas.SetActive(true);
            }
            else
                Canvas.SetActive(false);
        }
    }
}
