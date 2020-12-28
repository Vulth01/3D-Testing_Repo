using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleHit : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ball")
        {
            FindObjectOfType<audioManagerScript>().Play("doof");

        }
    }


}
