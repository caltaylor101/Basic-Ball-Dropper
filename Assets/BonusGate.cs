using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGate : MonoBehaviour
{
    public GameObject gameRun;
    public GameObject multiBall;
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
        gameRun.GetComponent<ImageFade>().scoreCalculator += gameRun.GetComponent<ImageFade>().scoreMultiplier;
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
    }
}
