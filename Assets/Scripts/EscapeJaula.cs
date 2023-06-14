using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeJaula : MonoBehaviour
{
    //Llaves
    [SerializeField] GameObject llaveMano;
    [SerializeField] GameObject llaveAgarrar;
    [SerializeField] GameObject llavePuerta;

    [SerializeField] Camera camara;
    [SerializeField] float camaraDistancia = 5;

    [SerializeField] GameObject textoLlave;
    //Puertas
    [SerializeField] GameObject puertaCerrada;
    [SerializeField] GameObject puertaAbierta;
    [SerializeField] GameObject textoPuerta;

    bool banderaPuerta;
    bool banderaDesactivar;

    //audio
    [SerializeField] AudioSource sonidoLlaves;

    private void Awake()
    {
        puertaCerrada.SetActive(true);
        puertaAbierta.SetActive(false);
    }
    void Start()
    {
        llaveMano.SetActive(false);
        llaveAgarrar.SetActive(true);
        llavePuerta.SetActive(false);
        textoPuerta.SetActive(false);
    }


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, camaraDistancia))
        {
            if (hit.transform.CompareTag("Llave1"))
            {
                textoLlave.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    sonidoLlaves.Play();
                    llaveMano.SetActive(true);
                    llaveAgarrar.SetActive(false);
                    banderaPuerta = true;
                    banderaDesactivar = true;
                }
            }
            else
            {
               textoLlave.SetActive(false);
            }
            if (banderaDesactivar == true)
            {
                if (banderaPuerta == true)
                {
                    if (hit.transform.CompareTag("Puerta"))
                    {
                        //textoPuerta.SetActive(true);

                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            puertaCerrada.SetActive(false);
                            llaveMano.SetActive(false);
                            puertaAbierta.SetActive(true);
                            llavePuerta.SetActive(true);
                            banderaDesactivar = false;
                            //textoPuerta.SetActive(false);
                        }
                    }
                    else
                    {
                        //textoPuerta.SetActive(false);
                    }
                }
            }
            else
            {
                //textoPuerta.SetActive(false);
            }
        }
    }
}
