using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageFade : MonoBehaviour
{
    // the image you want to fade, assign in inspector
    public GameObject ball;
    private SpriteRenderer imageRenderer;
    public int maxBalls;
    public int ballCount = 0;
    public int score;
    public int scoreMultiplier;
    public int scoreValue;
    public int ballSpawnArea = 3036;
    


    void Start()
    {

       
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            var v = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            var userInputPosition = Camera.main.ScreenToWorldPoint(v);

            SpawnBall(userInputPosition);


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

    IEnumerator FadeImage(bool fadeAway, GameObject theBall)
    {
        SpriteRenderer imageRenderer = theBall.GetComponent<SpriteRenderer>();

        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {

                // set color with i as alpha
                imageRenderer.color = new Color(1, 1, 1, i / 1);
                yield return null;
            }
            theBall.AddComponent(typeof(Rigidbody2D));
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

