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
    private string adUnitId = "ca-app-pub-3940256099942544/5224354917";
    private RewardedAd twoXRewardedAd;

    void Start()
    {
        this.twoXRewardedAd = new RewardedAd(adUnitId);
        this.twoXRewardedAd.OnUserEarnedReward += HandleUserEarnedReward;


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
        gameRun.GetComponent<Advertising>().TwoXRewardPlayer();
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }

  

    public void UserChoseToWatchAd()
    {
        if (this.twoXRewardedAd.IsLoaded())
        {
            this.twoXRewardedAd.Show();
        }
        else
        {
            CreateAndLoadRewardedAd();
            this.twoXRewardedAd.Show();
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
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }
}
