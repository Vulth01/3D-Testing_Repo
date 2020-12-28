using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicObstacle : Obstacle
{

    void Awake()
    {

        SetUpFunct();

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayCollisionSound(collision);


    }
}
