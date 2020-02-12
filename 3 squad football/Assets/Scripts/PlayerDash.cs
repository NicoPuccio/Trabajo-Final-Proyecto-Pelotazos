using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private float dashSpeed;
    private float dashTime;
    [SerializeField] private float startDashTime;
    private int direction;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        dashTime = startDashTime;
    }

    private void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction = 1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                direction = 2;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                direction = 3;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                direction = 4;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector3.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (Input.GetKeyDown(KeyCode.Z))
                {
                    Debug.Log("MORITE");
                    if (direction == 1)
                    {
                        rb.velocity = Vector3.left * dashSpeed;
                    }
                    if (direction == 2)
                    {
                        rb.velocity = Vector3.right * dashSpeed;
                    }
                    if (direction == 3)
                    {
                        rb.velocity = Vector3.forward * dashSpeed;
                    }
                    if (direction == 4)
                    {
                        rb.velocity = Vector3.back * dashSpeed;
                    }
                }
            }
        }
    }
}

    //public IEnumerator Dash()
    //{
    //    rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);
        
    //    yield return new WaitForSeconds(dashDuration);

    //    rb.velocity = Vector3.zero;
    //}
//}
