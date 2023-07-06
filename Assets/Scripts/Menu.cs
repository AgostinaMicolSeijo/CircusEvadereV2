using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject cinematicText;
    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void Jugar()
    {
        cinematicText.SetActive(true);
    }

    public void Salir()
    {
        Application.Quit();
        print("Salir");
    }
}
