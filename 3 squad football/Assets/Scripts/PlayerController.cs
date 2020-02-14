using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //input
    float horizontal;
    float vertical;
    Vector3 direction;
    bool jump = false;
    
    //movement
    public float movementSpeed = 1f;
    private Rigidbody rb;
    public string horizontalInput = "Horizontal";
    public string verticalInput = "Vertical";
    public string jumpInput = "Jump";
    public string dashInput = "Dash";

    private Animator animator;
    private AudioSource audioSource;
    
    //jump
    public bool isGrounded;
    public float jumpForce = 10f;
    //dash
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    public bool dashing = false;
    


    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        //get inpuit in the update. not working well for dash and jump
        GetInput();
        Dash();
        Jump();
        //SaveFromFall();
    }

    private void FixedUpdate()
    {
        //all physics movement is better in fixed update.
        Movement();
        
    }

    //void SaveFromFall()
    //{
    //    if (transform.position.y < 0)
    //    {
    //        transform.position = new Vector3(0, 1, -6);
    //    }
    //}

    void GetInput()
    {
        horizontal = Input.GetAxis(horizontalInput);
        vertical = Input.GetAxis(verticalInput);
        direction = new Vector3(horizontal, 0, vertical);
    }

    void Movement()
    {
        // get input
        //dash
        
        //movement
        if (horizontal != 0 || vertical != 0)
        {
            rb.rotation = Quaternion.LookRotation(direction);
            rb.MovePosition(rb.position + direction * movementSpeed * Time.deltaTime);
        }
        //else
        //{
        //    AnimateMovement(false);
        //}
    }

    private void Dash()
    {
        if (dashTime <= 0)
        {
            dashTime = startDashTime;
            rb.velocity = Vector3.zero;
        }
        if (Input.GetButtonDown(dashInput))
        {
            dashing = true;
            rb.AddForce(direction * dashSpeed, ForceMode.VelocityChange);
        }
        if (dashing)
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0)
            {
                dashing = false;
            }
        }
    }
    private void Jump()
    {
        //jump
        if (Input.GetButtonDown(jumpInput) && isGrounded)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
        }
    }
    //private void AnimateMovement(bool moving)
    //{
    //    if (animator)
    //    {
    //        animator.SetBool("IsRunning", moving);
    //    }
    //}
    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Ground")
            isGrounded = true;
    }
    
    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ground")
            isGrounded = false;
    }
}