using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameObject Menu;
    public GameObject MapSelector;
    public bool selectmap;


    void Start()
    {
        Menu.SetActive(true);
        MapSelector.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (selectmap&& Input.GetKey(KeyCode.Escape) || Input.GetButton("Back"))
        {
            Menu.SetActive(true);
            selectmap = false;
        }
        
    }

    public void SelectMap()
    {
        Menu.SetActive(false);
        MapSelector.SetActive(true);
        selectmap = true;
    }
}
