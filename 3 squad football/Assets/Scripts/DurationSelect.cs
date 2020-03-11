using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DurationSelect : MonoBehaviour
{
    float Time = 120f;
    public string[] times;
    public float[] timeduration;
    int index;
    public float horizontal;
    public bool delay;
    public bool ready;
    public Button Play;
    public string currentTime;
    public Text timeActual;


    void Start()
    {
        Time = timeduration[index];
        SetTime();
      
    }

    public void SetTime(/*float time*/)
    {
        PlayerPrefs.SetFloat("GameDuration", Time);
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal == 1 && !delay || horizontal == -1 && !delay)
        {
            GiveMeIndex();
        }
        if (Input.GetButton("okMenu") && !ready || Input.GetButton("Start") && !ready)
        {
            Play.Select();
        }
        else if (Input.GetButton("okMenu") && ready || Input.GetButton("Start") && ready)
        {
            Play.Select();
        }
    }

    public int GiveMeIndex()
    {
        delay = true;
        index += (int)horizontal;
        Normalizar();
        StartCoroutine(Delay());
        ChangeTime();
        return index;
    }

    public int Normalizar()
    {
        if (index < 0)
        {
            index = 4;
        }
        if (index > 4)
        {
            index = 0;
        }
        return index;
    }


    IEnumerator Delay()
    {
        delay = true;
        yield return new WaitForSeconds(0.2f);
        delay = false;
    }

    public void ChangeTime()
    {
        StartCoroutine(Delay());
        currentTime = times[index];
        timeActual.text = currentTime;
        Time = timeduration[index];
    }


}
