using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarClavas : MonoBehaviour
{
    [SerializeField] GameObject handPoint;
     GameObject pickedObject = null;

    


    void Update()
    {
        if(pickedObject != null)
        {
            if(Input.GetKey(KeyCode.G))
            {
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;

                pickedObject.gameObject.transform.SetParent(null);
                pickedObject = null;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("pino"))
        {
            if(Input.GetKey(KeyCode.E))
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = handPoint.transform.position;
                other.gameObject.transform.SetParent(handPoint.gameObject.transform);
                pickedObject = other.gameObject;
            }
        }
    }
}
