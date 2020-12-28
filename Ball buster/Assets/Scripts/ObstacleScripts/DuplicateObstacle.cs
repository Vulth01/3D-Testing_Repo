using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateObstacle : Obstacle
{

    [SerializeField]
    int InstanceLives = 1;

    GameObject ballObj;
    public BallManager ballManager;
    [SerializeField]
    private float spawnSpeed = 600f;
    void Awake()
    {

        obstacleLives = InstanceLives;


        ballObj = FindObjectOfType<Ball>().gameObject;
        ballManager = FindObjectOfType<BallManager>();

        SetUpFunct();

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayCollisionSound(collision);
        if (collision.collider.tag == "Ball")
        {
            SpawnNewBall();
        }


    }
    void SpawnNewBall()
    {
       GameObject newBall= Instantiate(ballObj);
        Vector2 direction = (ballManager.playerTrans.position - ballManager.centerTrans.position);
       direction.Normalize();
        newBall.GetComponent<Rigidbody2D>().AddForce(direction * spawnSpeed);
    }
}
