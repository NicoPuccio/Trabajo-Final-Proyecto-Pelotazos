using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private GameObject ball;
    public UIManager ui;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ball")
        {
            if (gameObject.tag == "Player1Goal")
            {
                GameManager.instance.Player2Scored();
                ui.ShowGol(1);
            }
            else if (gameObject.tag == "Player2Goal")
            {
                GameManager.instance.Player1Scored();
                ui.ShowGol(0);
            }
            GameManager.instance.PlayGolSound();
        }
    }
}
