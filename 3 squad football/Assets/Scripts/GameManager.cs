using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] goals;
    private int blackScore = 20;
    private int blueScore = 20;
    private int redScore = 20;
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

    public void ScoredInBlack()
    {
        //ball.GetComponent<Ball>().Dissapear();
        blackScore -= 1;
        Debug.Log("Puntaje del equipo negro: " + blackScore);
        ball.GetComponent<Ball>().Respawn();
    }

    public void ScoredInBlue()
    {
       
        blueScore -= 1;
        Debug.Log("Puntaje del equipo azul: " + blueScore);
        ball.GetComponent<Ball>().Respawn();
    }
    
    public void ScoredInRed()
    {
        
        redScore -= 1;
        Debug.Log("Puntaje del equipo rojo: " + redScore);
        ball.GetComponent<Ball>().Respawn();
    }
  
}
