using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Nader nader = collision.gameObject.GetComponentInChildren<Nader>();
        if (nader)
        {
            nader.AddAmmo(nader.maxAmmoReserveSize);
            Destroy(gameObject);
        }
    }
}
