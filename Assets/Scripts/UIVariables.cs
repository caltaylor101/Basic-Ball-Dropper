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
    private double totalScore;

    
    void Start()
    {
        score = gameRun.GetComponent<ImageFade>().score;
            gameObject.GetComponent<TextMeshProUGUI>().text = score.ToString();

    }

    // Update is called once per frame
    void Update()
    {

        CalculatePrestigeBonus();
        
            score = gameRun.GetComponent<ImageFade>().score;
            gameObject.GetComponent<TextMeshProUGUI>().text = score.ToString();

            totalScore = gameRun.GetComponent<ImageFade>().totalScore;
        
       
        if (gameObject.name == "PrestigeValue")
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = totalScore.ToString();
        }
        else if (gameObject.name == "BonusValue")
        {
            
            gameObject.GetComponent<TextMeshProUGUI>().text = gameRun.GetComponent<ImageFade>().prestigeBonus.ToString();
        }
        else if (gameObject.name =="CurrentBonus")
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = gameRun.GetComponent<ImageFade>().scoreMultiplier.ToString();
        }

    }

    private void CalculatePrestigeBonus()
    {
        gameRun.GetComponent<ImageFade>().prestigeBonus = Math.Round(gameRun.GetComponent<ImageFade>().totalScore * .0001f, 4);
        // 150 = .015
        // .005
        if (gameRun.GetComponent<ImageFade>().prestigeBonus - Math.Round(gameRun.GetComponent<ImageFade>().prestigeBonus, 2) >= .009)
        {
            Debug.Log(gameRun.GetComponent<ImageFade>().prestigeBonus - Math.Round(gameRun.GetComponent<ImageFade>().prestigeBonus, 2));
            gameRun.GetComponent<ImageFade>().prestigeBonus = Math.Round(gameRun.GetComponent<ImageFade>().prestigeBonus, 2); 
        }
        else if(gameRun.GetComponent<ImageFade>().prestigeBonus - Math.Round(gameRun.GetComponent<ImageFade>().prestigeBonus, 2) < .009)
        {
            gameRun.GetComponent<ImageFade>().prestigeBonus = Math.Round(Math.Floor(gameRun.GetComponent<ImageFade>().prestigeBonus * 100)/100, 2);
        }
    }
}
