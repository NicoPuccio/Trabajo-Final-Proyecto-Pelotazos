using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    
    public Material[] ballMaterials; // blue black red
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
        if ((other.GetComponent<Ball>().GetMaterial().color == ballMaterials[1].color /*black*/) 
            && (rend.material.color != ballMaterials[1].color) /*Is not an own goal*/)
        {
            ball.GetComponent<Ball>().Dissapear();
            GameManager.instance.BlackScored();
        }
        if ((other.GetComponent<Ball>().GetMaterial().color == ballMaterials[1].color /*black*/)
            && (rend.material.color == ballMaterials[1].color) /*Is an own goal*/)
        {
            GameManager.instance.BlackScoredOwnGoal();
        }

        if ((other.GetComponent<Ball>().GetMaterial().color == ballMaterials[0].color /*blue*/)
            && (rend.material.color != ballMaterials[0].color) /*Is not an own goal*/)
        {
            GameManager.instance.BlueScored();
        }
        if ((other.GetComponent<Ball>().GetMaterial().color == ballMaterials[0].color /*blue*/)
            && (rend.material.color == ballMaterials[0].color) /*Is an own goal*/)
        {
            GameManager.instance.BlueScoredOwnGoal();
        }

        if ((other.GetComponent<Ball>().GetMaterial().color == ballMaterials[2].color /*red*/)
            && (rend.material.color != ballMaterials[2].color) /*Is not an own goal*/)
        {
            GameManager.instance.RedScored();
        }
        if ((other.GetComponent<Ball>().GetMaterial().color == ballMaterials[2].color /*red*/)
            && (rend.material.color == ballMaterials[2].color) /*Is an own goal*/)
        {
            GameManager.instance.RedScoredOwnGoal();
        }

        }

    }

    
}
