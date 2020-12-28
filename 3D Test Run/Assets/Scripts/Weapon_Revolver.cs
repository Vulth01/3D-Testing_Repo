using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Weapon_Revolver : Weapon
{

    // Start is called before the first frame update
    void Start()
    {

        weaponsManager.OnShoot += WeaponsManager_OnShoot;
    }

    private void WeaponsManager_OnShoot(object sender, EventArgs e)
    {

        //Object original, Vector3 position, Quaternion rotation, Transform parent);
        GameObject bullet = Instantiate(bulletPrefab, shootPointTrans.position, Quaternion.identity, BulletPoolObject.transform);
        //Vector3 bulletVector = new Vector3(,0, bulletSpeed)
        bullet.GetComponent<Rigidbody>().AddForce(0, 0, bulletSpeed);

    }


    // Update is called once per frame
    void Update()
    {

    }
}
[RequireComponent(typeof(Transform), typeof(GameObject))]
[System.Serializable]
public class Weapon : MonoBehaviour
{
    [Header("weaponStats")]

    public static int numWeapons;
    protected float bulletSpeed = 100f;
    protected float fireRate;
    [Header("weapon Components")]
    public GameObject bulletPrefab;
    public GameObject BulletPoolObject;
    public Transform shootPointTrans;

    [HideInInspector]
    public PlayerWeaponsManager weaponsManager;


    void Start()
    {

    }


}
