using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text golPlayer1;
    public Text golPlayer2;
    public Text timer;
    public Text gol;

    public void UpdateStats()
    {
        golPlayer1.text = GameManager.instance.player1Score.ToString();
        golPlayer2.text = GameManager.instance.player2Score.ToString();
    }
 
    public void ShowMenu()
    {
        //to do
    }

    public void ShowWinner()
    {
        if (GameManager.instance.player1Score > GameManager.instance.player2Score)
        {
            Debug.Log("Player 1 Victory!");
        }
        else if (GameManager.instance.player1Score > GameManager.instance.player2Score)
        {
            Debug.Log("Player 2 Victory!");
        }
        else
        {
            Debug.Log("It's a tie! Everyone looses");
        }
    }

    public void ShowGol()
    {
        gol.color =Color.blue;
        //2849FF blue
        //to do
    }

    public void ShowTimer()
    {
        var minutes = Mathf.Floor((GameManager.instance.gameTimer % 3600) / 60).ToString("00"); /*((int)time / 60).ToString();*/
        var seconds = (GameManager.instance.gameTimer % 60).ToString("00");
        timer.text = minutes + ":" + seconds;
    }

    private void Update()
    {
        UpdateStats();
        ShowTimer();
    }

}
