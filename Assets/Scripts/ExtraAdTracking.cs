using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraAdTracking : MonoBehaviour
{
    private double remainingRewardTime;
    [SerializeField] private GameObject advertising;
    [SerializeField] private GameObject twoTimesRewardTimer;
    [SerializeField] private GameObject increaseRewardTimerPanel;
    [SerializeField] private GameObject adManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(twoTimesRewardTimer)
        {
            remainingRewardTime = System.Math.Floor(advertising.GetComponent<Advertising>().timeRemaining/60);
            twoTimesRewardTimer.GetComponent<UnityEngine.UI.Text>().text = remainingRewardTime.ToString() + " minutes left.";
        }
    }

    public void OpenIncreaseRewardTimerPanel()
    {
        increaseRewardTimerPanel.SetActive(true);
    }

    public void IncreaseTimerVideo()
    {
        adManager.GetComponent<AdManager>().UserChoseToIncreaseTimerReward();
        increaseRewardTimerPanel.SetActive(false);
    }

    public void NoThanks()
    {
        increaseRewardTimerPanel.SetActive(false);
    }

}
