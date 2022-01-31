using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] obstacles;
    public GameObject gameRun;
    public int upgradeObstacleCost = 10;
    public int upgradeObstacleCost2 = 50;

    public GameObject hourglassImage;
    public GameObject hourglassCollider;
    public int upgradeObstacleCost3 = 200;
    public int upgradeObstacleCost4 = 500;
    public int upgradeObstacleCost5 = 1000;

    // To save scale
    public float positionX;
    public float positionY;
    public float positionZ;


    void Start()
    {
        UpdateObstacles();
    }

    private void UpdateObstacles()
    {
        upgradeObstacleCost = gameRun.GetComponent<ImageFade>().upgradeObstacleCost;
        upgradeObstacleCost2 = gameRun.GetComponent<ImageFade>().upgradeObstacleCost2;
        upgradeObstacleCost3 = gameRun.GetComponent<ImageFade>().upgradeObstacleCost3;
        upgradeObstacleCost4 = gameRun.GetComponent<ImageFade>().upgradeObstacleCost4;
        upgradeObstacleCost5 = gameRun.GetComponent<ImageFade>().upgradeObstacleCost5;
    }

    public void LoggingTest()
    {
        Debug.Log("obstacle 1 " + upgradeObstacleCost);
        Debug.Log("obstacle 2 " + upgradeObstacleCost2);
        Debug.Log("obstacle 3 " + upgradeObstacleCost3);
        Debug.Log("obstacle 4 " + upgradeObstacleCost4);
        Debug.Log("obstacle 5 " + upgradeObstacleCost5);
    }

    public void UpgradeObstacle1()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle1");

        if (gameRun.GetComponent<ImageFade>().score >= upgradeObstacleCost)
        {
            gameRun.GetComponent<ImageFade>().scoreCalculator = gameRun.GetComponent<ImageFade>().scoreCalculator - upgradeObstacleCost;
            gameRun.GetComponent<ImageFade>().upgradeObstacleCost = (int)System.Math.Ceiling((float)upgradeObstacleCost * 1.33f);
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<Transform>().localScale = obstacle.GetComponent<Transform>().localScale - new Vector3(0.04f, 0.04f, 0.04f);
                positionX = obstacle.GetComponent<Transform>().localScale.x;
                positionY = obstacle.GetComponent<Transform>().localScale.y;
                positionZ = obstacle.GetComponent<Transform>().localScale.z;
            }

            UpdateObstacles();
            SaveUpgradeObstacleVariables();

            SaveUpgradeObstacle1 saveObject = new SaveUpgradeObstacle1();
            saveObject.positionX = positionX;
            saveObject.positionY = positionY;
            saveObject.positionZ = positionZ;
            SaveManager.SaveUpgradeObstacle1Scale(saveObject);

        }

    }

    private void SaveUpgradeObstacleVariables()
    {
        ObstacleVariables saveObject = new ObstacleVariables();
        saveObject.upgradeObstacleCost = upgradeObstacleCost;
        saveObject.upgradeObstacleCost2 = upgradeObstacleCost2;
        saveObject.upgradeObstacleCost3 = upgradeObstacleCost3;
        saveObject.upgradeObstacleCost4 = upgradeObstacleCost4;
        saveObject.upgradeObstacleCost5 = upgradeObstacleCost5;
        SaveManager.SaveUpgradeObstacleVariables(saveObject);
    }

    public void UpgradeObstacle2()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle2");

        if (gameRun.GetComponent<ImageFade>().score >= upgradeObstacleCost2)
        {
            gameRun.GetComponent<ImageFade>().scoreCalculator = gameRun.GetComponent<ImageFade>().scoreCalculator - upgradeObstacleCost2;
            gameRun.GetComponent<ImageFade>().upgradeObstacleCost2 = (int)System.Math.Ceiling((float)upgradeObstacleCost2 * 1.25f);
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<Transform>().localScale = obstacle.GetComponent<Transform>().localScale - new Vector3(0.1f, 0f, 0.1f);
                positionX = obstacle.GetComponent<Transform>().localScale.x;
                positionY = obstacle.GetComponent<Transform>().localScale.y;
                positionZ = obstacle.GetComponent<Transform>().localScale.z;
            }

            SaveUpgradeObstacle1 saveObject = new SaveUpgradeObstacle1();
            saveObject.positionX = positionX;
            saveObject.positionY = positionY;
            saveObject.positionZ = positionZ;
            SaveManager.SaveUpgradeObstacle2Scale(saveObject);

            UpdateObstacles();
            SaveUpgradeObstacleVariables();

        }
    }

    public void UpgradeObstacle3()
    {
        if (gameRun.GetComponent<ImageFade>().score >= upgradeObstacleCost3)
        {
            gameRun.GetComponent<ImageFade>().scoreCalculator = gameRun.GetComponent<ImageFade>().scoreCalculator - upgradeObstacleCost3;
            gameRun.GetComponent<ImageFade>().upgradeObstacleCost3 = (int)System.Math.Ceiling((float)upgradeObstacleCost3 * 1.15f);
            hourglassImage.GetComponent<Transform>().localScale += new Vector3(.02f, .0f, .0f);
            hourglassCollider.GetComponent<Transform>().localScale += new Vector3(.02f, .0f, .0f);
            positionX = hourglassCollider.GetComponent<Transform>().localScale.x;
            positionY = hourglassCollider.GetComponent<Transform>().localScale.y;
            positionZ = hourglassCollider.GetComponent<Transform>().localScale.z;
            SaveUpgradeObstacle1 saveObject = new SaveUpgradeObstacle1();
            saveObject.positionX = positionX;
            saveObject.positionY = positionY;
            saveObject.positionZ = positionZ;
            SaveManager.SaveUpgradeObstacle3Scale(saveObject);
            UpdateObstacles();
            SaveUpgradeObstacleVariables();
        }
    }

    public void UpgradeObstacle4()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle4");

        if (gameRun.GetComponent<ImageFade>().score >= upgradeObstacleCost4)
        {
            gameRun.GetComponent<ImageFade>().scoreCalculator = gameRun.GetComponent<ImageFade>().scoreCalculator - upgradeObstacleCost4;
            gameRun.GetComponent<ImageFade>().upgradeObstacleCost4 = (int)System.Math.Ceiling((float)upgradeObstacleCost4 * 1.33f);
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<Transform>().localScale = obstacle.GetComponent<Transform>().localScale - new Vector3(0.6f, .0f, 0.1f);
                positionX = obstacle.GetComponent<Transform>().localScale.x;
                positionY = obstacle.GetComponent<Transform>().localScale.y;
                positionZ = obstacle.GetComponent<Transform>().localScale.z;
            }

            SaveUpgradeObstacle1 saveObject = new SaveUpgradeObstacle1();
            saveObject.positionX = positionX;
            saveObject.positionY = positionY;
            saveObject.positionZ = positionZ;
            SaveManager.SaveUpgradeObstacle4Scale(saveObject);
            UpdateObstacles();
            SaveUpgradeObstacleVariables();
        }
    }
    public void UpgradeObstacle5()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle5");
        
        float sizeDifference = 0.05f;

        if (gameRun.GetComponent<ImageFade>().score >= upgradeObstacleCost5)
        {
            gameRun.GetComponent<ImageFade>().scoreCalculator = gameRun.GetComponent<ImageFade>().scoreCalculator - upgradeObstacleCost5;
            gameRun.GetComponent<ImageFade>().upgradeObstacleCost5 = (int)System.Math.Ceiling((float)upgradeObstacleCost5 * 1.33f);
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<Transform>().localScale = obstacle.GetComponent<Transform>().localScale - new Vector3(sizeDifference, sizeDifference, 0.1f);
            }


            SaveUpgradeObstacle5 newObstacle = new SaveUpgradeObstacle5();
            newObstacle = SaveManager.LoadObstacle5();
            if (newObstacle.sizeDifference != 0)
            {
                sizeDifference = newObstacle.sizeDifference;                         
            }

            sizeDifference += .05f;

            SaveUpgradeObstacle5 saveObject = new SaveUpgradeObstacle5();
            saveObject.sizeDifference = sizeDifference;
            SaveManager.SaveUpgradeObstacle5Scale(saveObject);
            UpdateObstacles();
            SaveUpgradeObstacleVariables();
        }
    }
}
