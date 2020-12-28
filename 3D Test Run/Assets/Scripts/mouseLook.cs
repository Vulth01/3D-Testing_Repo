using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{

    [Header("variables")]

    float xRotation = 0f;

    public Transform playerBodyTrans;

    [Header("cached components")]

    InputManager inputManager;

    public Transform playerTrans;
    Camera playerCam;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        Cursor.lockState = CursorLockMode.Locked;
        playerCam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * inputManager.mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * inputManager.mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerTrans.Rotate(Vector3.up * mouseX);
        playerBodyTrans.Rotate(Vector3.up * mouseX);

    }
}
