using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardMoney : MonoBehaviour
{
    [SerializeField] private GameObject rewardMoneyPanel;
    [SerializeField] private GameObject gameRun;
    [SerializeField] private GameObject adObject;
    [SerializeField] private GameObject rewardMoneyButton;
    // Start is called before the first frame update
    void Start()
    {
        if (rewardMoneyPanel.activeSelf && gameObject.GetComponent<UnityEngine.UI.Text>() != null)
        {
            double score = (gameRun.GetComponent<ImageFade>().totalScore / 10) * gameRun.GetComponent<ImageFade>().scoreMultiplier;
            gameObject.GetComponent<UnityEngine.UI.Text>().text = "Watch a video to receive: " + Math.Floor(score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenRewardMoneyPanel()
    {
        rewardMoneyPanel.SetActive(true);
    }

    public void GetMoneyReward()
    {
        adObject.GetComponent<AdManager>().UserChoseToGetMoneyReward();
        rewardMoneyPanel.SetActive(false);
        rewardMoneyPanel.SetActive(false);

    }

    public void NoThanks()
    {
        rewardMoneyPanel.SetActive(false);
        rewardMoneyButton.SetActive(false);
    }
}
