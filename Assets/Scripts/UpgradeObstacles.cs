using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] obstacles;
    public GameObject gameRun;
    public int upgradeObstacleCost = 10;
    public int upgradeObstacleCost2 = 100;

    public GameObject hourglassImage;
    public GameObject hourglassCollider;
    public int upgradeObstacleCost3 = 1000;
    public void UpgradeObstacle1()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle1");
        if (gameRun.GetComponent<ImageFade>().score >= upgradeObstacleCost)
        {
            gameRun.GetComponent<ImageFade>().score = gameRun.GetComponent<ImageFade>().score - upgradeObstacleCost;
            upgradeObstacleCost = (int)System.Math.Ceiling((float)upgradeObstacleCost * 1.75f);
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<Transform>().localScale = obstacle.GetComponent<Transform>().localScale - new Vector3(0.04f, 0.04f, 0.04f);
            }
        }

    }

    public void UpgradeObstacle2()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle2");

        if (gameRun.GetComponent<ImageFade>().score >= upgradeObstacleCost2)
        {
            gameRun.GetComponent<ImageFade>().score = gameRun.GetComponent<ImageFade>().score - upgradeObstacleCost2;
            upgradeObstacleCost2 = (int)System.Math.Ceiling((float)upgradeObstacleCost2 * 1.75f);
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<Transform>().localScale = obstacle.GetComponent<Transform>().localScale - new Vector3(0.02f, 0.02f, 0.02f);
            }
        }
    }

    public void UpgradeObstacle3()
    {
        if (gameRun.GetComponent<ImageFade>().score >= upgradeObstacleCost3)
        {
            gameRun.GetComponent<ImageFade>().score = gameRun.GetComponent<ImageFade>().score - upgradeObstacleCost3;
            upgradeObstacleCost3 = (int)System.Math.Ceiling((float)upgradeObstacleCost3 * 1.75f);
            hourglassImage.GetComponent<Transform>().localScale += new Vector3(.02f, .0f, .0f);
            hourglassCollider.GetComponent<Transform>().localScale += new Vector3(.02f, .0f, .0f);
            
        }
    }
}
