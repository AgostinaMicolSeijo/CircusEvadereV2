using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartasFinal : MonoBehaviour
{
    //UltimaCarta
    [SerializeField] Camera camara;
    public float distanciaRayo = 1f;

    [SerializeField] GameObject cartaFinal;
    void Start()
    {
        cartaFinal.SetActive(false);
    }


    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, distanciaRayo , LayerMask.GetMask("UltimaCarta")))
        {
           
            
                cartaFinal.SetActive(true);
            
           
        }
        else
        {
            cartaFinal.SetActive(false);
        }
    }
}
