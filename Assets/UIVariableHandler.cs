using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIVariableHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject clickBall;
    [SerializeField] private GameObject autoBall;
    [SerializeField] private GameObject currentButton;
    [SerializeField] private GameObject upgradeBallScriptObject;
    [SerializeField] private GameObject upgradeObjectScriptObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ball damagers
        if (clickBall)
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Dmg: " + Math.Round(clickBall.GetComponent<Damager>().damageMultiplier,2).ToString();
        }
        if (autoBall)
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Dmg: " + Math.Round(autoBall.GetComponent<Damager>().damageMultiplier,2).ToString();
        }

        //ball costs
        if (upgradeBallScriptObject && gameObject.name == "ClickballCurrentCost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeBallCost.ToString();
        }
        if (upgradeBallScriptObject && gameObject.name == "IdleCurrentCost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeIdleBallCost.ToString();
        }
        if (upgradeBallScriptObject && gameObject.name == "UnlockIdleCost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeIdleBallCost.ToString();
        }
        if (upgradeBallScriptObject && gameObject.name == "MaxBallsCost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeMaxBallsCost.ToString();
        }
        if (upgradeBallScriptObject && gameObject.name == "MaxIdleBallsCost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeMaxIdleBallsCost.ToString();
        }

        //ObstaclCosts
        if (upgradeObjectScriptObject && gameObject.name == "Obstacle1Cost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeObjectScriptObject.GetComponent<UpgradeObstacles>().upgradeObstacleCost.ToString();
        }
        if (upgradeObjectScriptObject && gameObject.name == "Obstacle2Cost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeObjectScriptObject.GetComponent<UpgradeObstacles>().upgradeObstacleCost2.ToString();
        }
        if (upgradeObjectScriptObject && gameObject.name == "Obstacle3Cost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeObjectScriptObject.GetComponent<UpgradeObstacles>().upgradeObstacleCost3.ToString();
        }


    }
}
