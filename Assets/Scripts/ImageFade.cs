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
    public Vector3 startHourglass;

    // AutoBallSpawner
    public GameObject autoBallSpawnPoint;
    public GameObject autoBall;
    public bool autoBallSpawn = true;
    public Vector3 spawnPosition;
    public float spawnTime = 10f;
    public int maxIdleBalls = 5;
    public int idleBallCount = 0;





    private void Awake()
    {
        double levelData = Prestige.GetDifferentiatingVariable();
        scoreMultiplier = levelData;
        // do here what you need to differentiate the level
    }
    void Start()
    {
        startHourglass = hourGlass.GetComponent<Transform>().position;
        StartCoroutine(HourglassAnim(startHourglass));

        spawnPosition = autoBallSpawnPoint.GetComponent<Transform>().position;
        InvokeRepeating("AutoBallSpawn", 0f, spawnTime);
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
    }

   


    private void AutoBallSpawn()
    {
        if (maxIdleBalls > ballCount && autoBallSpawn == true)
        {
            ballCount++;
            GameObject theBall = Instantiate(autoBall, new Vector3(spawnPosition.x, spawnPosition.y, 1), Quaternion.identity);
            theBall.tag = "Movable2";
            SpriteRenderer theBallColor = theBall.GetComponent<SpriteRenderer>();
            theBallColor.color = Color.red;
            StartCoroutine(FadeImage(true, theBall, theBallColor));
        }
    }

    

    IEnumerator HourglassAnim(Vector3 startHourglass)
    {
        for (float alpha = 0f; alpha <= 1f; alpha += Time.deltaTime/2)
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
        for (float i = 1f; i >= 0; i -= Time.deltaTime/2)
        {
            if (hourGlass.GetComponent<Transform>().position.y - i > startHourglass.y )
            {
                hourGlass.GetComponent<Transform>().position = new Vector3(hourGlass.GetComponent<Transform>().position.x, hourGlass.GetComponent<Transform>().position.y - i/20, hourGlass.GetComponent<Transform>().position.z);
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

