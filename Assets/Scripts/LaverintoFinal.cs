using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaverintoFinal : MonoBehaviour
{
    [SerializeField] Camera camara;
    public float distanciaRayo = 5f;

    [SerializeField] GameObject llaveFinal;
    [SerializeField] GameObject llaveMano;

    [SerializeField] GameObject reja;
    [SerializeField] GameObject rejaAnimada;

    bool activador = false;

    void Start()
    {
        rejaAnimada.SetActive(false);
        reja.SetActive(true);
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, distanciaRayo))
        {
            if (hit.transform.CompareTag("LlaveFinal"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    llaveFinal.SetActive(false);
                    llaveMano.SetActive(true);
                    activador = true;
                }
            }

        }

        if(activador == true)
        {
            llaveFinal.SetActive(false);

            if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, distanciaRayo))
            {
                if (hit.transform.CompareTag("RejaFinal"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        llaveMano.SetActive(false);
                        reja.SetActive(false);
                        rejaAnimada.SetActive(true);
                    }
                }
            }
        }
    }
}
