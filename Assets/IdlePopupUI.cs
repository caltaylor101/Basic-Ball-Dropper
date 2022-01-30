using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePopupUI : MonoBehaviour
{
    [SerializeField] private GameObject gameRun;
    [SerializeField] private GameObject rewardText;
    [SerializeField] private GameObject watchVideoButtonText;
    [SerializeField] private GameObject noThanksText;
    [SerializeField] private GameObject adManager;
    [SerializeField] private GameObject idlePopup;
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
            rewardText.GetComponent<UnityEngine.UI.Text>().text = "Welcome Back! You were gone for over " + Math.Floor(minutesAway).ToString() + " minutes! You earned a total of " + Math.Floor(idleReward);
        }
        else
        {
            rewardText.GetComponent<UnityEngine.UI.Text>().text = "Welcome Back! You were gone for " + Math.Floor(minutesAway).ToString() + " minutes! You earned a total of " + Math.Floor(idleReward);
        }
        watchVideoButtonText.GetComponent<UnityEngine.UI.Text>().text = "Watch a video for: " + Math.Floor((idleReward * 2)).ToString();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void WatchIdleReward()
    {
        adManager.GetComponent<AdManager>().UserChoseToDoubleIdleReward();
        idlePopup.SetActive(false);
    }

    public void NoThanksClose()
    {
        idlePopup.SetActive(false);
        gameRun.GetComponent<Advertising>().RegularIdleRewardPlayer();
    }
}
