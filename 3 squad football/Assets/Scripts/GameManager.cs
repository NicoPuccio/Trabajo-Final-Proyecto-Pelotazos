using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] goals;
    public int player1Score = 0;
    public int player2Score = 0;
    public static GameManager instance;
    public float timer;

    private GameObject ball;
    

    private void Start()
    {
        goals = GameObject.FindGameObjectsWithTag("Goal");
        ball = GameObject.FindGameObjectWithTag("Ball");
        instance = this;
        timer = 90f;
    }

    void Update()
    {
        DecreaseTimer();
    }

    private void DecreaseTimer()
    {
        timer -= Time.deltaTime;
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
