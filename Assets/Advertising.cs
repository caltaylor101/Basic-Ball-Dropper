using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advertising : MonoBehaviour
{
    [SerializeField] private GameObject clickBall;
    [SerializeField] private GameObject autoBall;
    [SerializeField] private GameObject multiBall;
    [SerializeField] private GameObject twoXRewardButton;
    public float timeRemaining = 120;
    public bool timerIsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
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
        clickBall.GetComponent<Damager>().damagePower *= 2;
        autoBall.GetComponent<Damager>().damagePower *= 2;
        multiBall.GetComponent<Damager>().damagePower *= 2;
        gameObject.GetComponent<ImageFade>().scoreValue *= 2;
        StartTwoXTimer();
    }

    public void TwoXTimerEnd()
    {
        timeRemaining = 0;
        clickBall.GetComponent<Damager>().damagePower /= 2;
        autoBall.GetComponent<Damager>().damagePower /= 2;
        multiBall.GetComponent<Damager>().damagePower /= 2;
        gameObject.GetComponent<ImageFade>().scoreValue /= 2;
        timerIsRunning = false;
        twoXRewardButton.SetActive(true);

    }

    private void StartTwoXTimer()
    {
        timeRemaining = 120;
        timerIsRunning = true;
        twoXRewardButton.SetActive(false);
    }
}
