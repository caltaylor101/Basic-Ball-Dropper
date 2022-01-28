using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advertising : MonoBehaviour
{
    [SerializeField] private GameObject clickBall;
    [SerializeField] private GameObject autoBall;
    [SerializeField] private GameObject multiBall;
    [SerializeField] private GameObject twoXRewardButton;
    public float timeRemaining;
    public float timerLength = 120;
    public bool timerIsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SaveRewards", 1f, 1f);
        timeRemaining = LoadRewards();
        if (timeRemaining > 0)
        {
            timerLength = timeRemaining;
            TwoXRewardPlayer();
        }
        else
        {
            TwoXTimerEnd();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                Debug.Log(timeRemaining);
            }
            else
            {
                TwoXTimerEnd();
            }
        }
    }

    public void TwoXRewardPlayer()
    {
        clickBall.GetComponent<Damager>().damagePower = 2;
        autoBall.GetComponent<Damager>().damagePower = 2;
        multiBall.GetComponent<Damager>().damagePower = 2;
        gameObject.GetComponent<ImageFade>().scoreValue = 2;
        StartTwoXTimer(timerLength);
    }

    public void TwoXTimerEnd()
    {
        timeRemaining = 0;
        clickBall.GetComponent<Damager>().damagePower = 1;
        autoBall.GetComponent<Damager>().damagePower = 1;
        multiBall.GetComponent<Damager>().damagePower = 1;
        gameObject.GetComponent<ImageFade>().scoreValue = 1;
        timerIsRunning = false;
        twoXRewardButton.SetActive(true);

    }

    private void StartTwoXTimer(float timerLength)
    {
        timeRemaining = timerLength;
        timerIsRunning = true;
        twoXRewardButton.SetActive(false);
    }

    public void SaveRewards()
    {
        SaveTwoXObject saveReward = new SaveTwoXObject();
        saveReward.timeRemaining = timeRemaining;
        AdSaveManager.SaveTwoXReward(saveReward);
    }

    public float LoadRewards()
    {
        SaveTwoXObject saveReward = new SaveTwoXObject();
        saveReward = AdSaveManager.LoadRewards();
        return saveReward.timeRemaining;
    }
}
