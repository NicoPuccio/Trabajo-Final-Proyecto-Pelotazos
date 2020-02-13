using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] goals;
    private int player1Score = 0;
    private int player2Score = 0;
    public static GameManager instance;

    private GameObject ball;
    

    private void Start()
    {
        goals = GameObject.FindGameObjectsWithTag("Goal");
        ball = GameObject.FindGameObjectWithTag("Ball");
        instance = this;
    }

    void Update()
    {
        
    }

    public void Player1Scored()
    {
        player1Score += 1;
        Debug.Log("Player 1 score: " + player1Score);
        ball.GetComponent<Ball>().RespawnBall();
    }
    
    public void Player2Scored()
    {
        player2Score += 1;
        Debug.Log("Player 2 score: " + player2Score);

        ball.GetComponent<Ball>().RespawnBall();
    }
  
}
