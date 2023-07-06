using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SegundaMuertePepito : MonoBehaviour
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
    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Malo2")
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
            contador = contador + Time.deltaTime * 2;
            print(contador);
            if (contador >= 1.5f)
            {
                //Cambio a escena y fin de muerte
                SceneManager.LoadScene("MenuMuerte");
                contador = 0f;
                vanderaMuerte = false;
            }
        }
    }
}
