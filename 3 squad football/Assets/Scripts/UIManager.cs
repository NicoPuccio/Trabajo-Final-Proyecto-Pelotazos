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
    public GameObject winnerCartel;
    public Image banner;
    public Sprite[] winbanner;
    public string whoWin;
    public Text wintext;
    public GameObject wincup;
    bool isGol;
    public float timergolpanel;
    public GameObject Gol;

    public Text player1FinalScore;
    public Text player2FinalScore;
    public GameObject pausePanel;

    private void Start()
    {
        winnerCartel.SetActive(false);
        pausePanel.SetActive(false);
    }
    public void UpdateStats()
    {
        golPlayer1.text = GameManager.instance.player1Score.ToString();
        golPlayer2.text = GameManager.instance.player2Score.ToString();
    }
 
    public void ShowMenu()
    {
        //to do
    }

    public void ShowWinner(string winner, int nrojugador)
    {
        winnerCartel.SetActive(true);
        banner.sprite = winbanner[nrojugador];
        wintext.text = winner;
        if (nrojugador != 2)
        {
            wincup.SetActive(true);
        }
        else
        {
            wincup.SetActive(false);
        }
        player1FinalScore.text = golPlayer1.text;
        player2FinalScore.text = golPlayer2.text;

        Debug.Log(winner);
    }

    public void ShowGol(int nro)
    {
        if (nro == 0)
        {
            gol.color = Color.blue;
            isGol = true;
        }
        else
        {
            gol.color = Color.red;
            isGol = true;

        }
       
       
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
        if (isGol)
        {
            timergolpanel += Time.deltaTime;
            Gol.SetActive(true);
            if (timergolpanel > 3)
            {
                Gol.SetActive(false);
                timergolpanel = 0;
                isGol = false;
            }
            
        }
        
    }

    public void ShowPauseMenu()
    {
        pausePanel.SetActive(true);
    }
    public void StopShowPauseMenu()
    {
        pausePanel.SetActive(false);
    }


}
