using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamecontrol : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures;
  //  public GameObject Fine;
    public static bool Win;
    //  public GameObject Luz;


    //intervencion de peke:
    [SerializeField] GameObject cofreCerrado;
    [SerializeField] GameObject cofreAnimado;
    //[SerializeField] GameObject llave;

    bool vanderaActivar = false;
    //fin xd

    private void Start()
    {
        Win = false;

        //intervencion de peke
        cofreCerrado.SetActive(true);
        cofreAnimado.SetActive(false);
        //llave.SetActive(false);
        // fin xd
    }

    public void Update()
    {  
      if (pictures[0].rotation.z == 0 &&
            pictures[1].rotation.z == 0 &&
            pictures[2].rotation.z == 0 &&
            pictures[3].rotation.z == 0 &&
            pictures[4].rotation.z == 0 &&
            pictures[5].rotation.z == 0 &&
            pictures[6].rotation.z == 0 &&
            pictures[7].rotation.z == 0 &&
            pictures[8].rotation.z == 0)
        {
            Win = true;
            //  Fine.SetActive(true);
            //  Luz.SetActive(true);
            vanderaActivar = true;

        }

      //intervencion de peke:
        if(vanderaActivar == true)
        {
            cofreCerrado.SetActive(false);
            cofreAnimado.SetActive(true);
            //llave.SetActive(true);
        }
      //fin xd

    }






}
