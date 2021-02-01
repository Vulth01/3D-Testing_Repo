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
    protected float bulletSpeed = 100f;
    protected float fireRate;
    [Header("weapon Components")]
    public GameObject bulletPrefab;
    public GameObject BulletPoolObject;
    public Transform shootPointTrans;

    protected PlayerWeaponsManager playerWeaponsManager;

    protected GameObject playerObject;



    protected Transform playerLookPoint;

    [HideInInspector]
    public PlayerWeaponsManager weaponsManager;

    //caching the bulletpooler
    BulletPooling bulletPooler;//not used yet **checkup on it
    protected void setUpWeapon()
    {
        playerWeaponsManager = FindObjectOfType<PlayerWeaponsManager>();
        playerObject = playerWeaponsManager.gameObject;

        playerLookPoint = playerWeaponsManager.playerLookTrans;


        Debug.Log(playerLookPoint.transform);

        bulletPooler = BulletPooling.Instance;
    }

    public void shootWeapon(string bulletTag, Vector3 BulletPosition, Quaternion BulletRotation)
    {
        GameObject bullet = bulletPooler.SpawnFromPool(bulletTag, BulletPosition, BulletRotation);

        Vector3 shootDirection = playerLookPoint.position - shootPointTrans.position;
        Debug.Log(shootDirection);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpeed * (shootDirection));

    }

}

