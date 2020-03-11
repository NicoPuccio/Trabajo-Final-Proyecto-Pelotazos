using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameObject Menu;
    public GameObject MapSelector;
    public GameObject durationSelector;
    public bool selectmap;


    void Start()
    {
        Menu.SetActive(true);
        MapSelector.SetActive(false);
        durationSelector.SetActive(false);
    }

    void Update()
    {
        if (selectmap&& Input.GetKey(KeyCode.Escape) || Input.GetButton("Back"))
        {
            Menu.SetActive(true);
            selectmap = false;
        }
    }

    public void SelectDuration()
    {
        Menu.SetActive(false);
        MapSelector.SetActive(false);
        durationSelector.SetActive(true);
    }

    public void SelectMap()
    {
        Menu.SetActive(false);
        MapSelector.SetActive(true);
        selectmap = true;
    }

}
