using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject MeleeEnemyPrefab;
    public GameObject ShootingEnemyPrefab;
    public float StartDelay=1;
    public Transform playerTrans;

    public Transform enemyEndOfGunTrans;
    public Vector2 spawnpoint;
    public int numMeleeSpawn;
    public int numShooterSpawn;

    public float Melee1DMG=30;
    public float Melee1KnockBack=100;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wave1(numMeleeSpawn,numShooterSpawn));
    }


    // Update is called once per frame
    void Update()
    {
        
    }
  
    IEnumerator Wave1(int numMelee, int numShooter)
    {
        
        yield return new WaitForSeconds(StartDelay);


        for (int M = 0; M < numMelee; M++)
        {
            GameObject a = Instantiate(MeleeEnemyPrefab, transform);
            a.transform.position = new Vector2 (spawnpoint.x+(M),spawnpoint.y);
            a.GetComponent<AIDestinationSetter>().target = playerTrans;
        }

        //   mEnemy1.GetComponent<AIDestinationSetter>().target = playerTrans;





        yield return new WaitForSeconds(5);
        //shooters



        for (int S = 0; S < numShooterSpawn; S++)
        {
            GameObject sEnemy1 = Instantiate(ShootingEnemyPrefab, transform);
            sEnemy1.transform.position = new Vector2(spawnpoint.x + (S ), spawnpoint.y);
            sEnemy1.GetComponent<AIDestinationSetter>().target = playerTrans;
            sEnemy1.GetComponent<ShootingEnemy>().playerTrans = playerTrans;
        }
       





    }
}
