using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }
    Vector3 vel = new Vector3();
    
    void Update()
    {
       
    }

    public void Move()
    {
        vel = gameObject.transform.position;
        vel.z = vel.z + 10;
        rb.velocity = vel;
        Debug.Log(rb.velocity);
    }
}
