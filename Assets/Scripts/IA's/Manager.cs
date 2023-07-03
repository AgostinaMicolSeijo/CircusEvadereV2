using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // prefabs
    [SerializeField] private GameObject _prefabN;
    [SerializeField] private GameObject _prefabR;

    //rangos
    [SerializeField] private float _rango;

    //referencias
    [SerializeField] private Transform _targetPepito;


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_targetPepito);
    }
}
