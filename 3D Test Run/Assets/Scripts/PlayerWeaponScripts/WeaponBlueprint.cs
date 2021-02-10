using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform), typeof(GameObject), typeof(string))]
[System.Serializable]
public class WeaponBlueprint : MonoBehaviour
{
    [Header("weaponStats")]

    public static int numWeapons;

    public string WeaponTag;
    protected float bulletSpeed = 10f;
    protected int bulletDamage = 10;
    protected float fireRate;
    [Header("weapon Components")]
    public GameObject bulletPrefab;
    public GameObject BulletPoolObject;
    public Transform shootPointTrans;

    protected PlayerWeaponsManager playerWeaponsManager;

    protected mouseLook mouseLook;

    protected GameObject playerObject;


    [HideInInspector]
    public PlayerWeaponsManager weaponsManager;

    //caching the bulletpooler
    BulletPooling bulletPooler;//not used yet **checkup on it
    protected void setUpWeapon()
    {
        playerWeaponsManager = FindObjectOfType<PlayerWeaponsManager>();
        mouseLook = FindObjectOfType<mouseLook>();
        playerObject = playerWeaponsManager.gameObject;


        bulletPooler = BulletPooling.Instance;
    }

    public void shootWeaponProjectile(string bulletTag, Vector3 BulletPosition, Quaternion BulletRotation)
    {
        GameObject bullet = bulletPooler.SpawnFromPool(bulletTag, BulletPosition, BulletRotation);





        bullet.GetComponent<Rigidbody>().AddForce(transform.right.normalized * bulletSpeed, ForceMode.Impulse);
        bullet.GetComponent<bullet>().Damage = bulletDamage;

    }
    public void shootWeaponRaycast()
    {








    }
}

