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

    private void Start()
    {
        winnerCartel.SetActive(false);
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
        Debug.Log(winner);
    }

    public void ShowGol()
    {
        gol.color =Color.blue;
        gol.color =Color.red;
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
