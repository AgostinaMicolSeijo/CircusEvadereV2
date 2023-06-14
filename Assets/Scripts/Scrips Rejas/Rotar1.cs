using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar1 : MonoBehaviour
{
    public void OnMouseDown()
    {
        transform.Rotate(0f, 90f, 0f);
    }
}
