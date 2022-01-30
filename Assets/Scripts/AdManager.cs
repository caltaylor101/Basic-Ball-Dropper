using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class AdManager : MonoBehaviour
{
    [SerializeField] private GameObject gameRun;

    // Start is called before the first frame update
    // test id for editor
    //private string adUnitId = "ca-app-pub-3940256099942544/5354046379";

    // actual ad id
    private string adUnitId = "ca-app-pub-8732055832105699/7621483920";


    private RewardedAd twoXRewardedAd;
    private bool twoXRewardedShowing = false;
    private bool idleRewardedShowing = false;
    private bool moneyRewardedShowing = false;
    private bool increaseTimerRewardedShowing = false;

    void Start()
    {
        this.twoXRewardedAd = new RewardedAd(adUnitId);
        this.twoXRewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        this.twoXRewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.twoXRewardedAd.OnAdClosed += HandleRewardedAdClosed;


        LoadRewardedAd();
        Debug.Log("the ad" + this.twoXRewardedAd);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadRewardedAd()
    {
        AdRequest request = new AdRequest.Builder().Build();
        this.twoXRewardedAd.LoadAd(request);
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        AdWorkAround();

        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }

    private void AdWorkAround()
    {
        if (twoXRewardedShowing)
        {
            gameRun.GetComponent<Advertising>().TwoXRewardPlayer();
            twoXRewardedShowing = false;
        }
        if (idleRewardedShowing)
        {
            gameRun.GetComponent<Advertising>().IdleRewardPlayer();
            idleRewardedShowing = false;
        }
        if (moneyRewardedShowing)
        {
            gameRun.GetComponent<Advertising>().MoneyRewardPlayer();
            moneyRewardedShowing = false;
        }
        if (increaseTimerRewardedShowing)
        {
            gameRun.GetComponent<Advertising>().IncreaseTimerRewardPlayer();
            increaseTimerRewardedShowing = false;
        }
    }


    public void UserChoseToWatchAd()
    {
        twoXRewardedShowing = true;
        AdWorkAround();

    }
    public void UserChoseToDoubleIdleReward()
    {

        idleRewardedShowing = true;
        AdWorkAround();


    }
    public void UserChoseToGetMoneyReward()
    {


        moneyRewardedShowing = true;
        AdWorkAround();


    }
    public void UserChoseToIncreaseTimerReward()
    {

        increaseTimerRewardedShowing = true;
        AdWorkAround();


    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        this.CreateAndLoadRewardedAd();
    }

    public void CreateAndLoadRewardedAd()
    {
        this.twoXRewardedAd = new RewardedAd(adUnitId);

        this.twoXRewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        this.twoXRewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.twoXRewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.twoXRewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("HandleRewardedAdLoaded event received");
    }
}
