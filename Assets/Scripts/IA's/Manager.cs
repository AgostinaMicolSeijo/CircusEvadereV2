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
    [SerializeField] private float _rangoVisionAumentado;
    [SerializeField] private float _rangoVisionOriginal;

    //referencias
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _targetPepito;
    [SerializeField] private Transform _spawnN;
    [SerializeField] private Transform _spawnR;

    //array
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _offset;
    [SerializeField] private int _arraynumber = 0;
    Vector3 _nextWaypoint;

    //timer
    [SerializeField] private float _timer;

    private void Awake()
    {
        _timer = 0;
        _nextWaypoint = _waypoints[0].position;
        _agent.speed = 3;
    }

    void Update()
    {
        if ((_bolacorrer.activeInHierarchy) && Vector3.Distance(transform.position, _targetPepito.position) <= _rangoAudicioncorrer)
        {
            transform.LookAt(_targetPepito);
            _rangoVision = _rangoVisionAumentado;

        }
        else
        {
            StartCoroutine("Tiempo_Vision");
            print("se activo corutina");
        }
        _agent.SetDestination(_nextWaypoint);
        if (Vector3.Distance(transform.position, _nextWaypoint) <= _offset)
        {

            _arraynumber++;
            _nextWaypoint = _waypoints[_arraynumber].position;
            if (_arraynumber >= _waypoints.Length - 1)
            {
                print("paso el array el manager");
                _arraynumber = -1;
            }
        }

        if (Vector3.Distance(transform.position, _targetPepito.position) <= _rangoVision)
        {
            
            if (_timer >= 7)
            {
                _timer = 0;
            }
            if (_timer == 0)
            {
              Instantiate(_prefabN, _spawnN.transform.position, _spawnN.transform.rotation);
                Instantiate(_prefabR, _spawnR.transform.position, _spawnR.transform.rotation);
            }
            _timer += Time.deltaTime;
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

    public IEnumerator Tiempo_Vision()
    {
        yield return new WaitForSeconds(3f);
        _rangoVision = _rangoVisionOriginal;
    }
   
}
