using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaverintoFinal : MonoBehaviour
{
    [SerializeField] Camera camara;
    public float distanciaRayo = 5f;

    [SerializeField] GameObject llaveFinal;
    [SerializeField] GameObject llaveMano;

    void Start()
    {
        
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
                }
            }

        }
    }
}
