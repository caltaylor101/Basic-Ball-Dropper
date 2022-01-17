using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIVariables : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject gameRun;
    private int score;
    private string scoreUI;
    private long totalScore;
    
    void Start()
    {
        score = gameRun.GetComponent<ImageFade>().score;
        gameObject.GetComponent<TextMeshProUGUI>().text = score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        gameRun.GetComponent<ImageFade>().prestigeBonus = Math.Round(gameRun.GetComponent<ImageFade>().totalScore * .0006f, 2);

        score = gameRun.GetComponent<ImageFade>().score;
        totalScore = gameRun.GetComponent<ImageFade>().totalScore;
        if (gameObject.name == "PrestigeValue")
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = totalScore.ToString();
        }
        else if (gameObject.name == "BonusValue")
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = gameRun.GetComponent<ImageFade>().prestigeBonus.ToString();
        }

    }
}
