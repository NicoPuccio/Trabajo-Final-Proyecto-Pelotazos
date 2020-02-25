using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    
    public Material[] material; // blue black red
    private Renderer rend;
    private GameObject ball;
    public UIManager ui;
    void Start()
    {
        rend = GetComponent<Renderer>();
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        
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
