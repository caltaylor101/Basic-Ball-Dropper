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
    private string adUnitId = "ca-app-pub-3940256099942544/5354046379";
    private RewardedAd twoXRewardedAd;
    private bool twoXRewardedShowing = false;
    private bool idleRewardedShowing = false;

    void Start()
    {
        this.twoXRewardedAd = new RewardedAd(adUnitId);
        this.twoXRewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        this.twoXRewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.twoXRewardedAd.OnAdClosed += HandleRewardedAdClosed;


        LoadRewardedAd();
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

        }
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }

  

    public void UserChoseToWatchAd()
    {
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
