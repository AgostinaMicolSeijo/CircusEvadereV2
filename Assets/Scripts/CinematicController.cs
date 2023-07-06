using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicController : MonoBehaviour
{
    [SerializeField] float textSpeed;
    [SerializeField] float contador = 0f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, textSpeed, 0) * Time.deltaTime;

        contador = contador + Time.deltaTime;

        if(contador>=10)
        {
            SceneManager.LoadScene("CarabanaMaldita");
            contador = 0;
        }
    }
}
