using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class enemyMovement : MonoBehaviour
{

    public NavMeshAgent agent;
    
    [Header("Roaming")]
    public float range;
    public Transform centrePoint;

    private float shootingDistance;
    private float pathUpdateDeadline;    

    [Header("Stats")]
    public float pathUpdateDelay = 0.2f;

    [Header("Agro")]
    public Transform target;
    public float agroDistance;

    delegate void MoveFunc();
    MoveFunc Move;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        Move = DoRMove;
    }

    private void Start()
    {
        shootingDistance = agent.stoppingDistance;
    }

    private void Update()
    {
        
        
        if (target != null)
        {
            bool inAgroRange = Vector3.Distance(transform.position, target.position) <= agroDistance;
            bool inShootingRange = Vector3.Distance(transform.position, target.position) <= shootingDistance;

            if (inAgroRange)
            {
                LookAtTarget();
                Move = DontRMove;
                Move();
                
                if (inShootingRange)
                {
                    print("shooting");
                }
                else
                {
                    UpdatePath();
                }
            }
            else if(!inAgroRange && !inShootingRange)
            {
                Move = DoRMove;
                Move();
            }
        }
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

    private void DoRMove()
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

    private void DontRMove()
    {

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
        agent.SetDestination(target.position);
        print("Update Path");
    }
}
