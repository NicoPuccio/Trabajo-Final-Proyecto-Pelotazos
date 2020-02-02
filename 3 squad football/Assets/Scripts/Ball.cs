using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Renderer rend;
    private Rigidbody rb;
    private BoxCollider bc;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        bc = GetComponent<BoxCollider>();
        rend.enabled = true;
    }
    Vector3 vel = new Vector3();
    
    void Update()
    {
       
    }

    public void Move()
    {
        vel = gameObject.transform.position;
        vel.z = vel.z + 30;
        rb.velocity = vel;
    }

    public void Respawn()
    {
        rb.velocity = Vector3.zero;
        gameObject.transform.position = new Vector3(0, 5, 0);
    }


    public void ChangeMaterial(Material m)
    {
        rend.sharedMaterial = m;
    }

    public Material GetMaterial()
    {
        return rend.sharedMaterial;
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
