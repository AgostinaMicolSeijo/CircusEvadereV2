using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartas : MonoBehaviour
{
    [SerializeField] Camera camara;
    public float distanciaRayo = 5f;

    [SerializeField] GameObject cartaJaula;

    private void Start()
    {
        cartaJaula.SetActive(false);
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, distanciaRayo))
        {
            if (hit.transform.CompareTag("CartaJaula"))
            {
                cartaJaula.SetActive(true);
            }
            else
            {
                cartaJaula.SetActive(false);
            }
        }
    }
}
