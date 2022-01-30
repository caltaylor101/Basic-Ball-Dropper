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

        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }

  

    public void UserChoseToWatchAd()
    {
        Debug.Log("test area");
        Debug.Log(this.twoXRewardedAd);
        if (this.twoXRewardedAd.IsLoaded())
        {
            this.twoXRewardedAd.Show();
            twoXRewardedShowing = true;
        }
        else
        {
            CreateAndLoadRewardedAd();
            this.twoXRewardedAd.Show();
            twoXRewardedShowing = true;
        }
    }
    public void UserChoseToDoubleIdleReward()
    {
        if (this.twoXRewardedAd.IsLoaded())
        {
            this.twoXRewardedAd.Show();
            idleRewardedShowing = true;
        }
        else
        {
            CreateAndLoadRewardedAd();
            this.twoXRewardedAd.Show();
            idleRewardedShowing = true;
        }

    }
    public void UserChoseToGetMoneyReward()
    {
        if (this.twoXRewardedAd.IsLoaded())
        {
            this.twoXRewardedAd.Show();
            moneyRewardedShowing = true;
        }
        else
        {
            CreateAndLoadRewardedAd();
            this.twoXRewardedAd.Show();
            moneyRewardedShowing = true;
        }

    }
    public void UserChoseToIncreaseTimerReward()
    {
        if (this.twoXRewardedAd.IsLoaded())
        {
            this.twoXRewardedAd.Show();
            increaseTimerRewardedShowing = true;
        }
        else
        {
            CreateAndLoadRewardedAd();
            this.twoXRewardedAd.Show();
            increaseTimerRewardedShowing = true;
        }

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
