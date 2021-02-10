using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerWeaponsManager : MonoBehaviour
{

    public GameObject startingGun;
    public Transform GunStartingPoint;
 
    public WeaponBlueprint[] currentWeapons;
    public int equipedWeaponID;


    public event EventHandler OnShoot;
    //  public class OnShootEventArgs : EventArgs { public int weaponID; }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            // OnShoot?.Invoke(this, new OnShootEventArgs { weaponID = equipedWeaponID });
            OnShoot?.Invoke(this, EventArgs.Empty);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        GameObject gun = EquipWeapon(startingGun);
        gun.GetComponent<WeaponBlueprint>().weaponsManager = this;


    }

    GameObject EquipWeapon(GameObject weapon)
    {

        GameObject gun = Instantiate(weapon, GunStartingPoint);
        return gun;
    }

    GameObject SwapWeapons(GameObject weapon)
    {

        GameObject gun = Instantiate(weapon, GunStartingPoint);
        return gun;
    }
    // Update is called once per frame

}

