using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [Header("player settings")]
  
  
    float playerMovementForce = 200f;

    float playerSprintMultiplier;
    float playerJumpForce = 10000;


    float GroundThreshold = 0.4f;


    Vector3 movementVector;

    public Transform groundCheckTrans;
    public LayerMask groundMask;


    public Rigidbody hips;

    [Header("cached components")]

    //InputManager inputManager;
    CharacterController controller;

    bool isGrounded;

    [Header("Gravity")]
    Vector3 velocity;

    bool isJumping = false;
    void Start()
    {

        //inputManager = GetComponent<InputManager>();
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {

        Playerdirection();

        GroundCheck();

        CheckJump();
        isGrounded = false;
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }
    #region myOwnLeanScript
    void lean()
    {

    }
    #endregion

    void Playerdirection()
    {
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.z = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("sprinting");
            movementVector.x = Input.GetAxis("Horizontal") * playerSprintMultiplier;
            movementVector.z = Input.GetAxis("Vertical") * playerSprintMultiplier;
        }
    }
    void CheckJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }


    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheckTrans.position, GroundThreshold, groundMask);
    }
    void ApplyMovement()
    {
        
       
        hips.AddForce(playerMovementForce * movementVector);



        if (isJumping)
        {
            hips.AddForce(hips.transform.up * playerJumpForce);

            //jump 
           
            isJumping = false;
        }
    }
}
