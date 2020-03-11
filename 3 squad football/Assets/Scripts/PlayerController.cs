using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //input
    private float horizontal;
    private float vertical;
    Vector3 direction;
    private bool jump = false;
    
    //movement
    public float movementSpeed = 1f;
    private Rigidbody rb;
    public string horizontalInput;
    public string verticalInput;
    public string jumpInput;
    public string dashInput;

    //audio
    public AudioSource audioKick;
    public AudioSource audioDash;
    
    //jump
    public bool isGrounded;
    public float jumpForce = 10f;
    private bool isJumping = false;
    //dash
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    public bool dashing = false;
    private float dashCooldown = 0f;
    public float startDashCooldown = 1f;

    //anim
    private Animator animator;
    //bug catcher
    private Vector3 startPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        dashTime = startDashTime;
        startPosition = gameObject.transform.position;
    }
    
    void Update()
    {
        //get inpuit in the update. not working well for dash and jump
        GetInput();
        Dash();
        Jump();
        Animate();
        SaveFromFall();
    }

    private void FixedUpdate()
    {
        //all physics movement is better in fixed update.
        Movement();
    }

    void SaveFromFall() //in case some unexpected bug appears
    {
        if (transform.position.y < 0)
        {
            transform.position = startPosition;
        }
    }

    void GetInput()
    {
        horizontal = Input.GetAxis(horizontalInput);
        vertical = Input.GetAxis(verticalInput);
        direction = new Vector3(horizontal, 0, vertical);
    }

    void Animate()
    {
        if (animator == null) return;

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        if (isJumping)
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }

    void Movement()
    {
        if (horizontal != 0 || vertical != 0)
        {
            rb.rotation = Quaternion.LookRotation(direction);
            rb.MovePosition(rb.position + direction * movementSpeed * Time.deltaTime);
        }
    }
    
    private void Dash()
    {
        if (dashCooldown < 0)
        {
            dashCooldown = 0;
        }
        if (dashTime <= 0)
        {
            dashTime = startDashTime;
            rb.velocity = Vector3.zero;
        }
        if (Input.GetButtonDown(dashInput) && dashCooldown <= 0 && (horizontal != 0 || vertical != 0))
        {
            dashCooldown = startDashCooldown;
            rb.AddForce(direction * dashSpeed, ForceMode.VelocityChange);
            dashing = true;
            PlayDashSound();
        }
        if (dashing)
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0)
            {
                dashing = false;
            }
        }
        if (dashCooldown > 0)
        {
            dashCooldown -= Time.deltaTime;
        }
        
    }

    private void PlayDashSound()
    {
        audioDash.Play();
    }
    private void Jump()
    {
        if (Input.GetButtonDown(jumpInput) && isGrounded)
        {
            isJumping = true;
            rb.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
        }
        else if (isGrounded == true)
        {
            isJumping = false;
        }
    }
    
    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Ground")
            isGrounded = true;
        if (collisionInfo.collider.tag == "Ball")
        {
            audioKick.Play();
        }
    }
    
    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ground")
            isGrounded = false;
    }

    
}