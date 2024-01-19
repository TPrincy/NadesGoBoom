using Mono.Cecil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nader : MonoBehaviour
{

    [SerializeField] Transform NadeSpawner;
    [SerializeField] GameObject Nade;

    [SerializeField] float nadePower;
    [SerializeField] float yPower;
    [SerializeField] float nadeDMG;
    
    public int  currentAmmoCount, maxAmmoCount = 6, currentAmmoReserve, maxAmmoReserveSize = 36;


    GameObject nadeShot;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }



    private void Fire()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmoCount > 0)
        {
            nadeShot = Instantiate(Nade, NadeSpawner);
            nadeShot.transform.parent = null;
            SetPosition();

            Rigidbody currentlyShot = nadeShot.GetComponent<Rigidbody>();
            Vector3 finalDirection = Camera.main.transform.forward;
            finalDirection = finalDirection + Camera.main.transform.up * yPower;
            currentlyShot.AddForce(finalDirection * nadePower, ForceMode.Impulse);
            currentAmmoCount--;


        }
    }

    void SetPosition()
    {
        nadeShot.transform.position = NadeSpawner.transform.position;
    }

    public void Reload()
    {
        int reloadAmount = maxAmmoCount - currentAmmoCount;
        reloadAmount = (currentAmmoReserve - reloadAmount) >= 0 ? reloadAmount : currentAmmoReserve;
        currentAmmoCount += reloadAmount;
        currentAmmoReserve -= reloadAmount;
    }

    public void AddAmmo(int ammoAmount)
    {
        currentAmmoReserve += ammoAmount;
        if(currentAmmoReserve > maxAmmoReserveSize)
        {
            currentAmmoReserve = maxAmmoReserveSize;
        }
    }

    private void Explode()
    {

    }
    

    




}
