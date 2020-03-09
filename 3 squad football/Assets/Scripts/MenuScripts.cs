using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScripts : MonoBehaviour
{
    public Button[] Buttons;
    public int index;
    public float vertical;

    private void Start()
    {
        ClickButton();
    }
    private void Update()
    {
        vertical = Input.GetAxisRaw("Horizontal");
        if (vertical==1)
        {
            ClickButton();
        }
        if (index>= Buttons.Length - 1)
        {
            index = 0;
        }
    }

    public void GoToTheNextButton()
    {
    }

    public void ClickButton()
    {
        Buttons[index].Select();
        index++;
    }
    
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
