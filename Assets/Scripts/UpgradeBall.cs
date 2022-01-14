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
    public GameObject autoBall;
    public int upgradeIdleBallCost = 10;

    // max ball variables
    public int upgradeMaxBallsCost = 10;
    public int upgradeMaxIdleBallsCost = 10;
    public GameObject maxIdleBallsButton;






    public void UpgradeBallDamage()
    {
        shatterableBoxes = GameObject.FindGameObjectsWithTag("Hittable");
        if (gameRun.GetComponent<ImageFade>().score >= upgradeBallCost)
        {
            gameRun.GetComponent<ImageFade>().score = gameRun.GetComponent<ImageFade>().score - upgradeBallCost;
            upgradeBallCost = (int)Math.Ceiling((float)upgradeBallCost * 1.25f);

            clickBall.GetComponent<Damager>().damageMultiplier += 0.01f;
        }

    }

    public void UnlockIdleBall()
    {
        if (gameRun.GetComponent<ImageFade>().score >= upgradeIdleBallCost)
        {
            gameRun.GetComponent<ImageFade>().score -= upgradeIdleBallCost;
            upgradeIdleButton.SetActive(true);
            idleBallSpawnSpot.SetActive(true);
            maxIdleBallsButton.SetActive(true);
            gameRun.GetComponent<ImageFade>().autoBallSpawn = true;
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

    }

    public void UpgradeIdleBall()
    {
        if (gameRun.GetComponent<ImageFade>().score >= upgradeIdleBallCost)
        {
            gameRun.GetComponent<ImageFade>().score = gameRun.GetComponent<ImageFade>().score - upgradeIdleBallCost;
            upgradeIdleBallCost = (int)Math.Ceiling((float)upgradeIdleBallCost * 1.33f);
            autoBall.GetComponent<Damager>().damageMultiplier += 0.01f;
        }
    }

    public void PlusOneMaxBall()
    {
        if (gameRun.GetComponent<ImageFade>().score >= upgradeMaxBallsCost)
        {
            gameRun.GetComponent<ImageFade>().score = gameRun.GetComponent<ImageFade>().score - upgradeMaxBallsCost;
            if (upgradeMaxBallsCost <= 250 && gameRun.GetComponent<ImageFade>().maxBalls <= 100)
            {
                upgradeMaxBallsCost = (int)Math.Ceiling((float)upgradeMaxBallsCost * 1.1f);
            }
            gameRun.GetComponent<ImageFade>().maxBalls += 1;
        }
    }

    public void PlusIdleBall()
    {
        if (gameRun.GetComponent<ImageFade>().score >= upgradeMaxIdleBallsCost)
        {
            gameRun.GetComponent<ImageFade>().score = gameRun.GetComponent<ImageFade>().score - upgradeMaxIdleBallsCost;
            if (upgradeMaxIdleBallsCost <= 250 && gameRun.GetComponent<ImageFade>().maxIdleBalls <= 100)
            {
                upgradeMaxIdleBallsCost = (int)Math.Ceiling((float)upgradeMaxIdleBallsCost * 1.1f);
            }
            gameRun.GetComponent<ImageFade>().maxIdleBalls += 1;
        }
    }


 
}
