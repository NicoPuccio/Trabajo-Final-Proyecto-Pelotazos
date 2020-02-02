using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController cc;
    [SerializeField]private float movementSpeed = 2f;
    private float currentSpeed = 0f;
    private float rotationSpeed = 0.1f;
    private float gravity = 3f;
    private float speedSmoothVelocity = 0f;
    private float SpeedSmoothTime = 0f;

    private Transform mainCameraTransform = null;

    private Vector3 moveDirection = Vector3.zero;
    

    public float speed = 10f;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        mainCameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Move();
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= speed;
    }

    private void FixedUpdate()
    {
        cc.Move(moveDirection * Time.fixedDeltaTime);
    }

    private void Move()
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector3 forward = mainCameraTransform.forward;
        Vector3 right = mainCameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = (forward * movementInput.y + right * movementInput.x).normalized;
        Vector3 gravityVector = Vector3.zero;

        if (!cc.isGrounded)
        {
            gravityVector.y -= gravity;
        }

        //cc.Move(gravityVector * Time.deltaTime); for implementing gravity

        if (desiredMoveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), rotationSpeed);
        }

        float targetSpeed = movementSpeed * movementInput.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, SpeedSmoothTime);

        cc.Move(desiredMoveDirection * currentSpeed * Time.deltaTime);
    }
}
