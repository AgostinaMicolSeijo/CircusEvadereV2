using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NegrelioIA : MonoBehaviour
{
    //el objetivo: player
    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _agent;
    

    //rangos
    [SerializeField] private float _rangoactual;
    [SerializeField] private float _radius;
    [SerializeField] private float _radius2;
    [SerializeField] private GameObject _bolacorrer;
    [SerializeField] private GameObject _bolacaminar;
    [SerializeField] private float _radioescuchar;
    [SerializeField] private float _radiusCerca;

    //array
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _offset;
    [SerializeField] private int _arraynumber = 0;
    Vector3 _nextWaypoint;

    //velocidades
    [SerializeField] private float _velocitynormal;
    [SerializeField] private float _persecucion;

    private void Awake()
    {
        _rangoactual = _radius;
        _nextWaypoint = _waypoints[0].position;
    }

    void Update()
    {
        if ((_bolacorrer.activeInHierarchy|| _bolacaminar.activeInHierarchy) && Vector3.Distance(transform.position, _target.position) <= _radioescuchar)
        {
            _rangoactual = _radius2;
            _agent.speed = _persecucion;
 
        }
        else
        {
            _rangoactual = _radius;
            _agent.speed = _velocitynormal;
        }

        if (Vector3.Distance(transform.position, _target.position) <= _rangoactual &&
            ( _bolacorrer.activeInHierarchy || _bolacaminar.activeInHierarchy) 
            || Vector3.Distance(transform.position, _target.position) <= _radiusCerca)
        {        
              _agent.SetDestination(_target.position);
        }
        else
        {
            _agent.SetDestination(_nextWaypoint);
            if (Vector3.Distance(transform.position, _nextWaypoint) <= _offset)
            {

                _arraynumber++;
                _nextWaypoint = _waypoints[_arraynumber].position;
                if (_arraynumber >= _waypoints.Length - 1)
                {
                    print("paso el array negrelio");
                    _arraynumber = -1;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, _rangoactual);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _radioescuchar);
        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(transform.position, _radiusCerca);

    }
}
