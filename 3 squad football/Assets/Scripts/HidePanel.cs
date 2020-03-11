using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanel : MonoBehaviour
{
    public bool isActive;

    void Update()
    {
        if (isActive)
        {
            if (Input.GetKey(KeyCode.Escape) || Input.GetButton("Back"))
            {
                gameObject.SetActive(false);
                isActive = false;
            }
        }
       
    }


   
}
