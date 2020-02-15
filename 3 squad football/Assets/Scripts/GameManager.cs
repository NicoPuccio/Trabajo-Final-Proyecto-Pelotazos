using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    

    private void Start()
    {
        goals = GameObject.FindGameObjectsWithTag("Goal");
        ball = GameObject.FindGameObjectWithTag("Ball");
        instance = this;
        gameTimer = 90f;
        ui = GetComponent<UIManager>();
    }

    void Update()
    {
        DecreaseTimer();
        StartCoroutine(EndGame());
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
}
