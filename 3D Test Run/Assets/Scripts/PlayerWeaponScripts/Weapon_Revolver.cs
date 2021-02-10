using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Weapon_Revolver : WeaponBlueprint
{

    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 25f;
        bulletDamage = 15;
        setUpWeapon();
       
        weaponsManager.OnShoot += WeaponsManager_OnShoot;
    }

    private void WeaponsManager_OnShoot(object sender, EventArgs e)
    {

        shootWeaponProjectile(WeaponTag, shootPointTrans.position, shootPointTrans.rotation);



    }


    // Update is called once per frame
    void Update()
    {
        //mouseLook.XRot;
    }

    float XRotation = 0;
    void rotateTowardsCursor()
    {

    }


}
