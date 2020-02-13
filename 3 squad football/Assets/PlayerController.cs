using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float jumpForce = 10f;
    public AudioClip rollSound;

    private Animator animator;
    private AudioSource audioSource;
    private Rigidbody rb;
    private float rollSpeed = 1f;
    public bool isGrounded;

    //public PlayerNumber playerNumber
    //{
    //    set
    //    {
    //        playerInput = PlayerInput.GetControllerForPlayer(value);
    //    }
    //}

    // Axis and button strings to set with controller number
    //PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        //SaveFromFall();
    }

    //void SaveFromFall()
    //{
    //    if (transform.position.y < 0)
    //    {
    //        transform.position = new Vector3(0, 1, -6);
    //    }
    //}

    void Movement()
    {
        // get input
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
        }
        if (horizontal != 0 || vertical != 0)
        {
            //AnimateMovement(true);
            //if (Input.GetButtonDown(playerInput.rollInput))
            //{
            //    audioSource.clip = rollSound;
            //    audioSource.Play();
            //    animator.SetTrigger("IsRolling");
            //}
            
            rb.rotation = Quaternion.LookRotation(direction);
            rb.MovePosition(rb.position + direction * movementSpeed * rollSpeed * Time.deltaTime);
        }
        else
        {
            AnimateMovement(false);
        }
        
        // if (Input.GetButtonDown(playerInput.jumpInput))
        // {
        // 	this.GetComponent<Rigidbody>().AddForce(0, jumpForce, 0, ForceMode.Acceleration);
        // }
    }

    private void AnimateMovement(bool moving)
    {
        if (animator)
        {
            animator.SetBool("IsRunning", moving);
        }
    }

    public void StartRolling()
    {
        rollSpeed = 1f;
    }

    public void MiddleRolling()
    {
        rollSpeed = 1.5f;
    }

    public void EndRolling()
    {
        rollSpeed = 1f;
    }

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