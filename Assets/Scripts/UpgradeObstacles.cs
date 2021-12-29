using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] obstacles;
    public GameObject gameRun;
    public int upgradeObstacleCost = 10;
    public void UpgradeObstacle1()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle1");
        if (gameRun.GetComponent<ImageFade>().score >= upgradeObstacleCost)
        {
            gameRun.GetComponent<ImageFade>().score = gameRun.GetComponent<ImageFade>().score - upgradeObstacleCost;
            upgradeObstacleCost = (int)System.Math.Ceiling((float)upgradeObstacleCost * 2.25f);
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<Transform>().localScale = obstacle.GetComponent<Transform>().localScale - new Vector3(0.01f, 0.01f, 0.01f);
            }
        }

    }
}
