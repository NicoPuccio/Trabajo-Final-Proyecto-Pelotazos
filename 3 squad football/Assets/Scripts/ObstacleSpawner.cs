using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    System.Random rnd = new System.Random();
    public int countdown;

    private void Awake()
    {
        countdown = (int)GameManager.instance.gameTimer;
    }

    private void Update()
    {
        countdown -= (int)Time.deltaTime;
    }


    private IEnumerator Spawn()
    {
        while(countdown > 0)
        {
            if (countdown % 10 == 0 && obstacles != null)
            {
                Instantiate(obstacles[GetRandom()], new Vector3(0, 15, 0), Quaternion.identity);
            }
        }
        return null;
    }

    private int GetRandom()
    {
        int result = rnd.Next(0, obstacles.Length + 1);
        return result;
    }
}
