using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartas : MonoBehaviour
{
    [SerializeField] Camera camara;
    public float distanciaRayo = 5f;

    [SerializeField] GameObject cartaJaula;
    [SerializeField] GameObject cartaLinterna;
    [SerializeField] GameObject cartaTuerca;
    [SerializeField] GameObject cartaGenerador;
    [SerializeField] GameObject cartaNegrelio;
    [SerializeField] GameObject cartaCajaMusical;
    [SerializeField] GameObject cartaEngranajeGenerador;
    private void Start()
    {
        cartaJaula.SetActive(false);
        cartaLinterna.SetActive(false);
        cartaTuerca.SetActive(false);
        cartaGenerador.SetActive(false);
        cartaNegrelio.SetActive(false);
        cartaCajaMusical.SetActive(false);
        cartaEngranajeGenerador.SetActive(false);
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


            if (hit.transform.CompareTag("CartaLinterna"))
            {
                cartaLinterna.SetActive(true);
            }
            else
            {
                cartaLinterna.SetActive(false);
            }


            if (hit.transform.CompareTag("CartaTuerca"))
            {
                cartaTuerca.SetActive(true);
            }
            else
            {
                cartaTuerca.SetActive(false);
            }


            if (hit.transform.CompareTag("CartaGenerador"))
            {
                cartaGenerador.SetActive(true);
            }
            else
            {
                cartaGenerador.SetActive(false);
            }


            if (hit.transform.CompareTag("CartaNegrelio"))
            {
                cartaNegrelio.SetActive(true);
            }
            else
            {
                cartaNegrelio.SetActive(false);
            }


            if (hit.transform.CompareTag("CartaCajaMusical"))
            {
                cartaCajaMusical.SetActive(true);
            }
            else
            {
                cartaCajaMusical.SetActive(false);
            }
            

            if (hit.transform.CompareTag("CartaEngranajeGenerador"))
            {
                cartaEngranajeGenerador.SetActive(true);
            }
            else
            {
                cartaEngranajeGenerador.SetActive(false);
            }
        }
    }
}
