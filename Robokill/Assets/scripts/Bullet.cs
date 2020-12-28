using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  [HideInInspector]  public float bulletDmg;
    public GameObject hitEffect;
  void   OnCollisionEnter2D(Collision2D collisionInfo)
    {
       GameObject effect= Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, .5f);
        Destroy(gameObject);
    }
}
