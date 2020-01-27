using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController cc;

    private Vector3 moveDirection = Vector3.zero;
    public float speed = 10f;
    

    
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= speed;
    }

    private void FixedUpdate()
    {
        cc.Move(moveDirection * Time.fixedDeltaTime);
    }
}
