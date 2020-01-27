using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBall : MonoBehaviour
{
    public Transform shootPoint;
    public float hitRange = 0.5f;
    public LayerMask ballLayer;
    public GameObject ball;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HitBall();
        }
    }

    void HitBall()
    {
        Collider[] ball = Physics.OverlapSphere(shootPoint.position, hitRange, ballLayer);

        foreach (Collider bola in ball)
        {
            Debug.Log("I hit the " + bola.name);
            bola.GetComponent<Ball>().Move();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (shootPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(shootPoint.position, hitRange);
    }
}
