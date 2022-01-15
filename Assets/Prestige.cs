using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prestige : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject prestigeVerification;
    [SerializeField] GameObject gameRun;
    [SerializeField] GameObject damager;

    void Start()
    {
        
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
        script.prestigeBonus = script.totalScore * .0006f;
        damager.GetComponent<Damager>().damageMultiplier += script.prestigeBonus;
        script.scoreMultiplier += script.prestigeBonus;


    }
    
}
