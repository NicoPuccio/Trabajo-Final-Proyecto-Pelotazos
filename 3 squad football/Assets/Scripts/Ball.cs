using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Renderer rend;
    private Rigidbody rb;
    private BoxCollider bc;
    public float impulseForce;
    
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

    public void RespawnBall()
    {
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        gameObject.transform.position = new Vector3(0, -10, 0);
        rb.velocity = Vector3.zero;
       
        yield return new WaitForSeconds(2f);
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
