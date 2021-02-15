using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [Header("player settings")]
    float playerMovementSpeed = 12f;

    float playerSprintSpeed;
    float playerJumpHeight = 3f;


    float GroundThreshold = 0.4f;

    public Animator playerAnimator;
    public Transform playerMesh;


    public Transform groundCheckTrans;
    public LayerMask groundMask;


    [Header("cached components")]

    //InputManager inputManager;
    CharacterController controller;

    bool isGrounded;
    bool isSprinting = false;
    [Header("Gravity")]
    Vector3 velocity;
    float gravity = -9.81f;
    void Start()
    {
        playerSprintSpeed = playerMovementSpeed * 1.3f;
        //inputManager = GetComponent<InputManager>();
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {

        GroundCheck();

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        ApplyGravity();

        ApplySprint();

        PlayerMovement();

        jump();
        isGrounded = false;
    }
    #region myOwnLeanScript

    #endregion
    void PlayerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");// "Input Axis Verticle is not setup."  error is given if you mispell it 

        playerAnimator.SetFloat("playerSpeed", x + z);
        Vector3 move = transform.right * x + transform.forward * z;
        if (isSprinting)
        {
            controller.Move(move * playerSprintSpeed * Time.deltaTime);
            isSprinting = false;
         
        }
        controller.Move(move * playerMovementSpeed * Time.deltaTime);

    }
    void lean()
    {

    }
    void jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            velocity.y = Mathf.Sqrt(playerJumpHeight * -2f * gravity);
        }
    }
    void ApplySprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;

        }
    }
    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheckTrans.position, GroundThreshold, groundMask);


    }

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
