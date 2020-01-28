using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Renderer rend;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
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
        Instantiate(gameObject, new Vector3(0, 3, 0), Quaternion.identity);
    }

    public void Dissapear()
    {
        Destroy(gameObject);
    }

    public void ChangeMaterial(Material m)
    {
        rend.sharedMaterial = m;
    }

    public Material GetMaterial()
    {
        return rend.sharedMaterial;
    }
}
