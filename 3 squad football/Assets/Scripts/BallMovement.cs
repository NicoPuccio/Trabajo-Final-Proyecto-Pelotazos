using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }
    Vector3 vel = new Vector3();
    // Update is called once per frame
    void Update()
    {
        vel = gameObject.transform.position;
        if (Input.anyKey)
        {
            vel.z = vel.z + 10;
            rb.velocity = vel;
            Debug.Log(rb.velocity);
        }
    }
}
