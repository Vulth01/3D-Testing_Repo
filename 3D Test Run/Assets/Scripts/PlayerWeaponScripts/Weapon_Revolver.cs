using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Weapon_Revolver : WeaponBlueprint
{

    // Start is called before the first frame update
    void Start()
    {
        setUpWeapon();

        weaponsManager.OnShoot += WeaponsManager_OnShoot;
    }

    private void WeaponsManager_OnShoot(object sender, EventArgs e)
    {

        shootWeaponProjectile(WeaponTag, shootPointTrans.position, shootPointTrans.rotation);


        //Object original, Vector3 position, Quaternion rotation, Transform parent);
        //   GameObject bullet = Instantiate(bulletPrefab, shootPointTrans.position, Quaternion.identity, BulletPoolObject.transform);
        //Vector3 bulletVector = new Vector3(,0, bulletSpeed)
        //  bullet.GetComponent<Rigidbody>().AddForce(0, 0, bulletSpeed);

    }


    // Update is called once per frame
    void Update()
    {

    }
}
