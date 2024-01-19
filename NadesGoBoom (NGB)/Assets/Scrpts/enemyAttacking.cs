using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class enemyAttacking : MonoBehaviour
{
    private enemyMovement EnemyMovement;
    
    [SerializeField] Transform EnemyNadeSpawner;
    [SerializeField] GameObject EnemyNade;

    [SerializeField] float nadePower;
    [SerializeField] float yPower;
    [SerializeField] float nadeDMG;
    [SerializeField] private float fireRate = 2f;
    private float fireingCooldown = 0f;

    GameObject enemyNadeShot;


    private void Start()
    {
        EnemyMovement = GetComponent<enemyMovement>();
    }
    private void Update()
    {

        if (EnemyMovement.inShootingRange)
        {
            if(fireingCooldown <= 0)
            {
                enemyNadeShot = Instantiate(EnemyNade, EnemyNadeSpawner);
                enemyNadeShot.transform.parent = null;
                SetPosition();

                Rigidbody currentlyShot = enemyNadeShot.GetComponent<Rigidbody>();
                Vector3 finalDirection = EnemyNadeSpawner.transform.forward;
                finalDirection = finalDirection + Vector3.up * nadePower;
                currentlyShot.AddForce(finalDirection * nadePower, ForceMode.Impulse);

                fireingCooldown = 1f/fireRate;
            }
            fireingCooldown -= Time.deltaTime;

        }

    }

    void SetPosition()
    {
        enemyNadeShot.transform.position = EnemyNadeSpawner.transform.position;
    }

}
