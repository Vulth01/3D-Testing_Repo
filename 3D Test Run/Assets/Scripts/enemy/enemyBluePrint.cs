using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBluePrint : MonoBehaviour
{
    protected int health;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnCollisionEnter(Collision collisionInfo)
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamaged(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            die();
        }
    }
    protected void die()
    {
        Debug.Log("enemy died");
        Destroy(gameObject);
    }
}
