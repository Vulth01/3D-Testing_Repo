using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winScript : MonoBehaviour
{
    LoadScenesScript loadScenesScript;

    void Awake()
    {
        loadScenesScript = FindObjectOfType<LoadScenesScript>();
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ball")
        {
            loadScenesScript.LoadNextSceneFunction();
        }
    }
}
