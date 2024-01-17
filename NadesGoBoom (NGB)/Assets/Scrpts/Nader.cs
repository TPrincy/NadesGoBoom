using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nader : MonoBehaviour
{

    [SerializeField] Transform NadeSpawner;
    [SerializeField] GameObject Nade;

    [SerializeField] float nadePower = 50f;
    [SerializeField] float yPower = 10f;

    

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject nadeShot = Instantiate(Nade, NadeSpawner);
            nadeShot.transform.parent = null;
            //currently nade spawns no where near where the spawner is located for some reason
            
            Rigidbody currentlyShot = nadeShot.GetComponent<Rigidbody>();
            Vector3 finalDirection = Camera.main.transform.forward;
            finalDirection = finalDirection + Camera.main.transform.up * yPower;
            currentlyShot.AddForce(finalDirection * nadePower, ForceMode.Impulse);

        }

    }
}
