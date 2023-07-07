using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LlaveFinal : MonoBehaviour
{
    [SerializeField] GameObject llaveMano;
    [SerializeField] GameObject llaveAgarrar;

    [SerializeField] GameObject rejaPuertaIzq;
    [SerializeField] GameObject rejaPuertaDer;

    [SerializeField] GameObject rejaPuertaIzqAnim;
    [SerializeField] GameObject rejaPuertaDerAnim;

    [SerializeField] Camera camara;
    float camaraDistancia = 1;

    bool activador = false;

    float contador = 0f;
    float contador2 = 0f;

    [SerializeField] GameObject fadeOut;

    [SerializeField] AudioSource sonidoLlaves;
    [SerializeField] AudioSource sonidoPuerta;

    void Start()
    {
        llaveAgarrar.SetActive(true);
        llaveMano.SetActive(false);

        rejaPuertaIzqAnim.SetActive(false);
        rejaPuertaDerAnim.SetActive(false);

        sonidoPuerta.Stop();
    }


    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, camaraDistancia))
        {
            if (hit.transform.CompareTag("LlaveCarpa"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    llaveAgarrar.SetActive(false);
                    llaveMano.SetActive(true);
                    activador = true;
                    sonidoLlaves.Play();
                }
            }

        }

        if (activador == true)
        {
            llaveAgarrar.SetActive(false);

            if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, camaraDistancia))
            {
                if (hit.transform.CompareTag("UltimaReja"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        llaveMano.SetActive(false);

                        rejaPuertaIzq.SetActive(false);
                        rejaPuertaDer.SetActive(false);

                        rejaPuertaIzqAnim.SetActive(true);
                        rejaPuertaDerAnim.SetActive(true);
                        sonidoPuerta.Play();
                        fadeOut.SetActive(true);
                        contador2++;
                        
                    }
                }
            }
            if(contador2 >= 0.1)
            {
                contador = contador + Time.deltaTime * 2;

                if (contador >= 2f)
                {
                    //Cambio a escena y fin de muerte
                    SceneManager.LoadScene("EscenaFinal");
                    contador = 0f;

                }
            }
        }
    }
}
