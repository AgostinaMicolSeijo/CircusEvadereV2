using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Morir : MonoBehaviour
{
    //EsperaMuerte
    bool vanderaMuerte = false;
    float contador = 0f;

    //fadeOut
    [SerializeField] GameObject fadeOut;

    private void Start()
    {
        fadeOut.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Activar el fade out al morir (poco notorio pero existe)
        if(other.tag == "Malo")
        {
            print("Muerto");
            vanderaMuerte = true;
            fadeOut.SetActive(true);
        }
        
    }

    private void Update()
    {
        //Tiempo desde que muero hasta que cambia de escena cuando muero dando tiempo a que se ejecute el fade out
        if (vanderaMuerte == true)
        {
            contador = contador + Time.deltaTime*2;
            print(contador);
            if (contador >= 1f)
            {
                //Cambio a escena y fin de muerte
                SceneManager.LoadScene("MenuMuerte");
                contador = 0f;
                vanderaMuerte = false;
            }
        }
    }
}
