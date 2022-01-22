using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveObject 
{

    public int maxBalls = 10;
    public int ballCount = 0;

    public int score = 0;
    public double scoreMultiplier = 1;
    public int scoreValue = 1;
    public long totalScore = 0;
    public long previousTotalScore = 0;
    public double prestigeBonus = 0;


    public bool autoBallSpawn = false;
    public int maxIdleBalls = 5;
    public int idleBallCount = 0;
}

[System.Serializable]
public class SaveClickBall
{
    public double damagePower = 1;
    public double damageMultiplier = 1;
    public double prestigeBonus;

}
[System.Serializable]

public class SaveAutoBall
{
    public double damagePower = 1;
    public double damageMultiplier = 1;
    public double prestigeBonus;
}
[System.Serializable]

public class SavePrefabs
{
    public List<SavePrefab> prefabList;
}
[System.Serializable]

public class SavePrefab
{
    public float positionX;
    public float positionY;
    public float positionZ;
    public double damagePower;
    public double damageMultiplier;

}
[System.Serializable]

public class HittableObject
{
    public string name;
}
[System.Serializable]

public class HittableObjectList
{
    public List<string> nameList;
}
[System.Serializable]

public class UpgradeBallVariables
{
    public int upgradeBallCost = 10;
    public int upgradeMaxBallsCost = 10;
    public int upgradeIdleBallCost = 20;
    public int upgradeMaxIdleBallsCost = 15;
}

[System.Serializable]
public class SaveUpgradeObstacleVariables
{
    public int upgradeObstacleCost = 10;
    public int upgradeObstacleCost2 = 100;
    public int upgradeObstacleCost3 = 1000;
}

[System.Serializable]
public class SaveUpgradeObstacle1
{
    public float positionX;
    public float positionY;
    public float positionZ;
}

