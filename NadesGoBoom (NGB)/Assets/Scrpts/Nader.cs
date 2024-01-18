using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nader : MonoBehaviour
{

    [SerializeField] Transform NadeSpawner;
    [SerializeField] GameObject Nade;

    [SerializeField] float nadePower = 50f;
    [SerializeField] float yPower = 10f;
    [SerializeField] float nadeDMG = 2f;


    GameObject nadeShot;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            nadeShot = Instantiate(Nade, NadeSpawner);
            nadeShot.transform.parent = null;
            SetPosition();
            //currently nade spawns no where near where the spawner is located for some reason
            
            Rigidbody currentlyShot = nadeShot.GetComponent<Rigidbody>();
            Vector3 finalDirection = Camera.main.transform.forward;
            finalDirection = finalDirection + Camera.main.transform.up * yPower;
            currentlyShot.AddForce(finalDirection * nadePower, ForceMode.Impulse);

        }

    }

    void SetPosition()
    {
        nadeShot.transform.position = NadeSpawner.transform.position;
    }


}
