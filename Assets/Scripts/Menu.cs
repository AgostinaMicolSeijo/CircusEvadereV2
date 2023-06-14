using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void Jugar()
    {
        SceneManager.LoadScene("CarabanasMalditas");
    }

    public void Salir()
    {
        Application.Quit();
    }

    //public void VolverMenu()
    /*{
        SceneManager.LoadScene("MenuPrincipal");
    }*/

}
