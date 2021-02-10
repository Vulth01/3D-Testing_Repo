using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    [Range(0.25f, 0.05f)]
    float slowDownFactor = 0.05f;
    [SerializeField]
    [Range(1, 10)]
    float slowDownLength = 2f;

    public void SlowTime()
    {
        Time.timeScale = slowDownFactor;
        
    }
    public void ReturnTime()
    {
        Time.timeScale = 1;
    }
}
