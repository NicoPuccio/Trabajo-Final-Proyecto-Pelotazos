using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{


   public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayGame(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void HowToPlayScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }
}
