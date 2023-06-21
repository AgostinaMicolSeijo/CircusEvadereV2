using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCamara : MonoBehaviour
{
    Transform camara;
    public Vector2 sensibilidad;

    //Slider

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Start()
    {
        camara = transform.Find("Camera");

    }

    void Update()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        if (hor != 0)
        {
            transform.Rotate(Vector3.up*hor*sensibilidad.x);
        }
        if (ver != 0)
        {
            //camara.Rotate(Vector3.left * ver * sensibilidad.y);
            float angle = (camara.localEulerAngles.x - ver*sensibilidad.y + 360) % 360;
            if (angle > 180)
            {
                angle -= 360;
            }
            angle = Mathf.Clamp(angle, -80, 80);
            camara.localEulerAngles = Vector3.right * angle;
        }
    }
}
