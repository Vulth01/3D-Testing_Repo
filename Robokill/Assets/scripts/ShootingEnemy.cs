using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{

    public  Transform playerTrans;
    public Transform enemyEndOfGun;

    [Header("which gun(by index) should the enemy have")]

    [SerializeField] private int enemyCurrentWeapon = 0;

    private float nextTimeToFire = 0;


    [Header("shooter SetUp array")]
    [SerializeField] private Shooter[] Shooters;



    void Start()
    {

    }



    void Update()
    {

        if (Time.time >= nextTimeToFire)
        {
            Shoot(enemyCurrentWeapon);
            nextTimeToFire = Time.time + 1 / Shooters[enemyCurrentWeapon].fireRate;
        }


    }
    private void Shoot(int enemycurrentWeapon)
    {

        Vector2 shootDirection = (playerTrans.position - transform.position);

        GameObject bullet = Instantiate(Shooters[enemycurrentWeapon].bulletPrefab, enemyEndOfGun);

        bullet.GetComponent<Bullet>().bulletDmg = Shooters[enemycurrentWeapon].weaponDamage;
        bullet.tag = "EnemyBullet";

        bullet.transform.parent = null; // because it instantiates it at the position of the gun you must deassign it as a parent, however there is a parameter that automatically sets it to world space

        bullet.GetComponent<Rigidbody2D>().AddForce(shootDirection.normalized * Shooters[enemycurrentWeapon].bulletSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);

        Destroy(bullet, 2);
    }
}
[System.Serializable]
public class Shooter
{


    public GameObject bulletPrefab;
    public float weaponDamage;
    public float bulletSpeed;
    public float fireRate;
    public float range;
    public int ammoCapacity;
    public int MaxMagazine;


}
