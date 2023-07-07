using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaCarabana : MonoBehaviour
{
    [SerializeField] Camera camara;
    float distanciaRayo = 1f;

    [SerializeField] GameObject puerta;
    [SerializeField] GameObject puertaAbrir;
    [SerializeField] GameObject puertaCerrar;
    // Start is called before the first frame update
    void Start()
    {
        
        puertaAbrir.SetActive(false);
        puertaCerrar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, distanciaRayo, LayerMask.GetMask("puerta")))
        {
            if(Input.GetKey(KeyCode.E))
            {
                puerta.SetActive(false);
                puertaAbrir.SetActive(true);
            }
        }

        if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, distanciaRayo, LayerMask.GetMask("puertaAbrir")))
        {
            if (Input.GetKey(KeyCode.E))
            {
                puertaCerrar.SetActive(false);
                puertaAbrir.SetActive(true);
            }
        }

        if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, distanciaRayo, LayerMask.GetMask("puertaCerrar")))
        {
            if (Input.GetKey(KeyCode.E))
            {
                puertaCerrar.SetActive(true);
                puertaAbrir.SetActive(false);
            }
        }
    }
}
