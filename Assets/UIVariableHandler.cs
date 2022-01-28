using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIVariableHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject clickBall;
    [SerializeField] private GameObject autoBall;
    [SerializeField] private GameObject currentButton;
    [SerializeField] private GameObject upgradeBallScriptObject;
    [SerializeField] private GameObject upgradeObjectScriptObject;
    [SerializeField] private GameObject bonusGate1;
    public GameObject gameRun;
    public Color colorGreen = new Color(0.75f, 1, 0.7817f, 1);
    public Color colorWhite = new Color(1, 1, 1, 1);
    void Start()
    {
        gameRun = GameObject.Find("GameRun");
    }

    // Update is called once per frame
    void Update()
    {
        UpgradeMenuVariables();
        GameUIVariables();


    }

    private void GameUIVariables()
    {
        if (bonusGate1)
        {
            bonusGate1.GetComponent<TextMeshProUGUI>().text = "X " + Math.Round(gameRun.GetComponent<ImageFade>().scoreValue * gameRun.GetComponent<ImageFade>().scoreMultiplier, 2).ToString();

        }
    }
    private void UpgradeMenuVariables()
    {
        
        //Ball damagers
        if (clickBall)
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Dmg: " + Math.Round(clickBall.GetComponent<Damager>().damageMultiplier, 2).ToString();
            
        }
        if (autoBall)
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Dmg: " + Math.Round(autoBall.GetComponent<Damager>().damageMultiplier, 2).ToString();
        }

        //ball costs
        if (upgradeBallScriptObject && gameObject.name == "ClickballCurrentCost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeBallCost.ToString();
            if (gameRun.GetComponent<ImageFade>().score >= upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeBallCost)
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorGreen;
            }
            else
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorWhite;
            }


        }
        if (upgradeBallScriptObject && gameObject.name == "IdleCurrentCost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeIdleBallCost.ToString();
            if (gameRun.GetComponent<ImageFade>().score >= upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeIdleBallCost)
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorGreen;
            }
            else
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorWhite;

            }
        }
        if (upgradeBallScriptObject && gameObject.name == "UnlockIdleCost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeIdleBallCost.ToString();
            if (gameRun.GetComponent<ImageFade>().score >= upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeIdleBallCost)
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorGreen;
            }
            else
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorWhite;

            }
        }
        if (upgradeBallScriptObject && gameObject.name == "MaxBallsCost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeMaxBallsCost.ToString();
            if (gameRun.GetComponent<ImageFade>().score >= upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeMaxBallsCost)
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorGreen;
            }
            else
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorWhite;

            }
        }
        if (upgradeBallScriptObject && gameObject.name == "MaxIdleBallsCost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeMaxIdleBallsCost.ToString();
            if (gameRun.GetComponent<ImageFade>().score >= upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeMaxIdleBallsCost)
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorGreen;
            }
            else
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorWhite;

            }
        }        
        if (upgradeBallScriptObject && gameObject.name == "UnlockMultiCost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeMultiBallCost.ToString();
            if (gameRun.GetComponent<ImageFade>().score >= upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeMultiBallCost)
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorGreen;
            }
            else
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorWhite;

            }
        }
        if (upgradeBallScriptObject && gameObject.name == "UpgradeMultiCost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeMultiBallCost.ToString();
            if (gameRun.GetComponent<ImageFade>().score >= upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeMultiBallCost)
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorGreen;
            }
            else
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorWhite;

            }
        }
        if (upgradeBallScriptObject && gameObject.name == "MaxMultiBallsCost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeMaxMultiBallsCost.ToString();
            if (gameRun.GetComponent<ImageFade>().score >= upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeMaxMultiBallsCost)
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorGreen;
            }
            else
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorWhite;

            }
        }
        if (upgradeBallScriptObject && gameObject.name == "UnlockDestructionCost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeDestructionBallCost.ToString();
            if (gameRun.GetComponent<ImageFade>().score >= upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeDestructionBallCost)
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorGreen;
            }
            else
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorWhite;

            }
        }



        //ObstaclCosts
        if (upgradeObjectScriptObject && gameObject.name == "Obstacle1Cost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeObjectScriptObject.GetComponent<UpgradeObstacles>().upgradeObstacleCost.ToString();
            if (gameRun.GetComponent<ImageFade>().score >= upgradeObjectScriptObject.GetComponent<UpgradeObstacles>().upgradeObstacleCost)
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorGreen;
            }
            else
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorWhite;

            }
        }
        if (upgradeObjectScriptObject && gameObject.name == "Obstacle2Cost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeObjectScriptObject.GetComponent<UpgradeObstacles>().upgradeObstacleCost2.ToString();
            if (gameRun.GetComponent<ImageFade>().score >= upgradeObjectScriptObject.GetComponent<UpgradeObstacles>().upgradeObstacleCost2)
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorGreen;
            }
            else
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorWhite;

            }
        }
        if (upgradeObjectScriptObject && gameObject.name == "Obstacle3Cost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeObjectScriptObject.GetComponent<UpgradeObstacles>().upgradeObstacleCost3.ToString();
            if (gameRun.GetComponent<ImageFade>().score >= upgradeObjectScriptObject.GetComponent<UpgradeObstacles>().upgradeObstacleCost3)
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorGreen;
            }
            else
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorWhite;

            }
        }
        if (upgradeObjectScriptObject && gameObject.name == "Obstacle4Cost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeObjectScriptObject.GetComponent<UpgradeObstacles>().upgradeObstacleCost4.ToString();
            if (gameRun.GetComponent<ImageFade>().score >= upgradeObjectScriptObject.GetComponent<UpgradeObstacles>().upgradeObstacleCost4)
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorGreen;
            }
            else
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorWhite;

            }
        }
        
        if (upgradeObjectScriptObject && gameObject.name == "Obstacle5Cost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeObjectScriptObject.GetComponent<UpgradeObstacles>().upgradeObstacleCost5.ToString();
            if (gameRun.GetComponent<ImageFade>().score >= upgradeObjectScriptObject.GetComponent<UpgradeObstacles>().upgradeObstacleCost5)
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorGreen;
            }
            else
            {
                gameObject.GetComponentInParent<UnityEngine.UI.Image>().color = colorWhite;

            }
        }

    }
}
