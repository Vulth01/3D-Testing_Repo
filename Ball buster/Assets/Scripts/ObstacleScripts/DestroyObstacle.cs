using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : Obstacle
{
    void Awake()
    {

        SetUpFunct();

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayCollisionSound(collision);
        PlayCollisionSound(collision);
        if (collision.collider.tag == "Ball")
        {
            Destroy(collision.collider);
        }



    }
}
