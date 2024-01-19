using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float dieTime = 5f;
    public GameObject collisionExplosion;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.TryGetComponent<enemyHealth>(out enemyHealth enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }
        else if (collision.gameObject.TryGetComponent<WallHealth>(out WallHealth wallComponent))
        {
            wallComponent.TakeWallDamage(1);
        }
        else if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Enemy")
        {
            GameObject explosion = (GameObject)Instantiate(collisionExplosion, transform.position, transform.rotation);
            print("miss");
            Destroy(gameObject);
            Destroy(explosion, 5f);
            return;
        }
    }
}
