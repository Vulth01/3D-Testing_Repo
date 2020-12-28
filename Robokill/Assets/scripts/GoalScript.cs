using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GoalScript : MonoBehaviour
{
    private int lastIndex=0;
  private int newIndex=0;
    public Tilemap[] tilemaps;
   
    void OnTriggerEnter2D()
    {
        randomWallSet();
    }
    private void randomWallSet()
    {

        lastIndex = newIndex;
        tilemaps[lastIndex].enabled = false;
         newIndex = Random.Range(0, lastIndex+1);
        tilemaps[newIndex].enabled = true;


    }
}
