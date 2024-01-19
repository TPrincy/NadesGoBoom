using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NadeDmg : MonoBehaviour
{

    public ParticleSystem particalHit;
    void Start()
    {
        particalHit = GetComponent<ParticleSystem>();
        print(particalHit);
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Enemy")
        {
            print("hit");
        }
    }
}
