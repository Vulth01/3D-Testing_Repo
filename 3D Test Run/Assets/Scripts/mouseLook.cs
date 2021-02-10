using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{

    [Header("variables")]

    float xRotation = 0 ;
    public float XRot
    {
        get
        {
            return xRotation;
        }
       
    }



    [Header("cached components")]

    InputManager inputManager;

    public Transform camTrans;


    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        Cursor.lockState = CursorLockMode.Locked;


    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * inputManager.mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * inputManager.mouseSensitivity;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.Rotate(Vector3.up * mouseX);

    }

    
    void LateUpdate()
    {
        
        camTrans.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

}
