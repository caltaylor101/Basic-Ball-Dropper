using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGate : MonoBehaviour
{
    public GameObject gameRun;
    public GameObject multiBall;
    public GameObject clickBall;
    public int numberOfMultiBalls = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameRun.GetComponent<ImageFade>().scoreCalculator += gameRun.GetComponent<ImageFade>().scoreValue * gameRun.GetComponent<ImageFade>().scoreMultiplier;
        gameRun.GetComponent<ImageFade>().totalScore += ((gameRun.GetComponent<ImageFade>().scoreValue * gameRun.GetComponent<ImageFade>().scoreMultiplier)/10);
        if (collision.gameObject.name == "MultiBall(Clone)")
        {
            Vector3 prefabPosition = collision.gameObject.GetComponent<Transform>().position;

            for (int i = 0; i < numberOfMultiBalls; i++)
            {
                if (prefabPosition.x >= 4.6f)
                {
                    GameObject loadedBall = Instantiate(multiBall, new Vector3(prefabPosition.x - i, prefabPosition.y - i, 1), Quaternion.identity);
                    loadedBall.name = "MultiBall(Repetition)";
                    loadedBall.AddComponent<Rigidbody2D>();
                }
                else
                {
                    GameObject loadedBall = Instantiate(multiBall, new Vector3(prefabPosition.x + i, prefabPosition.y + i, 1), Quaternion.identity);
                    loadedBall.name = "MultiBall(Repetition)";
                    loadedBall.AddComponent<Rigidbody2D>();
                }
            }
        }

        if (collision.gameObject.name == "Destruction(Clone)" && gameObject.name == "BonusGate2")
        {
            for (int i = 0; i <= 4; i++)
            {
                GameObject newBall = Instantiate(clickBall, new Vector3(gameObject.GetComponent<Transform>().position.x - i, gameObject.GetComponent<Transform>().position.y - i, 1), Quaternion.identity);
                newBall.AddComponent<Rigidbody2D>();
            }
        }
    }
}
