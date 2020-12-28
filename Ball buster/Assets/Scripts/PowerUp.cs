using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject playerObj;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag =="Player")
        {
            playerObj.transform.localScale = new Vector3(playerObj.transform.localScale.x+1, playerObj.transform.localScale.y, playerObj.transform.localScale.z);
            Debug.Log("powerupCollected");
        }
    }
}
