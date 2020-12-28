using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHit : MonoBehaviour
{
    public float Health=100;
    public int moneyOnKill=10;
    public GameObject healthBar;
    private float healthBarScale = 15f;
    public event EventHandler OnEnemyDie;
    private void EnemyHit_OnEnemyDie(object sender, EventArgs e)
    {
        Debug.Log("enmy has died");
        
    }
    // Start is called before the first frame update
    void Start()
    {

        healthBar.transform.localScale = new Vector3(Health / healthBarScale, 0.5f, 0);

        OnEnemyDie += EnemyHit_OnEnemyDie;

    }



    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        
        if (collisionInfo.collider.tag == "PlayerBullet" && Health > 0)
        {
            Health -= collisionInfo.collider.GetComponent<Bullet>().bulletDmg;
            healthBar.transform.localScale = new Vector3(Health / healthBarScale, 0.5f, 0);
            audioManagerScript.instance.Play("doof");
           
        }

   
        if (Health <= 0)
        {
            EnemyDie();
            
           
         
        }
        
        // HitDetect();
    }
    private void EnemyDie()
    {
        Destroy(gameObject);
        OnEnemyDie?.Invoke(this, EventArgs.Empty);
        playerMoneyHandler.UpdateMoney(moneyOnKill);


    }

   
}
