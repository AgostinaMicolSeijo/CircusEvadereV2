using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinDelJuego : MonoBehaviour
{
    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void Salir()
    {
        Application.Quit();
        print("Salir");
    }

}
