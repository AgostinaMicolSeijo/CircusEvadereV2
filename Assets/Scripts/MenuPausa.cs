 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public bool pause;
    public GameObject pauseMenu;
    public void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            pauseMenu.SetActive(!pause);
        }

        if(pauseMenu == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if(pauseMenu == false)
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
