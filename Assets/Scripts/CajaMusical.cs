using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaMusical : MonoBehaviour
{
    [SerializeField] Camera camara;
    [SerializeField] int distanciaRayo;

    [SerializeField] GameObject palanca;

    //Palancas con animaciones
    [SerializeField] GameObject palancaUno;
    //[SerializeField] GameObject palancaDos;
    //[SerializeField] GameObject palancaTres;

    //Baterias de la caja
    [SerializeField] GameObject bateriaUno;
    [SerializeField] GameObject bateriaDos;
    [SerializeField] GameObject bateriaTres;

    //Baterias coleccionables
    [SerializeField] GameObject bateriaColeccionableUno;
    [SerializeField] GameObject bateriaColeccionableDos;
    [SerializeField] GameObject bateriaoleccionableTres;

    // Se abre la caja musical
    //[SerializeField] GameObject tapaCajaMusical;
    //[SerializeField] GameObject tapaCajaMusicalCerrada;

    // LLave
    //[SerializeField] GameObject llave;

    // contador de baterias
    int contadorBaterias = 0;

    //Baterias puestas
    int bateriaPuestaUno = 0;
    int bateriaPuestaDos = 0;
    int bateriaPuestaTres = 0;

    // Textos "press e"
   /* [SerializeField] GameObject textoBateriaUno;
    [SerializeField] GameObject textoBateriaDos;
    [SerializeField] GameObject textoBateriaTres;

    [SerializeField] GameObject textoCajaMusicalUno;
    [SerializeField] GameObject textoCajaMusicalDos;
    [SerializeField] GameObject textoCajaMusicalTres;

    [SerializeField] GameObject textoPalancaUno;*/
    //[SerializeField] GameObject textoPalancaDos;

    //[SerializeField] GameObject textoLlave;

    //llave
    //[SerializeField] GameObject llaveCajaMusical;

    //carteles y puertas
    [SerializeField] GameObject rejapuertapuzzleUno;
    [SerializeField] GameObject rejapuertapuzzleDos;

    [SerializeField] GameObject rejapuertapuzzleUnoAnimada;
    [SerializeField] GameObject rejapuertapuzzleDosAnimada;

    [SerializeField] GameObject cartelUno;
    [SerializeField] GameObject cartelDos;

    [SerializeField] GameObject cartelUnoAnimado;
    [SerializeField] GameObject cartelDosAnimado;

    //cancion
    [SerializeField] AudioSource sonidoCajaMusical;
    void Start()
    {
        /*textoBateriaUno.SetActive(false);
        textoBateriaDos.SetActive(false);
        textoBateriaTres.SetActive(false);

        textoCajaMusicalUno.SetActive(false);
        textoCajaMusicalDos.SetActive(false);
        textoCajaMusicalTres.SetActive(false);*/
        //textoLlave.SetActive(false);

        //textoPalancaUno.SetActive(false);
        //textoPalancaDos.SetActive(false);

        palanca.SetActive(true);

        palancaUno.SetActive(false);
        //palancaDos.SetActive(false);
        //palancaTres.SetActive(false);

        bateriaUno.SetActive(false);
        bateriaDos.SetActive(false);
        bateriaTres.SetActive(false);

        //tapaCajaMusical.SetActive(false);
        //tapaCajaMusicalCerrada.SetActive(true);

        //llave.SetActive(false);

        //cartelesy puertas
        rejapuertapuzzleUnoAnimada.SetActive(false);
        rejapuertapuzzleDosAnimada.SetActive(false);

        rejapuertapuzzleUno.SetActive(true);
        rejapuertapuzzleDos.SetActive(true);
        
        cartelUno.SetActive(true);
        cartelDos.SetActive(true);

        cartelUnoAnimado.SetActive(false);
        cartelDosAnimado.SetActive(false);

    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, distanciaRayo))
        {

            //Agarrar Baterias
            if (hit.transform.CompareTag("bateriaUno"))
            {
               // textoBateriaUno.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    bateriaColeccionableUno.SetActive(false);
                    bateriaPuestaUno = bateriaPuestaUno + 1;

                    //textoBateriaUno.SetActive(false);
                }
            }

            if (hit.transform.CompareTag("bateriaDos"))
            {
               // textoBateriaDos.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    bateriaColeccionableDos.SetActive(false);
                    bateriaPuestaDos = bateriaPuestaDos + 1;

                    //textoBateriaDos.SetActive(false);
                }
            }

            if (hit.transform.CompareTag("bateriaTres"))
            {
                //textoBateriaTres.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    bateriaoleccionableTres.SetActive(false);
                    bateriaPuestaTres = bateriaPuestaTres + 1;

                   // textoBateriaTres.SetActive(false);
                }
            }

            //Poner Baterias en la Caja
            if (hit.transform.CompareTag("CajaMusical") && bateriaPuestaUno >= 1)
            {
                //textoCajaMusicalUno.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    bateriaUno.SetActive(true);
                    contadorBaterias = contadorBaterias + 1;
                    bateriaPuestaUno = 0;

                    //textoCajaMusicalUno.SetActive(false);
                }
            }

            if (hit.transform.CompareTag("CajaMusical") && bateriaPuestaDos >= 1)
            {
               // textoCajaMusicalDos.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    bateriaDos.SetActive(true);
                    contadorBaterias = contadorBaterias + 1;
                    bateriaPuestaDos = 0;

                    //textoCajaMusicalDos.SetActive(false);
                }
            }

            if (hit.transform.CompareTag("CajaMusical") && bateriaPuestaTres >= 1)
            {
               // textoCajaMusicalTres.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    bateriaTres.SetActive(true);
                    contadorBaterias = contadorBaterias + 1;
                    bateriaPuestaTres = 0;

                   // textoCajaMusicalTres.SetActive(false);
                }
            }

            if (contadorBaterias >= 3)
            {
                palanca.SetActive(false);
                palancaUno.SetActive(true);

                contadorBaterias = 0;

                rejapuertapuzzleUnoAnimada.SetActive(true);
                rejapuertapuzzleDosAnimada.SetActive(true);

                rejapuertapuzzleUno.SetActive(false);
                rejapuertapuzzleDos.SetActive(false);

                cartelUno.SetActive(false);
                cartelDos.SetActive(false);

                cartelUnoAnimado.SetActive(true);
                cartelDosAnimado.SetActive(true);

                sonidoCajaMusical.Play();

                //tapaCajaMusical.SetActive(true);
                //tapaCajaMusicalCerrada.SetActive(false);

                //llave.SetActive(true);

                //textoPalancaDos.SetActive(false);
            }

            /*if (hit.transform.CompareTag("llaveCaja"))
            {
                textoLlave.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    textoLlave.SetActive(false);
                }
            }*/
        }

       /* else
        {
            //textoBateriaUno.SetActive(false);
        }*/
    }
}
