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
    [SerializeField] private GameObject _runningBall;
    [SerializeField] private GameObject _bolacaminar;
    [SerializeField] private float _radioescuchar;
    [SerializeField] private float _radiusCerca;
    [SerializeField] private float _radiusCorrer;

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
        if (_waypoints.Length > 0)
        {
            SetterPosition();
        }
    }
    public void SetterPosition()
    {
        _nextWaypoint = _waypoints[0].position;

    }

    void Update()
    {
        if (!_runningBall)
        {
            return;
        }
        
        if ((_runningBall.activeInHierarchy) && Vector3.Distance(transform.position, _target.position) <= _radioescuchar)
        {
            _rangoactual = _radiusCorrer;
            _agent.speed = _persecucion;
 
        }
        else
        {
            _rangoactual = _radius;
            _agent.speed = _velocitynormal;
        }

        if (Vector3.Distance(transform.position, _target.position) <= _rangoactual &&
            (_runningBall.activeInHierarchy || _bolacaminar.activeInHierarchy) 
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
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _radiusCorrer);

    }
    public void SetterWaypoints(Transform[] value)
    {
        _waypoints = value;
    }
    public void SetterReference(Transform target, GameObject bolacorrer, GameObject bolacaminar)
    {
        _target = target;
        _runningBall = bolacorrer;
        _bolacaminar = bolacaminar;
    }
}
