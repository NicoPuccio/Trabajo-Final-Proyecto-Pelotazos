using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Renderer rend;
    private Rigidbody rb;
    private BoxCollider bc;
    public float impulseForce;
    private Vector3 startPosition;
    private AudioSource audioSource;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        bc = GetComponent<BoxCollider>();
        rend.enabled = true;
        audioSource = GetComponent<AudioSource>();
    }
    
    
    void Update()
    {
       // SaveFromFall();
    }

    public void RespawnBall()
    {
        StartCoroutine(Respawn());
    }

    private void SaveFromFall()
    {
        if (transform.position.y < 0)
        {
            transform.position = startPosition;
        }
    }

    private IEnumerator Respawn()
    {
        gameObject.transform.position = new Vector3(0, -10, 0);
        rb.velocity = Vector3.zero;
       
        yield return new WaitForSeconds(2f);
        rb.velocity = Vector3.zero;
        gameObject.transform.position = new Vector3(Random.Range(6.5f,14), 7, Random.Range(-11, 0f)); //respawn in center of the field
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
