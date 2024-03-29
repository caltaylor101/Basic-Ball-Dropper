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
        so.scoreCalculator = 0;
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
        saveDamager.damageMultiplier = 1 + prestigeBonus;
        Debug.Log(saveDamager.damageMultiplier);
        saveDamager.damagePower = 1;
        saveDamager.prestigeBonus = prestigeBonus;
        SaveManager.SaveClickBall(saveDamager);
        
        SaveAutoBall saveDamager2 = new SaveAutoBall();
        saveDamager2.prestigeBonus = prestigeBonus2;
        saveDamager2.damagePower = 1;
        saveDamager2.damageMultiplier = 1 + prestigeBonus2;
        Debug.Log(saveDamager2.damageMultiplier);
        SaveManager.SaveAutoBall(saveDamager2);

        UpgradeBallVariables saveObject = new UpgradeBallVariables();
        SaveManager.SaveUpgradeBallVariables(saveObject);

        ObstacleVariables obstacleVariables = new ObstacleVariables();
        SaveManager.SaveUpgradeObstacleVariables(obstacleVariables);

        SaveUpgradeObstacle1 obstacle1Save = new SaveUpgradeObstacle1();
        obstacle1Save.positionX = 1;
        obstacle1Save.positionY = 1;
        obstacle1Save.positionZ = 1;
        SaveManager.SaveUpgradeObstacle1Scale(obstacle1Save);

        SaveUpgradeObstacle1 obstacle2Save = new SaveUpgradeObstacle1();
        obstacle1Save.positionX = 4.5f;
        obstacle1Save.positionY = 4.5f;
        obstacle1Save.positionZ = 4.5f;
        SaveManager.SaveUpgradeObstacle1Scale(obstacle2Save);

        SaveUpgradeObstacle1 obstacle3Save = new SaveUpgradeObstacle1();
        obstacle1Save.positionX = 0.5f;
        obstacle1Save.positionY = 0.76f;
        obstacle1Save.positionZ = 0.48f;
        SaveManager.SaveUpgradeObstacle1Scale(obstacle3Save);






        SaveManager.DeleteObjectListData();
        SaveManager.DeleteBallListData();
        SaveManager.DeleteObjectDamageListData();

    }

    void Start()
    {
        gameRun = GameObject.Find("GameRun");

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PrestigeWorldVerification()
    {
        prestigeVerification.SetActive(!prestigeVerification.activeSelf);
    }

    public void PrestigeWorld()
    {
        ImageFade script = gameRun.GetComponent<ImageFade>();
        //script.prestigeBonus = script.totalScore * .0001f;
        damager.GetComponent<Damager>().damageMultiplier += script.prestigeBonus;
        damager.GetComponent<Damager>().damageMultiplier = Math.Round(damager.GetComponent<Damager>().damageMultiplier, 2);
        damager2.GetComponent<Damager>().damageMultiplier += script.prestigeBonus;
        damager2.GetComponent<Damager>().damageMultiplier = Math.Round(damager2.GetComponent<Damager>().damageMultiplier, 2);
        newScoreBonus = Math.Round((gameRun.GetComponent<ImageFade>().scoreMultiplier + script.prestigeBonus), 2);
        prestigeBonus = Math.Round(script.prestigeBonus + damager.GetComponent<Damager>().prestigeBonus, 2);
        prestigeBonus2 = Math.Round(script.prestigeBonus + damager2.GetComponent<Damager>().prestigeBonus, 2);

        Debug.Log(prestigeBonus);
        Debug.Log(prestigeBonus2);
        GetDifferentiatingVariable();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       

    }


    



}
