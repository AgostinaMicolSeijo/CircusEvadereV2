using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuerteMenu : MonoBehaviour
{
    public void Salir()
    {
        Application.Quit();
        print("Salir");
    }

    public void MuerteNivel1()
    {
        SceneManager.LoadScene("CarabanasMalditas");
    }

    public void MuerteNivel2()
    {
        SceneManager.LoadScene("CarpaMaldita");
    }
}
