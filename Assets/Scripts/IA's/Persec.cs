using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Persec : MonoBehaviour
{

    //el objetivo: player

    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _agent;
    //rangos
    [SerializeField] private float _rangoActualizado;
    [SerializeField] private float _rango;
    //gameobjects
    [SerializeField] private GameObject luz;

    //array
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _offset;
    [SerializeField] private int _arraynumber = 0;
    Vector3 _nextWaypoint;



}
