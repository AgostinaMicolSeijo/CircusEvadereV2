using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Update()
    {

    }
    public void Jugar()
    {
        SceneManager.LoadScene("CarabanasMalditas");
    }

    public void Salir()
    {
        Application.Quit();
        print("Salir");
    }
}
