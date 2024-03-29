using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameRun;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyAllBalls()
    {
        GameObject[] allBalls = GameObject.FindGameObjectsWithTag("Damage");
        foreach (GameObject ball in allBalls)
        {
            if (ball)
            {
                Destroy(ball);
            }
        }
        gameRun.GetComponent<ImageFade>().ballCount = 0;
        gameRun.GetComponent<ImageFade>().idleBallCount = 0;
    }
}
