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
        upgradeIdleButton.SetActive(true);
        idleBallSpawnSpot.SetActive(true);
        gameRun.GetComponent<ImageFade>().autoBallSpawn = true;
        gameObject.SetActive(false);
        Destroy(gameObject);
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
            upgradeMaxBallsCost = (int)Math.Ceiling((float)upgradeMaxBallsCost * 1.33f);
            gameRun.GetComponent<ImageFade>().maxBalls += 1;
        }
    }


 
}
