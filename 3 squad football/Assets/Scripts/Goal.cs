using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    
    public Material[] material; // blue black red
    private Renderer rend;
    private GameObject ball;
    void Start()
    {
        rend = GetComponent<Renderer>();
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        //Black scored not in own goal. 
        if (other.GetComponent<Ball>()!=null)
        {
        if (other.tag == "Ball" && rend.material.color == material[0].color) //blue
        {
            GameManager.instance.ScoredInBlue();
        }
        if (other.tag == "Ball" && rend.material.color == material[1].color)//black
        {
            GameManager.instance.ScoredInBlack();
        }

        if (other.tag == "Ball" && rend.material.color == material[2].color)//red
        {
            GameManager.instance.ScoredInRed();
        }
        
        }

    }

    
}
