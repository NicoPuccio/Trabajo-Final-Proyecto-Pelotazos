using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSelectorManager : MonoBehaviour
{

    public float horizontal;
    public Sprite[] mapImage;
    public string[] mapNames;
    public Image currentMap;
     public string mapName;
    public Button Play;
    public int index;
    public bool delay;

    public bool ready;

    private void Start()
    {
        currentMap.sprite = mapImage[0];
        //mapName.text = mapNames[0];
       // Play.Select();
        mapName = mapNames[index];
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal == 1 && !delay || horizontal == -1 && !delay)
        {
            GiveMeIndex();
        }
        if (Input.GetButton("Fire1") && !ready)
        {
            Play.Select();
        }
        else if (Input.GetButton("Fire1") && ready)
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
        ChangeMap();
        return index;
    }

    public int Normalizar()
    {
        if (index < 0)
        {
            index = 2;
        }
        if (index > 2)
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

    public void LoadLevel()
    {
        SceneManager.LoadScene(mapName);
    }

    public void ChangeMap()
    {
        StartCoroutine(Delay());
        currentMap.sprite = mapImage[index];
        mapName = mapNames[index];
        //index++;
    }


}
