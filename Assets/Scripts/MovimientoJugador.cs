using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MovimientoJugador : MonoBehaviour
{
    public CharacterController controler;
    public float velocidad = 5f;
    public float correr = 6f;

    public bool estaCorriendo = false;

    public float gravedad = -20f;
    public float alturaDeSalto = 3f;

    public Transform groundCheck;
    public float distanciaPiso = 0.3f;
    public LayerMask groundMask;

   // [SerializeField] GameObject pepeCamina;
   // [SerializeField] GameObject pepeCorre;

    Vector3 rapidez;

    bool estamosEnPasto;

    float duracion = 0f;
    float tiempoEspera = 4.5f;

    public AudioSource Clip;

    //[SerializeField] Animation movimiento;
    void Start()
    {
        //movimiento.SetActive(false);

        /*
        pepeCamina.SetActive(false);
        pepeCorre.SetActive(false);
        */
    }

    void Update()
    {

        estamosEnPasto = Physics.CheckSphere(groundCheck.position, distanciaPiso, groundMask);
        if (estamosEnPasto && rapidez.y < 0)
        {
            rapidez.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        //move.Normalize();
        if(x > 1 || z > 1)
        {
            move.Normalize();
        }

        controler.Move(move * velocidad * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) && estaCorriendo == false)
        {
            controler.Move(move * correr * Time.deltaTime);
            //movimiento.SetActive(true);
            duracion = duracion + Time.deltaTime;


            if (duracion >= 4)
            {
                tiempoEspera = 4.5f;
                //print("tiempo de espera" + tiempoEspera);
                //movimiento.SetActive(false);
                estaCorriendo = true;
                Clip.Play();

            }
            //

        }

        /*else
        { cambio de mecanica
            duracion = 0f;
        }*/
        if (estaCorriendo == true)
        {
            tiempoEspera = tiempoEspera - Time.deltaTime;
            //print("resta" + tiempoEspera);
            //movimiento.SetActive(false);
            if(tiempoEspera <= 0f)
            {
                //movimiento.SetActive(true);
                estaCorriendo = false;
                duracion = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && estamosEnPasto)
        {
            rapidez.y = Mathf.Sqrt(alturaDeSalto * -1 * gravedad);
        }

        rapidez.y += gravedad * Time.deltaTime;

        controler.Move(rapidez*Time.deltaTime);

        /*
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            //movimiento.SetActive(false);
        }*/
    }
}
