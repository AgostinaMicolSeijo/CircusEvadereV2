using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamecontrol : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures;
  //  public GameObject Fine;
    public static bool Win;
  //  public GameObject Luz;

    private void Start()
    {
        Win = false;
    }

    public void Update()
    {  
      if (pictures[0].rotation.z == 0 &&
            pictures[1].rotation.z == 0 &&
            pictures[2].rotation.z == 0 &&
            pictures[3].rotation.z == 0 &&
            pictures[4].rotation.z == 0 &&
            pictures[5].rotation.z == 0 &&
            pictures[6].rotation.z == 0 &&
            pictures[7].rotation.z == 0 &&
            pictures[8].rotation.z == 0)
        {
            Win = true;
          //  Fine.SetActive(true);
          //  Luz.SetActive(true);
          
        }




    }






}
