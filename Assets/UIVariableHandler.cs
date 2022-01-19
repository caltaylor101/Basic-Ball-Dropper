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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clickBall)
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Dmg: " + Math.Round(clickBall.GetComponent<Damager>().damageMultiplier,2).ToString();
        }
        if (autoBall)
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Dmg: " + Math.Round(autoBall.GetComponent<Damager>().damageMultiplier,2).ToString();
        }
        if (upgradeBallScriptObject && gameObject.name == "ClickballCurrentCost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeBallCost.ToString();
        }
        if (upgradeBallScriptObject && gameObject.name == "IdleCurrentCost")
        {
            currentButton.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + upgradeBallScriptObject.GetComponent<UpgradeBall>().upgradeIdleBallCost.ToString();
        }
    }
}
