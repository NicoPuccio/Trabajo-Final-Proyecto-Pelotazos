using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] goals;
    public int blackScore = 0;
    public int blueScore = 0;
    public int redScore = 0;
    public static GameManager instance;

    public GameObject ball;
    

    private void Start()
    {
        goals = GameObject.FindGameObjectsWithTag("Goal");
        ball = GameObject.FindGameObjectWithTag("Ball");
        instance = this;
    }

    void Update()
    {
        
    }

    public void BlackScored()
    {
        //ball.GetComponent<Ball>().Dissapear();
        blackScore += 1;
        Debug.Log("Puntaje del equipo negro: " + blackScore);
        ball.GetComponent<Ball>().Respawn();
    }

    public void BlackScoredOwnGoal()
    {
        ball.GetComponent<Ball>().Dissapear();
        blackScore -= 1;
        Debug.Log("Puntaje del equipo negro: " + blackScore);
        ball.GetComponent<Ball>().Respawn();
    }

    public void BlueScored()
    {
        ball.GetComponent<Ball>().Dissapear();
        blueScore += 1;
        Debug.Log("Puntaje del equipo azul: " + blueScore);
        ball.GetComponent<Ball>().Respawn();
    }

    public void BlueScoredOwnGoal()
    {
        ball.GetComponent<Ball>().Dissapear();
        blueScore -= 1;
        Debug.Log("Puntaje del equipo azul: " + blueScore);
        ball.GetComponent<Ball>().Respawn();
    }
    
    public void RedScored()
    {
        ball.GetComponent<Ball>().Dissapear();
        redScore += 1;
        Debug.Log("Puntaje del equipo rojo: " + redScore);
        ball.GetComponent<Ball>().Respawn();
    }
    public void RedScoredOwnGoal()
    {
        ball.GetComponent<Ball>().Dissapear();
        redScore -= 1;
        Debug.Log("Puntaje del equipo rojo: " + redScore);
        ball.GetComponent<Ball>().Respawn();
    }
}
