using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePopupUI : MonoBehaviour
{
    [SerializeField] private GameObject gameRun;
    [SerializeField] private GameObject rewardText;
    private double minutesAway;
    private double idleReward;
    // Start is called before the first frame update
    void Start()
    {


    }
    void OnEnable()
    {
        minutesAway = gameRun.GetComponent<IdleReward>().minutesAway;
        idleReward = gameRun.GetComponent<IdleReward>().idleReward;
        if (minutesAway >= 120)
        {
            rewardText.GetComponent<UnityEngine.UI.Text>().text = "Welcome Back! You were gone for over " + Math.Floor(minutesAway).ToString() + " minutes! You earned a total of " + Math.Round(idleReward, 2);
        }
        else
        {
            rewardText.GetComponent<UnityEngine.UI.Text>().text = "Welcome Back! You were gone for " + Math.Floor(minutesAway).ToString() + " minutes!";
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
