using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Manager : MonoBehaviour
{
    // prefabs
    [SerializeField] private GameObject _prefabN;
    [SerializeField] private GameObject _prefabR;

    //rangos
    [SerializeField] private float _rangoVision;
    [SerializeField] private float _rangoAudicioncaminar;
    [SerializeField] private float _rangoAudicioncorrer;
    [SerializeField] private GameObject _bolacorrer;
    [SerializeField] private GameObject _bolacaminar;

    //referencias
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _targetPepito;


    void Update()
    {
        if ((_bolacorrer.activeInHierarchy) && Vector3.Distance(transform.position, _targetPepito.position) <= _rangoAudicioncorrer)
        {
            transform.LookAt(_targetPepito);
        }
        
    }

    private void OnDrawGizmos()
    {
        //Rango al ver
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _rangoVision);

        //Rango al escuchar caminar
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _rangoAudicioncaminar);

        //rango de escucha correr
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, _rangoAudicioncorrer);

    }
}
