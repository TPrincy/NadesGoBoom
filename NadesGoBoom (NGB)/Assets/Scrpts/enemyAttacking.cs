using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class enemyAttacking : MonoBehaviour
{
    private enemyMovement EnemyMovement;
    
    [SerializeField] Transform EnemyNadeSpawner;
    [SerializeField] GameObject EnemyNade;

    [SerializeField] float nadePower;
    [SerializeField] float yPower;
    [SerializeField] float nadeDMG;
    //[SerializeField] int ammoCount = 2;

    GameObject enemyNadeShot;


    private void Start()
    {
        EnemyMovement = GetComponent<enemyMovement>();
    }
    private void Update()
    {

        if (EnemyMovement.inShootingRange)
        {
            print("shooting shooting");
            enemyNadeShot = Instantiate(EnemyNade, EnemyNadeSpawner);
            enemyNadeShot.transform.parent = null;
            SetPosition();
            //currently nade spawns no where near where the spawner is located for some reason

            Rigidbody currentlyShot = enemyNadeShot.GetComponent<Rigidbody>();
            Vector3 finalDirection = EnemyNadeSpawner.transform.forward;    
            finalDirection = finalDirection +  Vector3.up * nadePower;
            currentlyShot.AddForce(finalDirection * nadePower, ForceMode.Impulse);

        }

    }

    void SetPosition()
    {
        enemyNadeShot.transform.position = EnemyNadeSpawner.transform.position;
    }
}
