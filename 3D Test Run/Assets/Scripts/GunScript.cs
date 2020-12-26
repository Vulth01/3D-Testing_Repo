using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject startingGun;
    public Transform GunStartingPoint;
    // Start is called before the first frame update
    void Start()
    {
       GameObject gun =  Instantiate(startingGun, GunStartingPoint);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
