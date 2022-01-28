using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardButtons : MonoBehaviour
{
    [SerializeField] private GameObject twoXRewardPanel;
    [SerializeField] private GameObject adManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenRewardDecision()
    {
        twoXRewardPanel.SetActive(!twoXRewardPanel.activeSelf);
    }

    public void WatchVideoAd()
    {
        adManager.GetComponent<AdManager>().UserChoseToWatchAd();
        
    }
}
