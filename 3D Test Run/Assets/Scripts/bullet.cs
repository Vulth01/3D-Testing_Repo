using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody rb;
    int damage;
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
    void OnCollisionEnter(Collision collisionInfo)
    {

        var enemy = collisionInfo.collider.GetComponent<enemyBluePrint>();
        if (enemy)
        {
            
            enemy.takeDamaged(damage);

            //  parachuteBullet();
        }
    }
    float paraTime = 0.5f;
    bool parachuting = false;
    void parachuteBullet()
    {
        Debug.Log("parachuting");
        rb.drag = 3;
        parachuting = true;
    }

    void stopParachute()
    {
        rb.drag = 0;
        parachuting = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!parachuting)
        {
            return;
        }

        if (paraTime > 0)
        {
            paraTime -= Time.deltaTime;
        }
        else
        {
            stopParachute();
        }
    }
}
