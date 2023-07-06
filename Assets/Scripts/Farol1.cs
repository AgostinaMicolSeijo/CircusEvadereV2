using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farol1 : MonoBehaviour
{
    [SerializeField] GameObject luzFarol;
    bool banderaFarol;
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            luzFarol.SetActive(banderaFarol);
            banderaFarol = !banderaFarol;
        }
    }
}
