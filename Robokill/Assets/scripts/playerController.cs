using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class playerController : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [Header("Health Components")]
    [SerializeField] private float Health = 100;
    private float healthBarScale = 15f;

    [Header("Movement components")]
    [SerializeField] private Rigidbody2D playerRigid;
    [SerializeField] private Transform legsTransform;
    [SerializeField] private Rigidbody2D legsRigidBody;
    private Vector2 movementVector;
    [SerializeField] private float movementSpeed = 5f;

    [Header("AimAtMouse components")]
    [SerializeField] private Transform gunTransform;
    [SerializeField] private Rigidbody2D gunRigidBody;
    [SerializeField] private Camera cam;

    [Header("Weapons class components")]
    [SerializeField] private TextMeshProUGUI AmmoTMP;
    [SerializeField] private Transform endOfGunTrans;
    public int selectedWeapon = -1;
    public bool[] unlockedWeaponNumber = { false };
    private float nextTimeToFire = 0;

   [SerializeField] private Weapon[] weapons;


    void Awake()
    {
        int i = 0;
        foreach (Weapon weapon in weapons)
        {
            weapons[i].CurrentMagazine = weapons[i].MaxMagazine;
            weapons[i].CurrentAmmoCapacity = weapons[i].MaxAmmoCapacity;
            i++;
        }

    }
    void Start()
    {

        healthBar.transform.localScale = new Vector3(Health / healthBarScale, 0.5f, 0);
    }
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "PickUp")
        {

            PickUpFunct(collisionInfo.gameObject.GetComponent<Pickup>().ID);
            Destroy(collisionInfo.gameObject);
        }
    }
    public void debugPickUp(int id, int bum)
    {
        Debug.Log("Pickup");
    }
    public void PickUpFunct(int ID)
    {

        unlockedWeaponNumber[ID] = true;
        selectedWeapon = ID;
        selectedWeapon = ID;
        UpdateAmmo(ID);

    }
    void Update()
    {

        movementVector.x = Input.GetAxisRaw("Horizontal");

        movementVector.y = Input.GetAxisRaw("Vertical");


        gunTransform.position = transform.position;// attatches the gun to the legs because the seperate gameobject is moved with the rigidbody so it doestn move the transform

        legsTransform.position = transform.position;


        if (selectedWeapon >= 0) DetectSelectedWepon();




        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire && selectedWeapon >= 0 && !isReloading && weapons[selectedWeapon].CurrentMagazine > 0)
        {
            Shoot(selectedWeapon);

            nextTimeToFire = Time.time + 1 / weapons[selectedWeapon].fireRate;
        }
        else if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire && selectedWeapon >= 0 && !isReloading && weapons[selectedWeapon].CurrentMagazine <= 0)
        {
            StartCoroutine(Reload(selectedWeapon));
        }

        if (Input.GetKeyDown(KeyCode.R) && weapons[selectedWeapon].CurrentMagazine != weapons[selectedWeapon].MaxMagazine && !isReloading)
        {


            StartCoroutine(Reload(selectedWeapon));


        }
    }
    void FixedUpdate()
    {
        AimAtMouse();
        Movement();
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {

        if (collisionInfo.collider.tag == "EnemyBullet" && Health > 0)
        {
            Health -= collisionInfo.collider.GetComponent<Bullet>().bulletDmg;
            healthBar.transform.localScale = new Vector3(Health / healthBarScale, 0.5f, 0);
        }

        if (collisionInfo.collider.tag == "MeleeEnemy" && Health > 0)
        {

            Health -= collisionInfo.collider.GetComponent<MeleeEnemy>().meleeDmg;
            healthBar.transform.localScale = new Vector3(Health / healthBarScale, 0.5f, 0);

            gameObject.GetComponent<Rigidbody2D>().AddForce((transform.position - collisionInfo.collider.transform.position).normalized * collisionInfo.collider.GetComponent<MeleeEnemy>().KnockBack);


        }
        else if (Health <= 0)
        {
            PlayerDie();
        }

        // HitDetect();
    }
    private bool isReloading = false;

    IEnumerator Reload(int weaponID)
    {

        if (weapons[weaponID].CurrentAmmoCapacity > 0)
        {
            isReloading = true;

            yield return new WaitForSeconds(weapons[weaponID].reloadTime);



            if (weapons[weaponID].CurrentAmmoCapacity >= weapons[weaponID].MaxMagazine)
            {
                weapons[weaponID].CurrentMagazine = weapons[weaponID].MaxMagazine;

            }
            else if (weapons[weaponID].CurrentAmmoCapacity < weapons[weaponID].MaxMagazine)
            {
                weapons[weaponID].CurrentMagazine = weapons[weaponID].CurrentAmmoCapacity;
            }
            weapons[selectedWeapon].CurrentAmmoCapacity -= weapons[weaponID].ammoSpent;




            isReloading = false;

            UpdateAmmo(weaponID);
        }
        else
        {
            Debug.Log("OutOfAmmo");

        }
        weapons[weaponID].ammoSpent = 0;
    }
    private void Movement()
    {
        playerRigid.MovePosition(playerRigid.position + movementVector * movementSpeed * Time.fixedDeltaTime);

        if (movementVector.x == 1) legsRigidBody.rotation = 90;

        if (movementVector.x == -1) legsRigidBody.rotation = -90;

        if (movementVector.y == 1) legsRigidBody.rotation = 0;

        if (movementVector.y == -1) legsRigidBody.rotation = -180;

    }
    private void PlayerDie()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Shoot(int curWeapID)
    {
        weapons[curWeapID].ammoSpent++;
        Vector2 shootDirection = (cam.ScreenToWorldPoint(Input.mousePosition) - endOfGunTrans.position);

        GameObject bullet = Instantiate(weapons[curWeapID].bulletPrefab, endOfGunTrans);

        bullet.GetComponent<Bullet>().bulletDmg = weapons[curWeapID].weaponDamage;

        bullet.tag = "PlayerBullet";

        bullet.transform.parent = null; // because it instantiates it at the position of the gun you must deassign it as a parent, however there is a parameter that automatically sets it to world space

        bullet.GetComponent<Rigidbody2D>().AddForce(shootDirection.normalized * weapons[curWeapID].bulletSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);


        Destroy(bullet, 2);

        weapons[curWeapID].CurrentMagazine--;
        UpdateAmmo(curWeapID);
    }
    private void AimAtMouse()
    {
        Vector2 direction = (gunRigidBody.transform.position - cam.ScreenToWorldPoint(Input.mousePosition));
        float aimAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gunRigidBody.rotation = aimAngle + 90;
    }
    private void DetectSelectedWepon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && unlockedWeaponNumber[0])
        {
            selectedWeapon = 0;//weapon1
            UpdateAmmo(0);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && unlockedWeaponNumber[1])
        {
            selectedWeapon = 1;//weapon2
            UpdateAmmo(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && unlockedWeaponNumber[2])
        {
            selectedWeapon = 2;
            UpdateAmmo(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && unlockedWeaponNumber[3])
        {
            selectedWeapon = 3;
            UpdateAmmo(3);
        }
    }
    private void UpdateAmmo(int weaponIndex)
    {
        AmmoTMP.text = weapons[weaponIndex].CurrentMagazine + " || " + weapons[weaponIndex].MaxMagazine + "\n" + weapons[weaponIndex].CurrentAmmoCapacity;
    }
}
[Serializable]
class Weapon
{
    [HideInInspector] public int ammoSpent = 0;
    public string weaponName;
    public GameObject bulletPrefab;
    public float weaponDamage;
    public float bulletSpeed;
    public float reloadTime;
    public float fireRate;

    public int CurrentMagazine;
    [HideInInspector] public int MaxMagazine;


    public int CurrentAmmoCapacity;
    [HideInInspector] public int MaxAmmoCapacity;



}

