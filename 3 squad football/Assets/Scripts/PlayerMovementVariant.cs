using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementVariant : MonoBehaviour
{
    private CharacterController cc;
    [SerializeField] private float movementSpeed = 2f;
    private float currentSpeed = 0f;
    public float rotationSpeed = 0.1f;
    private float gravity = 20.0f;
    private float speedSmoothVelocity = 0f;
    private float SpeedSmoothTime = 0f;
    [SerializeField] private float jumpForce;
    
    private Rigidbody rb;

    private Vector3 moveDirection = Vector3.zero;


    public float speed = 10f;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Move();
        if (cc.isGrounded)
        {
            moveDirection = new Vector3(0, 0.0f, Input.GetAxisRaw("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            moveDirection = new Vector3(0, moveDirection.y, Input.GetAxisRaw("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.x *= speed;
            moveDirection.z *= speed;
        }
        transform.Rotate(0, Input.GetAxisRaw("Horizontal") * rotationSpeed, 0);
        moveDirection.y -= gravity * Time.deltaTime;
        cc.Move(moveDirection * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        //cc.Move(moveDirection * Time.fixedDeltaTime);
        //Jump();
    }

    private void Move()
    {

    }

    private void Jump()
    {
        if (cc.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
            }

        }
    }
}