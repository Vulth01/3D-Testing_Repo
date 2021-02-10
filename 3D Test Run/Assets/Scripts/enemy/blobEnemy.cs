using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class blobEnemy : enemyBluePrint
{

    GameObject player;
    NavMeshAgent navAgent;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerMovement>().gameObject;
        navAgent = GetComponent<NavMeshAgent>();
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        navAgent.SetDestination(player.transform.position);
    }
}
