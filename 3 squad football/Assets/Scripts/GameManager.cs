﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{

    private GameObject[] goals;
    public int player1Score = 0;
    public int player2Score = 0;
    public static GameManager instance;
    public float gameTimer;

    private GameObject ball;
    public string endGameScene;
    private UIManager ui;
    public bool inGame;
   // public GameObject 

    private void Start()
    {
        goals = GameObject.FindGameObjectsWithTag("Goal");
        ball = GameObject.FindGameObjectWithTag("Ball");
        instance = this;
        gameTimer = 90f;
        StartCoroutine(GameCicle());
        ui = GetComponent<UIManager>();
        inGame = true;
    }

    void Update()
    {
        //DecreaseTimer();
        //StartCoroutine(EndGame());
        if (!inGame && Input.GetButton("Start"))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void DecreaseTimer()
    {
        gameTimer -= Time.deltaTime;
    }

    public void Player1Scored()
    {
        player1Score += 1;
        ball.GetComponent<Ball>().RespawnBall();
    }
    
    public void Player2Scored()
    {
        player2Score += 1;
        ball.GetComponent<Ball>().RespawnBall();
    }

    private IEnumerator EndGame()
    {
        if (gameTimer <=0)
        {
            gameTimer = 0;
            Destroy(ball);
            //ui.ShowWinner(); // this is showing multiple times. 
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(endGameScene);
        }
    }

    public string PlayerWinner()
    {
        string winner = "empate";
        if (player1Score< player2Score)
        {
            winner = "Ganador jugador rojo";
        }
        else if (player1Score>player2Score)
        {
            winner = "Ganador jugador azul";
        }

        return winner;
    }

    public int numberwinner()
    {
        int winner = 2;
        if (player1Score < player2Score)
        {
            winner = 1;
        }
        else if (player1Score > player2Score)
        {
            winner = 0;
        }

        return winner;
    }
    IEnumerator GameCicle()
    {
        gameTimer = 90f;
        while (gameTimer > 0)
        {
            DecreaseTimer();
            yield return null;
        }

        ui.ShowWinner(PlayerWinner(), numberwinner());
        gameTimer = 0;
        StopCoroutine(GameCicle());
        inGame = false;
    }


}
