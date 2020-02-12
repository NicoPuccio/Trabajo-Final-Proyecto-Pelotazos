using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=bsLFIPoBPEQ
public class BallShooting : MonoBehaviour
{
    private GameObject ball;
    public Transform shootPoint;
    public float hitRange = 0.5f;
    public LayerMask ballLayer;

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryHitBall();
        }
    }

    private void TryHitBall()
    {
        Collider[] balls = Physics.OverlapSphere(shootPoint.position, hitRange, ballLayer);
        float power = GetPower();
        foreach (Collider col in balls)
        {
            if (power > 0)
            {
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                rb.velocity = GetReflected() * power;
            }
        }
        
    }

    private Vector3 GetReflected()
    {
        Vector3 ballVector = transform.position - ball.transform.position;
        Vector3 planeTangent = Vector3.Cross(ballVector, Camera.main.transform.forward);
        Vector3 planeNormal = Vector3.Cross(planeTangent, ballVector);
        Vector3 reflected = Vector3.Reflect(Camera.main.transform.forward, planeNormal);
        return reflected.normalized;
    }

    private float GetPower()
    {
        return 30;
    }
}
