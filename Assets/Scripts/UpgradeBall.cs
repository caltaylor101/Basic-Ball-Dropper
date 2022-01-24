using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeBall : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] shatterableBoxes;
    public GameObject gameRun;
    public int upgradeBallCost = 10;
    public GameObject clickBall;

    //Idle Variables
    public GameObject idleBallSpawnSpot;
    public GameObject upgradeIdleButton;
    public GameObject unlockIdleButton;
    public GameObject autoBall;
    public int upgradeIdleBallCost = 10;
    public int upgradeMultiBallCost = 1000;

    // max ball variables
    public int upgradeMaxBallsCost = 10;
    public int upgradeMaxIdleBallsCost = 10;
    public int upgradeMaxMultiBallsCost = 25;
    public GameObject maxIdleBallsButton;

    // MultiBall
    public GameObject unlockMultiButton;
    public GameObject multiBallSpawnSpot;
    public GameObject upgradeMultiButton;




    private void Awake()
    {
        if (gameRun.GetComponent<ImageFade>().autoBallSpawn)
        {
            if (upgradeIdleButton != null)
            {
                upgradeIdleButton.SetActive(true);
            }
            if (unlockIdleButton != null)
            {
                unlockIdleButton.SetActive(false);
            }
            if (maxIdleBallsButton != null)
            {
                maxIdleBallsButton.SetActive(true);

            }

        }

        
    }

    

    private void Start()
    {
        upgradeBallCost = gameRun.GetComponent<ImageFade>().upgradeBallCost;
        upgradeIdleBallCost = gameRun.GetComponent<ImageFade>().upgradeIdleBallCost;
        upgradeMaxBallsCost = gameRun.GetComponent<ImageFade>().upgradeMaxBallsCost;
        upgradeMaxIdleBallsCost = gameRun.GetComponent<ImageFade>().upgradeMaxIdleBallsCost;
    }

    

    public void UpgradeBallDamage()
    {
        shatterableBoxes = GameObject.FindGameObjectsWithTag("Hittable");
        if (gameRun.GetComponent<ImageFade>().score >= upgradeBallCost)
        {
            gameRun.GetComponent<ImageFade>().scoreCalculator = gameRun.GetComponent<ImageFade>().scoreCalculator - upgradeBallCost;
            upgradeBallCost = (int)Math.Ceiling((float)upgradeBallCost * 1.10f);

            clickBall.GetComponent<Damager>().damageMultiplier += Math.Round(0.05f, 2);
        }

        gameRun.GetComponent<ImageFade>().upgradeBallCost = upgradeBallCost;

        UpgradeBallVariables saveObject = new UpgradeBallVariables();
        saveObject.upgradeBallCost = gameRun.GetComponent<ImageFade>().upgradeBallCost;
        saveObject.upgradeIdleBallCost = gameRun.GetComponent<ImageFade>().upgradeIdleBallCost;
        saveObject.upgradeMaxBallsCost = gameRun.GetComponent<ImageFade>().upgradeMaxBallsCost;
        saveObject.upgradeMaxIdleBallsCost = gameRun.GetComponent<ImageFade>().upgradeMaxIdleBallsCost;
        SaveManager.SaveUpgradeBallVariables(saveObject);

    }

    public void UnlockIdleBall()
    {
        if (gameRun.GetComponent<ImageFade>().score >= upgradeIdleBallCost)
        {
            gameRun.GetComponent<ImageFade>().scoreCalculator -= upgradeIdleBallCost;
            upgradeIdleButton.SetActive(true);
            idleBallSpawnSpot.SetActive(true);
            maxIdleBallsButton.SetActive(true);
            unlockMultiButton.SetActive(true);
            gameRun.GetComponent<ImageFade>().autoBallSpawn = true;
            Destroy(gameObject);
        }

    }
        public void UnlockMultiBall()
    {
        if (gameRun.GetComponent<ImageFade>().score >= upgradeMultiBallCost)
        {
            gameRun.GetComponent<ImageFade>().scoreCalculator -= upgradeMultiBallCost;
            upgradeMultiButton.SetActive(false);
            upgradeMultiButton.SetActive(true);
            multiBallSpawnSpot.SetActive(true);
            //maxIdleBallsButton.SetActive(true);
            //unlockMultiButton.SetActive(true);
            gameRun.GetComponent<ImageFade>().multiBallSpawn = true;
            Debug.Log(upgradeMultiButton.activeSelf);
            Destroy(gameObject);
        }

    }


    public void UpgradeIdleBall()
    {
        if (gameRun.GetComponent<ImageFade>().score >= upgradeIdleBallCost)
        {
            gameRun.GetComponent<ImageFade>().scoreCalculator = gameRun.GetComponent<ImageFade>().scoreCalculator - upgradeIdleBallCost;
            upgradeIdleBallCost = (int)Math.Ceiling((float)upgradeIdleBallCost * 1.15f);
            autoBall.GetComponent<Damager>().damageMultiplier += Math.Round(0.06f, 2);
        }
        gameRun.GetComponent<ImageFade>().upgradeIdleBallCost = upgradeIdleBallCost;

        UpgradeBallVariables saveObject = new UpgradeBallVariables();
        saveObject.upgradeBallCost = gameRun.GetComponent<ImageFade>().upgradeBallCost;
        saveObject.upgradeIdleBallCost = gameRun.GetComponent<ImageFade>().upgradeIdleBallCost;
        saveObject.upgradeMaxBallsCost = gameRun.GetComponent<ImageFade>().upgradeMaxBallsCost;
        saveObject.upgradeMaxIdleBallsCost = gameRun.GetComponent<ImageFade>().upgradeMaxIdleBallsCost;
        SaveManager.SaveUpgradeBallVariables(saveObject);
    }

    public void PlusOneMaxBall()
    {
        if (gameRun.GetComponent<ImageFade>().score >= upgradeMaxBallsCost)
        {
            gameRun.GetComponent<ImageFade>().scoreCalculator = gameRun.GetComponent<ImageFade>().scoreCalculator - upgradeMaxBallsCost;
            if (upgradeMaxBallsCost <= 250 && gameRun.GetComponent<ImageFade>().maxBalls <= 100)
            {
                upgradeMaxBallsCost = (int)Math.Ceiling((float)upgradeMaxBallsCost * 1.1f);
            }
            gameRun.GetComponent<ImageFade>().maxBalls += 1;
        }

        gameRun.GetComponent<ImageFade>().upgradeMaxBallsCost = upgradeMaxBallsCost;

        UpgradeBallVariables saveObject = new UpgradeBallVariables();
        saveObject.upgradeBallCost = gameRun.GetComponent<ImageFade>().upgradeBallCost;
        saveObject.upgradeIdleBallCost = gameRun.GetComponent<ImageFade>().upgradeIdleBallCost;
        saveObject.upgradeMaxBallsCost = gameRun.GetComponent<ImageFade>().upgradeMaxBallsCost;
        saveObject.upgradeMaxIdleBallsCost = gameRun.GetComponent<ImageFade>().upgradeMaxIdleBallsCost;
        SaveManager.SaveUpgradeBallVariables(saveObject);
    }

    public void PlusIdleBall()
    {
        if (gameRun.GetComponent<ImageFade>().score >= upgradeMaxIdleBallsCost)
        {
            gameRun.GetComponent<ImageFade>().scoreCalculator = gameRun.GetComponent<ImageFade>().scoreCalculator - upgradeMaxIdleBallsCost;
            if (upgradeMaxIdleBallsCost <= 250 && gameRun.GetComponent<ImageFade>().maxIdleBalls <= 100)
            {
                upgradeMaxIdleBallsCost = (int)Math.Ceiling((float)upgradeMaxIdleBallsCost * 1.1f);
            }
            gameRun.GetComponent<ImageFade>().maxIdleBalls += 1;
        }

        gameRun.GetComponent<ImageFade>().upgradeMaxIdleBallsCost = upgradeMaxIdleBallsCost;

        UpgradeBallVariables saveObject = new UpgradeBallVariables();
        saveObject.upgradeBallCost = gameRun.GetComponent<ImageFade>().upgradeBallCost;
        saveObject.upgradeIdleBallCost = gameRun.GetComponent<ImageFade>().upgradeIdleBallCost;
        saveObject.upgradeMaxBallsCost = gameRun.GetComponent<ImageFade>().upgradeMaxBallsCost;
        saveObject.upgradeMaxIdleBallsCost = gameRun.GetComponent<ImageFade>().upgradeMaxIdleBallsCost;
        SaveManager.SaveUpgradeBallVariables(saveObject);
    }


 
}
