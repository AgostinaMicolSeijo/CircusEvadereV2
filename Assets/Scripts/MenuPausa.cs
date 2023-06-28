 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public bool pause=false;
    public GameObject pauseMenu;
    public void Awake()
    {
        pauseMenu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print(pause);
            pause = !pause;
            pauseMenu.SetActive(pause);
        }

        if(pause != false)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if(pause == false)
        { 
            Cursor.lockState = CursorLockMode.Locked; 
        }     
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("MenuInicio");
    }
    public void Salir()
    {
        Application.Quit();
        print("Salir");
    }
    public void Return()
    {
        pauseMenu.SetActive(false);
    }
    
}
