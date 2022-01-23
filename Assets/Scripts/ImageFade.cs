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
    public double scoreMultiplier;
    public int scoreValue;
    public long totalScore;
    public long previousTotalScore;
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


    // save testing
    public SaveObject so;

    // upgrade ball variables
    public int upgradeBallCost = 10;
    public int upgradeIdleBallCost = 15;
    public int upgradeMaxBallsCost = 10;
    public int upgradeMaxIdleBallsCost = 10;

    // upgrade Obstacle Variables
    public int upgradeObstacleCost = 10;
    public int upgradeObstacleCost2 = 100;
    public int upgradeObstacleCost3 = 200;
    public GameObject obstacle1Box;
    public GameObject obstacle2Box;




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
        spawnPosition = autoBallSpawnPoint.GetComponent<Transform>().position;
        InvokeRepeating("AutoBallSpawn", 0f, spawnTime);

        InvokeRepeating("SaveGame", 5f, 5f);
    }
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !Physics2D.OverlapPoint(mousePosition))
        {

            var v = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            var userInputPosition = Camera.main.ScreenToWorldPoint(v);

            SpawnBall(userInputPosition);
        }

        spawnPosition = autoBallSpawnPoint.GetComponent<Transform>().position;


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


    }

    void OnApplicationQuit()
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


    private void SaveGame()
    {
        Debug.Log("GameSaved");
        so.maxBalls = maxBalls;
        so.ballCount = ballCount;
        so.score = score;
        so.scoreMultiplier = scoreMultiplier;
        so.scoreValue = scoreValue;
        so.totalScore = totalScore;
        so.previousTotalScore = previousTotalScore;
        so.prestigeBonus = prestigeBonus;
        so.autoBallSpawn = autoBallSpawn;
        so.maxIdleBalls = maxIdleBalls;
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
        scoreMultiplier = so.scoreMultiplier;
        scoreValue = so.scoreValue;
        totalScore = so.totalScore;
        previousTotalScore = so.previousTotalScore;
        prestigeBonus = so.prestigeBonus;
        autoBallSpawn = so.autoBallSpawn;
        maxIdleBalls = so.maxIdleBalls;
        idleBallCount = so.idleBallCount;

        SaveClickBall cb = new SaveClickBall();
        cb = SaveManager.LoadClickBall();
        ball.GetComponent<Damager>().damagePower = cb.damagePower;
        if (ball.GetComponent<Damager>().damageMultiplier > 1 + cb.prestigeBonus)
        {
            ball.GetComponent<Damager>().damageMultiplier = cb.damageMultiplier;
            Debug.Log("Greater than" + cb.damageMultiplier);
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
        if (autoBall.GetComponent<Damager>().damageMultiplier > 1 + cb.prestigeBonus)
        {
            autoBall.GetComponent<Damager>().damageMultiplier = ab.damageMultiplier;

        }
        else
        {
            autoBall.GetComponent<Damager>().damageMultiplier = System.Math.Round(ab.damageMultiplier, 2);
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
        }

        ObstacleVariables obstacleVariables = new ObstacleVariables();
        obstacleVariables = SaveManager.LoadUpgradeObstacleVariables();
        if (obstacleVariables != null)
        {
            upgradeObstacleCost = obstacleVariables.upgradeObstacleCost;
            upgradeObstacleCost2 = obstacleVariables.upgradeObstacleCost2;
            upgradeObstacleCost3 = obstacleVariables.upgradeObstacleCost3;
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
                else if (damageObject.maxDamage == 1000)
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



    IEnumerator HourglassAnim(Vector3 startHourglass)
    {
        for (float alpha = 0f; alpha <= 1f; alpha += Time.deltaTime / 2)
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
                    imageRenderer.color = new Color(.75f, 0, 0, i / spawnTime);
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

