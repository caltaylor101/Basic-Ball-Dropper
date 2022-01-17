using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveObject 
{

    public int maxBalls;
    public int ballCount;

    public int score;
    public double scoreMultiplier;
    public int scoreValue;
    public long totalScore;
    public long previousTotalScore;
    public double prestigeBonus;


    public bool autoBallSpawn;
    public int maxIdleBalls;
    public int idleBallCount;
}
