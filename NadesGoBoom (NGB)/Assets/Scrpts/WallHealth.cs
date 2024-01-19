using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : MonoBehaviour
{

    [SerializeField] float Whealth, maxWhealth = 6f;


    void Start()
    {
        Whealth = maxWhealth;
    }

    public void TakeWallDamage(float damageAmount)
    {
        Whealth -= damageAmount;

        if (Whealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
