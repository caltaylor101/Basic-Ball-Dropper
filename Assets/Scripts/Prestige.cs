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
    public static double GetDifferentiatingVariable() { return newScoreBonus; }

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       

    }


    



}
