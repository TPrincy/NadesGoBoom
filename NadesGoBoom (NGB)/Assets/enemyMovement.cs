using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class enemyMovement : MonoBehaviour
{

    public NavMeshAgent agent;
    public float range;
    public float shootingDistance;

    public Transform centrePoint;
    public Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        shootingDistance = agent.stoppingDistance;
    }

    private void Update()
    {
        randomMovement();
        agroRange();
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit Hit;
        if(NavMesh.SamplePosition(randomPoint, out Hit, 1.0f, NavMesh.AllAreas))
        {
            result = Hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    private void randomMovement()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.SetDestination(point);
            }
        }
    }

    private void agroRange()
    {
        if(target != null)
        {
            bool inRange = Vector3.Distance(transform.position, target.position) <= shootingDistance;

            if (inRange)
            {
                LookAtTarget();
            }
            else
            {
                UpdatePath();
            }
        }
    }

    private void LookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    private void UpdatePath()
    {
        
    }
}
