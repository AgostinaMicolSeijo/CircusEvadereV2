using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
   
    
   
    private void OnMouseDown()
    {
        if (!Gamecontrol.Win )
        {
            transform.Rotate(0f, 0f, 90f);
        }
    }
    
}
