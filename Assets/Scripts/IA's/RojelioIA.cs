using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RojelioIA : MonoBehaviour
{
    //el objetivo: player
    public Transform target;
    // la linterna
    public GameObject luz;
    public NavMeshAgent agent;
    public Transform enemy;
    //  public Transform escondite;
    // variables para rangos segun sea necesario. Y velocidades
    //  public float rangoescondite;
    public float radius;
    public float rangoactual;
    public float rangolinterna;
    public float velocidadnormal;
    public float velocidadmaxima;
    [SerializeField] Transform[] _waypoints;
    Vector3 _nextWaypoint;
    [SerializeField] float _offset;
    [SerializeField] int _arraynumber = 0;

    /* se asigna que el rango actual sea igual al "radius" al cual se le asigna desde el inspector
      para por modificarlo en tiempo real  */
    private void Awake()
    {
        rangoactual = radius;
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
        if (!luz)
        {
            return;
        }
        /* si la distancia entre el enemigo y el player es menor al rango actual 
         se persigue mediante el navmesh. En caso de estar al borde del rango el navmesh aumenta su 
         velocidad, de lo contrario vuelve a su velocidad normal*/
        if (Vector3.Distance(transform.position, target.position) <= rangoactual /* && Vector3.Distance(transform.position, escondite.position) >= rangoescondite*/)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            agent.SetDestination(_nextWaypoint);
            if (Vector3.Distance(transform.position, _nextWaypoint) <= _offset)
            {

                _arraynumber++;
                _nextWaypoint = _waypoints[_arraynumber].position;
                if (_arraynumber >= _waypoints.Length -1)
                {
                    print("paso el array");
                    _arraynumber = -1;
                }
            }
            // en caso de que el jugador no este en su rango, el enemigo patrulla a una velocidad x
            /* if (Vector3.Distance(transform.position, target.position) >= rangoactual)
           {
               agent.SetDestination(_nextWaypoint);
               if (Vector3.Distance(transform.position, _nextWaypoint) <= _offset)
               {

                       _arraynumber++;
                       _nextWaypoint = _waypoints[_arraynumber].position;
                   if (_arraynumber >= _waypoints.Length -1)
                   {
                       print("paso el array");
                       _arraynumber = 0;
                   }
               }
            */
        }



        if (Vector3.Distance(transform.position, target.position) >= rangoactual - 5)
        {
            agent.speed = velocidadmaxima;
        }
        else
        {
            agent.speed = velocidadnormal;
        }
        /* si la linterna esta prendida el rango de deteccion del enemigo aumenta, si se apaga vuelve a la normalidad */
        if (luz.activeInHierarchy)
        {
            rangoactual = rangolinterna;
        }
        else
        {
            rangoactual = radius;
        }



    }
    // se genera un gizmo de color rojo para marcar el rango de deteccion del enemigo
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemy.position, rangoactual);
        // Gizmos.color = Color.green;
        // Gizmos.DrawSphere(escondite.position, rangoescondite);
    }
    public void SetterWaypoints(Transform[] value)
    {
        _waypoints = value;
    }
    public void SetterReference(Transform _target,GameObject _luz)
    {
        target = _target;
        luz = _luz;
    }
}
