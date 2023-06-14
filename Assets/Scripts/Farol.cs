using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farol : MonoBehaviour
{
    [SerializeField] GameObject farolMano;
    [SerializeField] GameObject farolAgarrar;
    int farol = 0;
    [SerializeField] GameObject luzFarol;

    [SerializeField] Camera camara;
    [SerializeField] float camaraDistancia = 5f;
    bool banderaFarol;

    public GameObject texto;
    void Start()
    {
        texto.SetActive(false);

        luzFarol.SetActive(true);

        farolMano.SetActive(false);
    }


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, camaraDistancia, LayerMask.GetMask("AgarrarFarol")))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(farolAgarrar);
                farolMano.SetActive(true);
                farol = farol++;
                texto.SetActive(true);
            }
        }
        if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, camaraDistancia, LayerMask.GetMask("AgarrarFarol")))
        {
            texto.SetActive(true);
        }
        else
        {
            texto.SetActive(false);
        }

        if (farol >= 0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                luzFarol.SetActive(banderaFarol);
                banderaFarol = !banderaFarol;
            }

        }
    }
}

