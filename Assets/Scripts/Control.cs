using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] private float camaradistance;
    [SerializeField] private GameObject camara;
  
    public void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, camaradistance))
        { 
            if (hit.transform.CompareTag("2d") )
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!Gamecontrol.Win)
                    {
                     transform.Rotate(0f, 0f, 90f);

                    }
                }
            }

        }
    }



}
