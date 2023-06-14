using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    [SerializeField] Transform camara;
    public float distanciaRayo = 5f;
    //engranajes a buscar
    [SerializeField] GameObject engranajeUno;
    [SerializeField] GameObject engranajeDos;
    [SerializeField] GameObject engranajeTres;
    //engranajes encontrados
    [SerializeField] GameObject engranajeUnoGenerador;
    [SerializeField] GameObject engranajeDosGenerador;
    [SerializeField] GameObject engranajeTresGenerador;

    [SerializeField] GameObject luzCirco;

    [SerializeField] GameObject textoEngranaje;

    int falsoUno = 0;
    int falsoDos = 0;
    int falsoTres = 0;

    int contadorEngranajes = 0;
    //Puzle 3 Luces

    [SerializeField] GameObject botonUno;
    [SerializeField] GameObject botonDos;
    [SerializeField] GameObject botonTres;

    [SerializeField] GameObject rojoUno;
    [SerializeField] GameObject rojoDos;
    [SerializeField] GameObject rojoTres;

    [SerializeField] GameObject amarilloUno;
    [SerializeField] GameObject amarilloDos;
    [SerializeField] GameObject amarilloTres;

    [SerializeField] GameObject verdeUno;
    [SerializeField] GameObject verdeDos;
    [SerializeField] GameObject verdeTres;


    [SerializeField] GameObject rojoUnoLuz;
    [SerializeField] GameObject rojoDosLuz;
    [SerializeField] GameObject rojoTresLuz;

    [SerializeField] GameObject amarilloUnoLuz;
    [SerializeField] GameObject amarilloDosLuz;
    [SerializeField] GameObject amarilloTresLuz;

    [SerializeField] GameObject verdeUnoLuz;
    [SerializeField] GameObject verdeDosLuz;
    [SerializeField] GameObject verdeTresLuz;

    int primerBoton;
    int segundoBoton;
    int tercerBoton;

    int contadorRojo = 0;
    int contadorAmarillo = 0;
    int contadorVerde = 0;

    bool banderaBoton;
    bool banderaBotonDos;
    bool banderaBotonTres;

    [SerializeField] GameObject puerta;
    [SerializeField] GameObject puertaAbrir;
    //[SerializeField] GameObject puertaCerrar;

    [SerializeField] AudioSource botones;
    [SerializeField] AudioSource generador;

    private void Awake()
    {
        luzCirco.SetActive(false);
        generador.Play();

        //lucesPuzzle
        rojoUnoLuz.SetActive(false);
        rojoDosLuz.SetActive(false);
        rojoTresLuz.SetActive(false);

        amarilloUnoLuz.SetActive(false);
        amarilloDosLuz.SetActive(false);
        amarilloTresLuz.SetActive(false);

        verdeUnoLuz.SetActive(false);
        verdeDosLuz.SetActive(false);
        verdeTresLuz.SetActive(false);
    }

    void Start()
    {
        engranajeUno.SetActive(true);
        engranajeDos.SetActive(true);
        engranajeTres.SetActive(true);

        engranajeUnoGenerador.SetActive(false);
        engranajeDosGenerador.SetActive(false);
        engranajeTresGenerador.SetActive(false);


        textoEngranaje.SetActive(false);

        //botones
        rojoUno.SetActive(false);
        rojoDos.SetActive(false);
        rojoTres.SetActive(false);

        amarilloUno.SetActive(false);
        amarilloDos.SetActive(false);
        amarilloTres.SetActive(false);

        verdeUno.SetActive(false);
        verdeDos.SetActive(false);
        verdeTres.SetActive(false);
        //Activadores
        banderaBoton = true;
        banderaBotonDos = true;
        banderaBotonTres = true;

        //puertas
        puerta.SetActive(true);
        puertaAbrir.SetActive(false);
        //puertaCerrar.SetActive(false);
    }

    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, distanciaRayo))
        {
            //agarrar engranajes
            if (hit.transform.CompareTag("engranajeUno"))
            {
                textoEngranaje.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    engranajeUno.SetActive(false);
                    falsoUno = falsoUno + 1;
                    /*
                    contadorEngranajes = contadorEngranajes + 1;
                    engranajeUnoGenerador.SetActive(true);
                    */

                    textoEngranaje.SetActive(false);
                }
            }
            if (hit.transform.CompareTag("engranajeDos"))
            {
                textoEngranaje.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    engranajeDos.SetActive(false);
                    falsoDos = falsoDos + 1;
                    /*
                    contadorEngranajes = contadorEngranajes + 1;
                    engranajeDosGenerador.SetActive(true);
                    */

                    textoEngranaje.SetActive(false);
                }

            }
            if (hit.transform.CompareTag("engranajeTres"))
            {
                textoEngranaje.SetActive(true);
                falsoTres = falsoTres + 1;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    engranajeTres.SetActive(false);
                    /*
                    contadorEngranajes = contadorEngranajes + 1;
                    engranajeTresGenerador.SetActive(true);
                    */

                    textoEngranaje.SetActive(false);
                }
            }

            //Poner engranajes
            if (hit.transform.CompareTag("Detector") && falsoUno >= 1)
            {
                textoEngranaje.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    engranajeUnoGenerador.SetActive(true);
                    contadorEngranajes = contadorEngranajes + 1;

                    textoEngranaje.SetActive(false);
                }
            }

            if (hit.transform.CompareTag("Detector") && falsoUno < 1)
            {
                textoEngranaje.SetActive(false);
            }

            if (hit.transform.CompareTag("Detector") && falsoDos >= 1)
            {
                textoEngranaje.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    engranajeDosGenerador.SetActive(true);
                    contadorEngranajes = contadorEngranajes + 1;

                    textoEngranaje.SetActive(false);
                }
            }

            if (hit.transform.CompareTag("Detector") && falsoDos < 1)
            {
                textoEngranaje.SetActive(false);
            }

            if (hit.transform.CompareTag("Detector") && falsoTres >= 1)
            {
                print("Mira el generador");
                textoEngranaje.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    engranajeTresGenerador.SetActive(true);
                    contadorEngranajes = contadorEngranajes + 1;

                    textoEngranaje.SetActive(false);
                }
            }

            if (hit.transform.CompareTag("Detector") && falsoTres < 1)
            {
                textoEngranaje.SetActive(false);
            }

            if(contadorEngranajes >= 3)
            {
                banderaBoton = true;
                luzCirco.SetActive(true);
            }
            if(hit.transform.CompareTag("boton") && banderaBoton == true)
            {
                textoEngranaje.SetActive(true);
                print("Mira boton");
                //primer boton

                if (Input.GetKeyDown(KeyCode.E))
                {
                    botones.Play();
                    primerBoton = Random.Range(1, 4);
                    //print(primerBoton);

                    if (primerBoton == 1)
                    {
                        //rojo
                        rojoUno.SetActive(true);
                        amarilloUno.SetActive(false);
                        verdeUno.SetActive(false);
                        rojoUnoLuz.SetActive(true);

                        contadorRojo = contadorRojo + 1;
                        banderaBoton = false;
                    }

                    if (primerBoton == 2)
                    {
                        //amarillo
                        amarilloUno.SetActive(true);
                        rojoUno.SetActive(false);
                        verdeUno.SetActive(false);
                        amarilloUnoLuz.SetActive(true);

                        contadorAmarillo = contadorAmarillo + 1;
                        banderaBoton = false;
                    }

                    if (primerBoton == 3)
                    {
                        //verde
                        verdeUno.SetActive(true);
                        rojoUno.SetActive(false);
                        amarilloUno.SetActive(false);
                        verdeUnoLuz.SetActive(true);

                        contadorVerde = contadorVerde + 1;
                        banderaBoton = false;
                    }
                }
            }
            if (hit.transform.CompareTag("boton2") && banderaBotonDos == true)
            {
                //segundo boton
                textoEngranaje.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    botones.Play();
                    segundoBoton = Random.Range(1, 4);

                    if (segundoBoton == 1)
                    {
                        //rojo
                        rojoDos.SetActive(true);
                        amarilloDos.SetActive(false);
                        verdeDos.SetActive(false);

                        if (contadorRojo >= 1)
                        {
                            contadorRojo = contadorRojo + 1;
                            banderaBotonDos = false;
                            rojoDosLuz.SetActive(true);
                        }
                    }

                    if (segundoBoton == 2)
                    {
                        //amarillo
                        amarilloDos.SetActive(true);
                        rojoDos.SetActive(false);
                        verdeDos.SetActive(false);

                        if (contadorAmarillo >= 1)
                        {
                            contadorAmarillo = contadorAmarillo + 1;
                            banderaBotonDos = false;
                            amarilloDosLuz.SetActive(true);
                        }
                    }

                    if (segundoBoton == 3)
                    {
                        //verde
                        verdeDos.SetActive(true);
                        amarilloDos.SetActive(false);
                        rojoDos.SetActive(false);

                        if (contadorVerde >= 1)
                        {
                            contadorVerde = contadorVerde + 1;
                            banderaBotonDos = false;
                            verdeDosLuz.SetActive(true);
                        }
                    }
                }
            }
            if (hit.transform.CompareTag("boton3") && banderaBotonTres == true)
            {
                //tercer Boton
                textoEngranaje.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    botones.Play();
                    tercerBoton = Random.Range(1, 4);

                    if (tercerBoton == 1)
                    {
                        //rojo
                        rojoTres.SetActive(true);
                        amarilloTres.SetActive(false);
                        verdeTres.SetActive(false);

                        if (contadorRojo >= 2)
                        {
                            contadorRojo = contadorRojo + 1;
                            banderaBotonTres = false;
                            rojoTresLuz.SetActive(true);
                        }
                    }

                    if (tercerBoton == 2)
                    {
                        //amarillo
                        amarilloTres.SetActive(true);
                        rojoTres.SetActive(false);
                        verdeTres.SetActive(false);

                        if (contadorAmarillo >= 2)
                        {
                            contadorAmarillo = contadorAmarillo + 1;
                            banderaBotonTres = false;
                            amarilloTresLuz.SetActive(true);
                        }
                    }

                    if (tercerBoton == 3)
                    {
                        //verde
                        verdeTres.SetActive(true);
                        rojoTres.SetActive(false);
                        amarilloTres.SetActive(false);

                        if (contadorVerde >= 2)
                        {
                            contadorVerde = contadorVerde + 1;
                            banderaBotonTres = false;
                            verdeTresLuz.SetActive(true);
                        }
                    }
                }
            }
        }
        //abrir puertas
        if (contadorRojo >= 3 || contadorAmarillo >= 3 || contadorVerde >= 3)
        {
            puerta.SetActive(false);
            puertaAbrir.SetActive(true);
        }

        else
        {
            
            textoEngranaje.SetActive(false);
        }
        
    }
}
