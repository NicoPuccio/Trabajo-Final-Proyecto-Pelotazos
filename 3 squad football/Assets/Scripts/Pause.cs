using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool pause;
    public UIManager ui;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause") && GameManager.instance.inGame)
        {
            PauseGame();
        } 
    }

    public void PauseGame()
    {
        if (!pause)
        {
            pause = true;
            Time.timeScale = 0;
            ui.ShowPauseMenu();
        }
        else
        {
            pause = false;
            Time.timeScale = 1;
            ui.StopShowPauseMenu();
        }
    }
}
