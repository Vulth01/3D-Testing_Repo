using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{

    [Header("playerInputSettings")]

    public float mouseSensitivity = 100f;

    void Start()
    {


    }
    public Vector3 GetPlayerMoveVector()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");// "Input Axis Verticle is not setup."  error is given if you mispell it 
        return transform.right * x + transform.forward * z;

    }
    // Update is called once per frame
    void Update()
    {

    }
}
