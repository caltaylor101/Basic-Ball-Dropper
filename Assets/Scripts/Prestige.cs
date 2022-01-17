using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prestige : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject prestigeVerification;
    [SerializeField] GameObject gameRun;
    [SerializeField] GameObject damager;
    [SerializeField] GameObject damager2;
    private static double newScoreBonus;
    private static double prestigeBonus;
    private static double prestigeBonus2;
    private static bool autoBallExists;
    public static void GetDifferentiatingVariable() 
    {
        SaveObject so = new SaveObject();
        so.maxBalls = 10;
        so.ballCount = 0;
        so.score = 0;
        so.scoreMultiplier = newScoreBonus;
        so.scoreValue = 1;
        so.totalScore = 0;
        so.previousTotalScore = GameObject.Find("GameRun").GetComponent<ImageFade>().totalScore + GameObject.Find("GameRun").GetComponent<ImageFade>().totalScore;
        so.prestigeBonus = 0;
        so.autoBallSpawn = false;
        so.maxIdleBalls = 5;
        so.idleBallCount = 0;
        if (so.scoreMultiplier == 0)
        {
            so.scoreMultiplier = 1;
        }
        SaveManager.Save(so);

        SaveClickBall saveDamager = new SaveClickBall();
        saveDamager.prestigeBonus = prestigeBonus;
        SaveManager.SaveClickBall(saveDamager);
        
        SaveAutoBall saveDamager2 = new SaveAutoBall();
        saveDamager2.prestigeBonus = prestigeBonus2;
        SaveManager.SaveAutoBall(saveDamager);



    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameRun = GameObject.Find("GameRun");
    }

    public void PrestigeWorldVerification()
    {
        prestigeVerification.SetActive(!prestigeVerification.activeSelf);
    }

    public void PrestigeWorld()
    {
        ImageFade script = gameRun.GetComponent<ImageFade>();
        script.prestigeBonus = script.totalScore * .0006f;
        damager.GetComponent<Damager>().damageMultiplier += script.prestigeBonus;
        damager.GetComponent<Damager>().damageMultiplier = Math.Round(damager.GetComponent<Damager>().damageMultiplier, 2);
        damager2.GetComponent<Damager>().damageMultiplier += script.prestigeBonus;
        damager2.GetComponent<Damager>().damageMultiplier = Math.Round(damager2.GetComponent<Damager>().damageMultiplier, 2);
        newScoreBonus = Math.Round((gameRun.GetComponent<ImageFade>().scoreMultiplier + script.prestigeBonus), 2);
        prestigeBonus = script.prestigeBonus + damager.GetComponent<Damager>().prestigeBonus;

        prestigeBonus2 = script.prestigeBonus + damager2.GetComponent<Damager>().prestigeBonus;

        GetDifferentiatingVariable();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       

    }


    



}
