using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBall : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] shatterableBoxes;
    public GameObject gameRun;
    public int upgradeBallCost = 10;
    public void UpgradeBallDamage()
    {
        shatterableBoxes = GameObject.FindGameObjectsWithTag("Hittable");
        if (gameRun.GetComponent<ImageFade>().score >= upgradeBallCost)
        {
            gameRun.GetComponent<ImageFade>().score = gameRun.GetComponent<ImageFade>().score - upgradeBallCost;
            upgradeBallCost = (int)Math.Ceiling((float)upgradeBallCost * 1.25f);
            foreach (GameObject boxes in shatterableBoxes)
        {
                boxes.GetComponent<Shatterable>().damageMultiplier = boxes.GetComponent<Shatterable>().damageMultiplier + 0.01f;
        }
        }

    }
}
