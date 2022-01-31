using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleReward : MonoBehaviour
{
    private DateTime currentTime;
    private TimeSpan timeDifference;
    public double minutesAway;
    private double maxMinutesAway = 120;
    public double idleReward;
    [SerializeField] private GameObject idleRewardPopupPanel;
    [SerializeField] private GameObject clickBall;
    [SerializeField] private GameObject autoBall;
    [SerializeField] private GameObject multiBall;
    // Start is called before the first frame update
    void Awake()
    {
        currentTime = DateTime.Now;
        SaveIdleRewards so = AdSaveManager.LoadIdleRewards();
        //TimeSpan testTime = currentTime - DateTime.Parse(so.currentTime);
        timeDifference = currentTime.Subtract(DateTime.Parse(so.currentTime));
        IdleRewardPopup();

    }
    void Start()
    {

    }

    private void IdleRewardPopup()
    {
        if (minutesAway == 0)
        {
            minutesAway = timeDifference.TotalMinutes;
        }
        if (minutesAway > 120)
        {
            minutesAway = 120;
        }
        idleReward = minutesAway * gameObject.GetComponent<ImageFade>().scoreMultiplier * (clickBall.GetComponent<Damager>().damageMultiplier + autoBall.GetComponent<Damager>().damageMultiplier + multiBall.GetComponent<Damager>().damageMultiplier);
        if (idleRewardPopupPanel)
        {
            idleRewardPopupPanel.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnApplicationPause()
    {
        SaveIdle();

    }

    private void OnApplicationQuit()
    {
        SaveIdle();
    }

    private void SaveIdle()
    {
        SaveIdleRewards so = new SaveIdleRewards();
        string theTime = DateTime.Now.ToString();
        so.currentTime = theTime;
        AdSaveManager.SaveIdleReward(so);
    }


}
