using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageFade : MonoBehaviour
{
    // the image you want to fade, assign in inspector
    public GameObject ball;
    private SpriteRenderer imageRenderer;

    //Ball settings
    public int maxBalls;
    public int ballCount = 0;
    public int ballSpawnArea = 3036;


    //Score Counter
    public int score;
    public double scoreCalculator;
    public double scoreMultiplier;
    public int scoreValue;
    public double totalScore;
    public double previousTotalScore;
    public double prestigeBonus;

    //Level 2 hourglass animation
    public GameObject hourGlass;
    public GameObject hourGlassGraphic;
    public GameObject hourGlassBase;
    public Vector3 startHourglass;

    // AutoBallSpawner
    public GameObject autoBallSpawnPoint;
    public GameObject autoBall;
    public bool autoBallSpawn = false;
    public Vector3 spawnPosition;
    public float spawnTime = 10f;
    public int maxIdleBalls = 5;
    public int idleBallCount = 0;
    public bool pausing = false;
    
    // MultiBallSpawner
    public GameObject multiBallSpawnPoint;
    public GameObject multiBall;
    public bool multiBallSpawn = false;
    public Vector3 multiSpawnPosition;
    public float multiSpawnTime = 10f;
    public int maxMultiBalls = 5;
    public int multiBallCount = 0;
    public int numberOfMultiBalls = 1;
    public double upgradeMultiBallCost = 2500;



    // save testing
    public SaveObject so;

    // upgrade ball variables
    public int upgradeBallCost = 10;
    public int upgradeIdleBallCost = 15;
    public int upgradeMaxBallsCost = 10;
    public int upgradeMaxIdleBallsCost = 10;
    public int upgradeMaxMultiBallsCost = 30;
    public int upgradeMaxDestructionBallsCost = 10000;


    // upgrade Obstacle Variables
    public int upgradeObstacleCost = 10;
    public int upgradeObstacleCost2 = 50;
    public int upgradeObstacleCost3 = 200;
    public int upgradeObstacleCost4 = 500;
    public int upgradeObstacleCost5 = 1000;
    public GameObject obstacle1Box;
    public GameObject obstacle2Box;

    // bonus gate
    public bool level1Start;
    public bool level2Start;
    public bool level3Start;
    public bool level4Start;
    public GameObject bonusGate1;
    public GameObject bonusGate2;
    public GameObject bonusGate3;
    public GameObject bonusGate4;

    // DestructionBall
    public GameObject destructionBallSpawnPoint;
    public GameObject destructionBall;
    public bool destructionBallSpawn = false;
    public Vector3 destructionSpawnPosition;
    public float destructionSpawnTime = 120f;
    public int maxDestructionBalls = 1;
    public int destructionBallCount = 0;
    public int upgradeDestructionBallCost = 20000;
    public int destructionBounce = 0;
    public int maxDestructionBounce = 1;


    //Rewards
    //2X score reward 
    public bool watchedVideo;




    private void Awake()
    {


        LoadGame();

        // do here what you need to differentiate the level
    }
    void Start()
    {
        startHourglass = hourGlass.GetComponent<Transform>().position;
        StartCoroutine(HourglassAnim(startHourglass));
        if (autoBallSpawn)
        {
            autoBallSpawnPoint.SetActive(true);
        }
        if (multiBallSpawn)
        {
            multiBallSpawnPoint.SetActive(true);
        }


        spawnPosition = autoBallSpawnPoint.GetComponent<Transform>().position;
        multiSpawnPosition = multiBallSpawnPoint.GetComponent<Transform>().position;
        destructionSpawnPosition = destructionBallSpawnPoint.GetComponent<Transform>().position;


        InvokeRepeating("AutoBallSpawn", 0f, spawnTime);
        InvokeRepeating("MultiBallSpawn", 0f, multiSpawnTime);
        InvokeRepeating("DestructionBallSpawn", 0f, destructionSpawnTime);
        InvokeRepeating("SaveGame", 1f, 1f);
    }
    void Update()
    {

        score = (int)Math.Floor(scoreCalculator);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !Physics2D.OverlapPoint(mousePosition))
        {

            var v = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            var userInputPosition = Camera.main.ScreenToWorldPoint(v);

            SpawnBall(userInputPosition);
        }

        spawnPosition = autoBallSpawnPoint.GetComponent<Transform>().position;
        multiSpawnPosition = multiBallSpawnPoint.GetComponent<Transform>().position;
        destructionSpawnPosition = destructionBallSpawnPoint.GetComponent<Transform>().position;

        if (pausing)
        {
            GameObject[] prefabList = GameObject.FindGameObjectsWithTag("Damage");
            List<SavePrefab> savePrefabList = new List<SavePrefab>();
            foreach (GameObject prefab in prefabList)
            {
                SavePrefab sf = new SavePrefab();
                sf.positionX = prefab.GetComponent<Transform>().position.x;
                sf.positionY = prefab.GetComponent<Transform>().position.y;
                sf.positionZ = prefab.GetComponent<Transform>().position.z;
                sf.damagePower = prefab.GetComponent<Damager>().damagePower;
                sf.damageMultiplier = prefab.GetComponent<Damager>().damageMultiplier;

                savePrefabList.Add(sf);
            }
            SavePrefabs savePrefabs = new SavePrefabs();
            savePrefabs.prefabList = savePrefabList;
            SaveManager.SavePrefabs(savePrefabs);
            pausing = false;
        }

        level1Start = Level1Check();
        level2Start = Level2Check();
        level3Start = Level3Check();
        level4Start = Level4Check();
        if (level1Start)
        {
            StartGate();
        }


    }

    void OnApplicationQuit()
    {
        GameObject[] prefabList = GameObject.FindGameObjectsWithTag("Damage");
        List<SavePrefab> savePrefabList = new List<SavePrefab>();
        foreach (GameObject prefab in prefabList)
        {
            if (prefab.name == "Destruction(Clone)")
            {
                
            }
            else
            {
                SavePrefab sf = new SavePrefab();
                sf.positionX = prefab.GetComponent<Transform>().position.x;
                sf.positionY = prefab.GetComponent<Transform>().position.y;
                sf.positionZ = prefab.GetComponent<Transform>().position.z;
                sf.damagePower = prefab.GetComponent<Damager>().damagePower;
                sf.damageMultiplier = prefab.GetComponent<Damager>().damageMultiplier;

                savePrefabList.Add(sf);
            }
            
        }
        SavePrefabs savePrefabs = new SavePrefabs();
        savePrefabs.prefabList = savePrefabList;
        SaveManager.SavePrefabs(savePrefabs);
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            pausing = true;
            GameObject[] prefabList = GameObject.FindGameObjectsWithTag("Damage");
            List<SavePrefab> savePrefabList = new List<SavePrefab>();
            foreach (GameObject prefab in prefabList)
            {
                SavePrefab sf = new SavePrefab();
                sf.positionX = prefab.GetComponent<Transform>().position.x;
                sf.positionY = prefab.GetComponent<Transform>().position.y;
                sf.positionZ = prefab.GetComponent<Transform>().position.z;
                sf.damagePower = prefab.GetComponent<Damager>().damagePower;
                sf.damageMultiplier = prefab.GetComponent<Damager>().damageMultiplier;

                savePrefabList.Add(sf);
            }
            SavePrefabs savePrefabs = new SavePrefabs();
            savePrefabs.prefabList = savePrefabList;
            SaveManager.SavePrefabs(savePrefabs);
        }

    }


    public void SaveGame()
    {
        so.maxBalls = maxBalls;
        so.ballCount = ballCount;
        so.score = score;
        so.scoreCalculator = scoreCalculator;
        so.scoreMultiplier = scoreMultiplier;
        so.scoreValue = scoreValue;
        so.totalScore = totalScore;
        so.previousTotalScore = previousTotalScore;
        so.prestigeBonus = prestigeBonus;
        so.autoBallSpawn = autoBallSpawn;
        so.multiBallSpawn = multiBallSpawn;
        so.destructionBallSpawn = destructionBallSpawn;
        so.maxIdleBalls = maxIdleBalls;
        so.maxMultiBalls = maxMultiBalls;
        so.maxDestructionBalls = maxDestructionBalls;
        so.numberOfMultiBalls = numberOfMultiBalls;
        so.idleBallCount = idleBallCount;
        SaveManager.Save(so);

        SaveClickBall cb = new SaveClickBall();
        cb.damagePower = ball.GetComponent<Damager>().damagePower;
        cb.damageMultiplier = ball.GetComponent<Damager>().damageMultiplier;
        cb.prestigeBonus = ball.GetComponent<Damager>().prestigeBonus;
        SaveManager.SaveClickBall(cb);

        SaveAutoBall ab = new SaveAutoBall();
        ab.damagePower = autoBall.GetComponent<Damager>().damagePower;
        ab.damageMultiplier = autoBall.GetComponent<Damager>().damageMultiplier;
        ab.prestigeBonus = autoBall.GetComponent<Damager>().prestigeBonus;

        SaveManager.SaveAutoBall(ab);

    }

    private void LoadGame()
    {
        Debug.Log("GameLoaded");
        SaveObject so = new SaveObject();
        so = SaveManager.Load();
        maxBalls = so.maxBalls;
        ballCount = so.ballCount;
        score = so.score;
        scoreCalculator = so.scoreCalculator;
        scoreMultiplier = so.scoreMultiplier;
        scoreValue = so.scoreValue;
        totalScore = so.totalScore;
        previousTotalScore = so.previousTotalScore;
        prestigeBonus = so.prestigeBonus;
        autoBallSpawn = so.autoBallSpawn;
        multiBallSpawn = so.multiBallSpawn;
        maxIdleBalls = so.maxIdleBalls;
        maxMultiBalls = so.maxMultiBalls;
        numberOfMultiBalls = so.numberOfMultiBalls;
        idleBallCount = so.idleBallCount;
        destructionBallSpawn = so.destructionBallSpawn;
        maxDestructionBalls = so.maxDestructionBalls;


        SaveClickBall cb = new SaveClickBall();
        cb = SaveManager.LoadClickBall();
        ball.GetComponent<Damager>().damagePower = cb.damagePower;
        if (ball.GetComponent<Damager>().damageMultiplier > 1 + cb.prestigeBonus)
        {
            ball.GetComponent<Damager>().damageMultiplier = cb.damageMultiplier;
        }
        else
        {
            ball.GetComponent<Damager>().damageMultiplier = System.Math.Round(cb.damageMultiplier, 2);
        }
        ball.GetComponent<Damager>().prestigeBonus = cb.prestigeBonus;


        SaveAutoBall ab = new SaveAutoBall();
        ab = SaveManager.LoadAutoball();
        autoBall.GetComponent<Damager>().damagePower = ab.damagePower;
        autoBall.GetComponent<Damager>().damageMultiplier = System.Math.Round(ab.damageMultiplier, 2);
        // add multiball
        multiBall.GetComponent<Damager>().damagePower = ab.damagePower;
        multiBall.GetComponent<Damager>().damageMultiplier = System.Math.Round(ab.damageMultiplier, 2);
        if (autoBall.GetComponent<Damager>().damageMultiplier > 1 + cb.prestigeBonus)
        {
            autoBall.GetComponent<Damager>().damageMultiplier = ab.damageMultiplier;
            multiBall.GetComponent<Damager>().damageMultiplier = ab.damageMultiplier;
        }
        else
        {
            autoBall.GetComponent<Damager>().damageMultiplier = System.Math.Round(ab.damageMultiplier, 2);
            multiBall.GetComponent<Damager>().damageMultiplier = System.Math.Round(ab.damageMultiplier, 2);
        }
        autoBall.GetComponent<Damager>().prestigeBonus = ab.prestigeBonus;



        SavePrefabs sp = new SavePrefabs();
        sp = SaveManager.LoadPrefabs();
        if (sp.prefabList != null)
        {
            ballCount = 0;
            foreach (SavePrefab prefab in sp.prefabList)
            {
                GameObject loadedBall = Instantiate(ball, new Vector3(prefab.positionX, prefab.positionY, prefab.positionZ), Quaternion.identity);
                loadedBall.AddComponent<Rigidbody2D>();
                ballCount += 1;
            }
            idleBallCount = 0;
        }



        UpgradeBallVariables ballVariables = new UpgradeBallVariables();
        ballVariables = SaveManager.LoadUpgradeBallVariables();
        if (ballVariables != null)
        {
            upgradeBallCost = ballVariables.upgradeBallCost;
            upgradeIdleBallCost = ballVariables.upgradeIdleBallCost;
            upgradeMaxBallsCost = ballVariables.upgradeMaxBallsCost;
            upgradeMaxIdleBallsCost = ballVariables.upgradeMaxIdleBallsCost;
            upgradeMaxMultiBallsCost = ballVariables.upgradeMaxMultiBallsCost;
            upgradeMaxDestructionBallsCost = ballVariables.upgradeMaxDestructionBallsCost;
            upgradeDestructionBallCost = ballVariables.upgradeDestructionBallCost;
            bonusGate1.GetComponent<BonusGate>().numberOfMultiBalls = ballVariables.numberOfMultiBalls;
            bonusGate2.GetComponent<BonusGate>().numberOfMultiBalls = ballVariables.numberOfMultiBalls;
        }

        ObstacleVariables obstacleVariables = new ObstacleVariables();
        obstacleVariables = SaveManager.LoadUpgradeObstacleVariables();
        if (obstacleVariables != null)
        {
            upgradeObstacleCost = obstacleVariables.upgradeObstacleCost;
            upgradeObstacleCost2 = obstacleVariables.upgradeObstacleCost2;
            upgradeObstacleCost3 = obstacleVariables.upgradeObstacleCost3;
            upgradeObstacleCost4 = obstacleVariables.upgradeObstacleCost4;
            upgradeObstacleCost5 = obstacleVariables.upgradeObstacleCost5;
        }

        SaveUpgradeObstacle1 obstacle1 = new SaveUpgradeObstacle1();
        obstacle1 = SaveManager.LoadObstacle1();
        if (obstacle1.positionX != 0)
        {
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle1");
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<Transform>().localScale = new Vector3(obstacle1.positionX, obstacle1.positionY, obstacle1.positionZ);
            }
        }
        SaveUpgradeObstacle1 obstacle2 = new SaveUpgradeObstacle1();
        obstacle2 = SaveManager.LoadObstacle2();
        if (obstacle2.positionX != 0)
        {
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle2");
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<Transform>().localScale = new Vector3(obstacle2.positionX, obstacle2.positionY, obstacle2.positionZ);
            }
        }
        
        SaveUpgradeObstacle1 obstacle3 = new SaveUpgradeObstacle1();
        obstacle3 = SaveManager.LoadObstacle3();
        if (obstacle3.positionX != 0)
        {
            hourGlassGraphic.GetComponent<Transform>().localScale = new Vector3(obstacle3.positionX, obstacle3.positionY, obstacle3.positionZ);
            hourGlassBase.GetComponent<Transform>().localScale = new Vector3(obstacle3.positionX, obstacle3.positionY, obstacle3.positionZ);
        }

        SaveUpgradeObstacle1 obstacle4 = new SaveUpgradeObstacle1();
        obstacle4 = SaveManager.LoadObstacle4();
        if (obstacle4.positionX != 0)
        {
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle4");
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<Transform>().localScale = new Vector3(obstacle4.positionX, obstacle4.positionY, obstacle4.positionZ);
            }
        }
        
        SaveUpgradeObstacle5 obstacle5 = new SaveUpgradeObstacle5();
        obstacle5 = SaveManager.LoadObstacle5();
        if (obstacle5.sizeDifference != 0)
        {
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle5");
            foreach (GameObject obstacle in obstacles)
            {
                Debug.Log(obstacle.GetComponent<Transform>().localScale);
                obstacle.GetComponent<Transform>().localScale = new Vector3(obstacle.GetComponent<Transform>().localScale.x - obstacle5.sizeDifference, obstacle.GetComponent<Transform>().localScale.y - obstacle5.sizeDifference, 0);
                Debug.Log(obstacle.GetComponent<Transform>().localScale);

            }
        }

        HittableObjectDamageList hittableList = new HittableObjectDamageList();
        hittableList = SaveManager.LoadHittableObjectDamage();
        if (hittableList.damageObjects != null)
        {
            foreach (HittableObjectDamage damageObject in hittableList.damageObjects)
            {
                if (damageObject.maxDamage == 100 && damageObject.damage != damageObject.maxDamage)
                {
                    GameObject destroyObject = GameObject.Find(damageObject.name);
                    Destroy(destroyObject);
                    GameObject obstacleLoadInstantiation = Instantiate(obstacle1Box, new Vector3(damageObject.positionX, damageObject.positionY, damageObject.positionZ), Quaternion.identity);
                    obstacleLoadInstantiation.name = damageObject.name;
                    obstacleLoadInstantiation.tag = damageObject.tag;
                    obstacleLoadInstantiation.GetComponent<Shatterable>().damage = damageObject.damage;
                    obstacleLoadInstantiation.GetComponent<Shatterable>().maxDamage = damageObject.maxDamage;
                    obstacleLoadInstantiation.GetComponent<Shatterable>().gameRun = gameObject;

                }
                else if (damageObject.maxDamage == 250)
                {
                    GameObject destroyObject = GameObject.Find(damageObject.name);
                    Destroy(destroyObject);
                    GameObject obstacleLoadInstantiation = Instantiate(obstacle2Box, new Vector3(damageObject.positionX, damageObject.positionY, damageObject.positionZ), Quaternion.identity);
                    obstacleLoadInstantiation.name = damageObject.name;
                    obstacleLoadInstantiation.tag = damageObject.tag;
                    obstacleLoadInstantiation.GetComponent<Shatterable>().damage = damageObject.damage;
                    obstacleLoadInstantiation.GetComponent<Shatterable>().maxDamage = damageObject.maxDamage;
                    obstacleLoadInstantiation.GetComponent<Shatterable>().gameRun = gameObject;
                }
            }
        }

        HittableObjectList objectList = new HittableObjectList();
        objectList = SaveManager.LoadHittableObjects();
        if (objectList.nameList != null)
        {
            foreach (string name in objectList.nameList)
            {
                GameObject[] deleteObjectList = GameObject.FindGameObjectsWithTag("Hittable");
                foreach (GameObject objectToDelete in deleteObjectList)
                {
                    if (objectToDelete.name == name)
                    {
                        Destroy(objectToDelete);
                    }
                }
                GameObject deleteObject = GameObject.Find(name);
                Destroy(deleteObject);
            }
        }

        SaveDestructionBall destructionObject = new SaveDestructionBall();
        destructionObject = SaveManager.LoadDestructionBall();
        if (destructionObject != null)
        {
            maxDestructionBounce = destructionObject.maxDestructionBounce;
        }

    }


    private bool Level1Check()
    {
        GameObject box1 = GameObject.Find("Box");
        GameObject box2 = GameObject.Find("Box (1)");
        GameObject box3 = GameObject.Find("Box (2)");
        GameObject box4 = GameObject.Find("Box (3)");

        if (box1 == null && box2 == null && box3 == null && box4 == null)
        {
            return true;
        }
        else return false;
    }
    private bool Level2Check()
    {
        GameObject box1 = GameObject.Find("Level2Box");
        GameObject box2 = GameObject.Find("Level2Box1");
        GameObject box3 = GameObject.Find("Level2Box2");
        GameObject box4 = GameObject.Find("Level2Box3");
        GameObject box5 = GameObject.Find("Level2Box4");

        if (box1 == null && box2 == null && box3 == null && box4 == null && box5 == null)
        {
            return true;
        }
        else return false;
    }
    private bool Level3Check()
    {
        GameObject box1 = GameObject.Find("chest");
        if (box1 == null)
        {
            return true;
        }
        else return false;
        
    }
    private bool Level4Check()
    {
        GameObject box1 = GameObject.Find("chest2");

        if (box1 == null)
        {
            return true;
        }
        else return false;
    }

    private void StartGate()
    {
        bonusGate1.SetActive(true);
        if (level2Start)
        {
            bonusGate2.SetActive(true);
        }
        if (level3Start)
        {
            bonusGate3.SetActive(true);
            bonusGate3.SetActive(true);
        }
        if (level4Start)
        {
            bonusGate4.SetActive(true);
            bonusGate4.SetActive(true);
        }

    }

    private void AutoBallSpawn()
    {
        if (maxIdleBalls > idleBallCount && autoBallSpawn == true)
        {
            idleBallCount++;
            GameObject theBall = Instantiate(autoBall, new Vector3(spawnPosition.x, spawnPosition.y, 1), Quaternion.identity);
            theBall.tag = "Movable2";
            SpriteRenderer theBallColor = theBall.GetComponent<SpriteRenderer>();
            theBallColor.color = Color.red;
            StartCoroutine(FadeImage(true, theBall, theBallColor));
        }
    }
        private void MultiBallSpawn()
    {
        if (maxMultiBalls > multiBallCount && multiBallSpawn == true)
        {
            multiBallCount++;
            GameObject theBall = Instantiate(multiBall, new Vector3(multiSpawnPosition.x, multiSpawnPosition.y, 1), Quaternion.identity);
            theBall.tag = "MultiMovable2";
            SpriteRenderer theBallColor = theBall.GetComponent<SpriteRenderer>();
            theBallColor.color = Color.green;
            StartCoroutine(FadeImage(true, theBall, theBallColor));
        }
    }
            private void DestructionBallSpawn()
    {
        if (maxDestructionBalls > destructionBallCount && destructionBallSpawn == true)
        {
            destructionBallCount++;
            GameObject theBall = Instantiate(destructionBall, new Vector3(destructionSpawnPosition.x, destructionSpawnPosition.y, 1), Quaternion.identity);
            theBall.tag = "DestructionMovable2";
            SpriteRenderer theBallColor = theBall.GetComponent<SpriteRenderer>();
            theBallColor.color = Color.magenta;
            theBall.GetComponent<Destruction>().destructionBounce = 0;
            StartCoroutine(FadeImage(true, theBall, theBallColor));
        }
    }



    IEnumerator HourglassAnim(Vector3 startHourglass)
    {
        for (float alpha = 0f; alpha <= 1f; alpha += Time.unscaledDeltaTime / 2)
        {
            if (alpha > 0.95f)
            {

                alpha = 1f;
                //hourGlass.GetComponent<Transform>().position = startHourglass;

            }

            //hourGlass.GetComponent<Transform>().localScale = new Vector3(alpha, alpha, alpha);
            var delta = alpha / 20;
            hourGlass.GetComponent<Transform>().position = new Vector3(hourGlass.GetComponent<Transform>().position.x, hourGlass.GetComponent<Transform>().position.y + delta, hourGlass.GetComponent<Transform>().position.z);

            if (alpha < 0.95f)
            {
                yield return null;
            }
            else
            {
                yield return StartCoroutine(HourglassDown(startHourglass));
            }
        }

    }

    IEnumerator HourglassDown(Vector3 startHourglass)
    {
        for (float i = 1f; i >= 0; i -= Time.deltaTime / 2)
        {
            if (hourGlass.GetComponent<Transform>().position.y - i > startHourglass.y)
            {
                hourGlass.GetComponent<Transform>().position = new Vector3(hourGlass.GetComponent<Transform>().position.x, hourGlass.GetComponent<Transform>().position.y - i / 20, hourGlass.GetComponent<Transform>().position.z);
            }
            if (i < 0.10f)
            {
                i = 0;
                yield return StartCoroutine(HourglassAnim(startHourglass));
            }
            yield return null;
        }
    }



    private void SpawnBall(Vector3 userInput)
    {
        if (userInput.y >= ballSpawnArea && maxBalls > ballCount)
        {
            ballCount++;
            GameObject theBall = Instantiate(ball, new Vector3(userInput.x, userInput.y, 1), Quaternion.identity);
            StartCoroutine(FadeImage(true, theBall));
        }
    }



    IEnumerator FadeImage(bool fadeAway, GameObject theBall, SpriteRenderer theBallRender = null)
    {
        SpriteRenderer imageRenderer = theBall.GetComponent<SpriteRenderer>();

        if (theBallRender)
        {
            if (theBallRender.color == Color.red)
            {
                for (float i = 0; i <= spawnTime; i += Time.deltaTime)
                {

                    // set color with i as alpha
                    imageRenderer.color = new Color(1, 0, 0, i / spawnTime);
                    yield return null;
                }
                theBall.AddComponent(typeof(Rigidbody2D));


                theBall.tag = "Damage";

            }
            if (theBallRender.color == Color.green)
            {
                for (float i = 0; i <= spawnTime; i += Time.deltaTime)
                {

                    // set color with i as alpha
                    imageRenderer.color = new Color(0, 1, 0, i / spawnTime);
                    yield return null;
                }
                theBall.AddComponent(typeof(Rigidbody2D));


                theBall.tag = "Damage";

            }
            if (theBallRender.color == Color.magenta)
            {
                for (float i = 0; i <= spawnTime; i += Time.deltaTime)
                {

                    // set color with i as alpha
                    imageRenderer.color = new Color(.836f, 0, 1, i / spawnTime);
                    yield return null;
                }
                theBall.AddComponent(typeof(Rigidbody2D));


                theBall.tag = "Damage";

            }

        }
        // fade from opaque to transparent
        else if (fadeAway && !theBallRender)
        {
            // loop over 1 second backwards
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                if (imageRenderer)
                {
                    imageRenderer.color = new Color(1, 1, 1, i / 1);
                }
                // set color with i as alpha
                yield return null;

            }
            if (imageRenderer)
            {
                theBall.AddComponent(typeof(Rigidbody2D));

            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                imageRenderer.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }

}

