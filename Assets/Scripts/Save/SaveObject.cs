using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveObject 
{

    public int maxBalls = 10;
    public int ballCount = 0;

    public int score = 0;
    public double scoreCalculator = 0;
    public double scoreMultiplier = 1;
    public int scoreValue = 1;
    public double totalScore = 0;
    public double previousTotalScore = 0;
    public double prestigeBonus = 0;


    public bool autoBallSpawn = false;
    public bool multiBallSpawn = false;
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

public class HittableObjectDamage
{
    public string name;
    public string tag;
    public double damage;
    public double maxDamage;
    public float positionX;
    public float positionY;
    public float positionZ;

}
[System.Serializable]

public class HittableObjectDamageList
{
    public List<HittableObjectDamage> damageObjects;
}

[System.Serializable]
public class UpgradeBallVariables
{
    public int upgradeBallCost = 10;
    public int upgradeMaxBallsCost = 10;
    public int upgradeIdleBallCost = 20;
    public int upgradeMaxIdleBallsCost = 15;
    public int upgradeMultiBallCost = 1000;
    public int upgradeMaxMultiBallsCost = 1000;
    // not used yet public int upgradeMaxMultiBallsCost = 15;

}

[System.Serializable]
public class ObstacleVariables
{
    public int upgradeObstacleCost = 10;
    public int upgradeObstacleCost2 = 50;
    public int upgradeObstacleCost3 = 200;
    public int upgradeObstacleCost4 = 500;
}

[System.Serializable]
public class SaveUpgradeObstacle1
{
    public float positionX;
    public float positionY;
    public float positionZ;
}

