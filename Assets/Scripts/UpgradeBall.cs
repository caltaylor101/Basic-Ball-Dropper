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
    public double upgradeMultiBallCost = 1000;
    public int upgradeDestructionBallCost = 20000;

    // max ball variables
    public int upgradeMaxBallsCost = 10;
    public int upgradeMaxIdleBallsCost = 10;
    public int upgradeMaxMultiBallsCost = 50;
    public int upgradeMaxDestructionBallsCost = 20000;
    public GameObject maxIdleBallsButton;

    // MultiBall
    public GameObject unlockMultiButton;
    public GameObject multiBallSpawnSpot;
    public GameObject upgradeMultiButton;
    public GameObject multiBall;
    public GameObject plusMultiBallButton;
    public GameObject bonusGate;
    public GameObject bonusGate2;
    public GameObject bonusGate3;
    public GameObject bonusGate4;

    // Destrution Ball
    public GameObject unlockDestructionButton;
    public GameObject destructionBallSpawnSpot;
    public GameObject upgradeDestructionButton;
    public GameObject destructionBall;
    public GameObject plusDestructionBallButton;





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
            if (unlockMultiButton != null)
            {
                unlockMultiButton.SetActive(true);
            }

        }
        if (gameRun.GetComponent<ImageFade>().multiBallSpawn)
        {
            if (upgradeMultiButton != null)
            {
                upgradeMultiButton.SetActive(true);
                upgradeMultiButton.SetActive(true);
            }
            if (unlockMultiButton != null)
            {
                unlockMultiButton.SetActive(false);
            }
            if (plusMultiBallButton != null)
            {
                plusMultiBallButton.SetActive(true);
            }

        }

        if (gameRun.GetComponent<ImageFade>().multiBallSpawn)
        {
            if (unlockDestructionButton != null)
            {
                unlockDestructionButton.SetActive(true);
                unlockDestructionButton.SetActive(true);
            }
        }

        if (gameRun.GetComponent<ImageFade>().destructionBallSpawn)
        {
            if (upgradeDestructionButton != null)
            {
                upgradeDestructionButton.SetActive(true);
                upgradeDestructionButton.SetActive(true);
            }
            if (unlockDestructionButton != null)
            {
                unlockDestructionButton.SetActive(false);
            }
            if (plusDestructionBallButton != null)
            {
                plusDestructionBallButton.SetActive(true);
            }

        }




    }



    private void Start()
    {
        upgradeBallCost = gameRun.GetComponent<ImageFade>().upgradeBallCost;
        upgradeIdleBallCost = gameRun.GetComponent<ImageFade>().upgradeIdleBallCost;
        upgradeMaxBallsCost = gameRun.GetComponent<ImageFade>().upgradeMaxBallsCost;
        upgradeMaxIdleBallsCost = gameRun.GetComponent<ImageFade>().upgradeMaxIdleBallsCost;
        upgradeMaxMultiBallsCost = gameRun.GetComponent<ImageFade>().upgradeMaxMultiBallsCost;
        upgradeMultiBallCost = gameRun.GetComponent<ImageFade>().upgradeMultiBallCost;
        upgradeDestructionBallCost = gameRun.GetComponent<ImageFade>().upgradeDestructionBallCost;
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

        SaveBallVariables();

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
            upgradeMultiBallCost += 1500;
            gameRun.GetComponent<ImageFade>().upgradeMultiBallCost = upgradeMultiBallCost;
            multiBallSpawnSpot.SetActive(true);
            gameRun.GetComponent<ImageFade>().multiBallSpawn = true;
            upgradeMultiButton.SetActive(true);
            upgradeMultiButton.SetActive(true);
            upgradeDestructionButton.SetActive(true);
            upgradeDestructionButton.SetActive(true);
            Destroy(gameObject);
            SaveBallVariables();
        }
    }
            public void UnlockDestructionBall()
    {
        if (gameRun.GetComponent<ImageFade>().score >= upgradeDestructionBallCost)
        {
            gameRun.GetComponent<ImageFade>().scoreCalculator -= upgradeDestructionBallCost;
            upgradeDestructionBallCost += 20000;
            gameRun.GetComponent<ImageFade>().upgradeDestructionBallCost = upgradeDestructionBallCost;
            destructionBallSpawnSpot.SetActive(true);
            gameRun.GetComponent<ImageFade>().destructionBallSpawn = true;
            upgradeDestructionButton.SetActive(true);
            upgradeDestructionButton.SetActive(true);
            Destroy(gameObject);
            SaveBallVariables();
        }
    }

    public void UpgradeMultiBall()
    {
        if (gameRun.GetComponent<ImageFade>().score >= upgradeMultiBallCost)
        {
            gameRun.GetComponent<ImageFade>().scoreCalculator = gameRun.GetComponent<ImageFade>().scoreCalculator - upgradeMultiBallCost;
            multiBall.GetComponent<Damager>().damageMultiplier += Math.Round(0.06f, 2);
            gameRun.GetComponent<ImageFade>().upgradeMultiBallCost += 1500;
            bonusGate.GetComponent<BonusGate>().numberOfMultiBalls += 1;
            bonusGate2.GetComponent<BonusGate>().numberOfMultiBalls += 1;
            bonusGate3.GetComponent<BonusGate>().numberOfMultiBalls += 1;
            bonusGate4.GetComponent<BonusGate>().numberOfMultiBalls += 1;
        }
        upgradeMultiBallCost = gameRun.GetComponent<ImageFade>().upgradeMultiBallCost;
        SaveBallVariables();
    }
        public void UpgradeDestructionBall()
    {
        if (gameRun.GetComponent<ImageFade>().score >= upgradeDestructionBallCost)
        {
            gameRun.GetComponent<ImageFade>().scoreCalculator = gameRun.GetComponent<ImageFade>().scoreCalculator - upgradeDestructionBallCost;
            destructionBall.GetComponent<Destruction>().maxDestructionBounce += 1;
            gameRun.GetComponent<ImageFade>().maxDestructionBounce += 1;
            gameRun.GetComponent<ImageFade>().upgradeDestructionBallCost += 20000;
        }
        upgradeDestructionBallCost = gameRun.GetComponent<ImageFade>().upgradeDestructionBallCost;
        SaveDestructionBall saveDestruction = new SaveDestructionBall();
        saveDestruction.maxDestructionBounce = gameRun.GetComponent<ImageFade>().maxDestructionBounce;
        SaveManager.SaveDestructionBall(saveDestruction);
        SaveBallVariables();
    }

    private void SaveBallVariables()
    {
        UpgradeBallVariables saveObject = new UpgradeBallVariables();
        saveObject.upgradeBallCost = gameRun.GetComponent<ImageFade>().upgradeBallCost;
        saveObject.upgradeIdleBallCost = gameRun.GetComponent<ImageFade>().upgradeIdleBallCost;
        saveObject.upgradeMaxBallsCost = gameRun.GetComponent<ImageFade>().upgradeMaxBallsCost;
        saveObject.upgradeMaxIdleBallsCost = gameRun.GetComponent<ImageFade>().upgradeMaxIdleBallsCost;
        saveObject.upgradeMultiBallCost = gameRun.GetComponent<ImageFade>().upgradeMultiBallCost;
        saveObject.upgradeMaxMultiBallsCost = gameRun.GetComponent<ImageFade>().upgradeMaxMultiBallsCost;
        saveObject.numberOfMultiBalls = gameRun.GetComponent<ImageFade>().numberOfMultiBalls;
        saveObject.upgradeDestructionBallCost = gameRun.GetComponent<ImageFade>().upgradeDestructionBallCost;
        saveObject.upgradeMaxDestructionBallsCost = gameRun.GetComponent<ImageFade>().upgradeMaxDestructionBallsCost;

        SaveManager.SaveUpgradeBallVariables(saveObject);
    }

    public void UpgradeIdleBall()
    {
        if (gameRun.GetComponent<ImageFade>().score >= upgradeIdleBallCost )
        {
            gameRun.GetComponent<ImageFade>().scoreCalculator = gameRun.GetComponent<ImageFade>().scoreCalculator - upgradeIdleBallCost;
            upgradeIdleBallCost = (int)Math.Ceiling((float)upgradeIdleBallCost * 1.15f);
            autoBall.GetComponent<Damager>().damageMultiplier += Math.Round(0.06f, 2);
        }
        gameRun.GetComponent<ImageFade>().upgradeIdleBallCost = upgradeIdleBallCost;
   
        SaveBallVariables();
    }

    public void PlusOneMaxBall()
    {
        if (gameRun.GetComponent<ImageFade>().score >= upgradeMaxBallsCost)
        {
            gameRun.GetComponent<ImageFade>().scoreCalculator = gameRun.GetComponent<ImageFade>().scoreCalculator - upgradeMaxBallsCost;
            if (upgradeMaxBallsCost <= 2000 && gameRun.GetComponent<ImageFade>().maxBalls <= 20)
            {
                upgradeMaxBallsCost = (int)Math.Ceiling((float)upgradeMaxBallsCost * 1.5f);
            }
            gameRun.GetComponent<ImageFade>().maxBalls += 1;
        }

        gameRun.GetComponent<ImageFade>().upgradeMaxBallsCost = upgradeMaxBallsCost;

        SaveBallVariables();
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

        SaveBallVariables();
    }
        public void PlusMultiBall()
    {
        if (gameRun.GetComponent<ImageFade>().score >= upgradeMaxMultiBallsCost)
        {
            upgradeMaxMultiBallsCost = gameRun.GetComponent<ImageFade>().upgradeMaxMultiBallsCost;
            gameRun.GetComponent<ImageFade>().scoreCalculator = gameRun.GetComponent<ImageFade>().scoreCalculator - upgradeMaxMultiBallsCost;
            if (upgradeMaxMultiBallsCost <= 2000 && gameRun.GetComponent<ImageFade>().maxMultiBalls <= 20)
            {
                upgradeMaxMultiBallsCost = (int)Math.Ceiling((float)upgradeMaxMultiBallsCost * 1.5f);
            }
            else
            {
                upgradeMaxMultiBallsCost = (int)Math.Ceiling((float)upgradeMaxMultiBallsCost * 1.5f);
            }
            gameRun.GetComponent<ImageFade>().maxMultiBalls += 1;
        }
        gameRun.GetComponent<ImageFade>().upgradeMaxMultiBallsCost = upgradeMaxMultiBallsCost;
        gameRun.GetComponent<ImageFade>().SaveGame();
        SaveBallVariables();
    }


 
}
