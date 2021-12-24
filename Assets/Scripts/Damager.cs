using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
   
    // Start is called before the first frame update
    private int ballCount;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Hittable")
        {
            ImageFade otherScript = GameObject.Find("GameRun").GetComponent<ImageFade>();
            otherScript.ballCount--;
            otherScript.score = otherScript.score + (otherScript.scoreMultiplier * otherScript.scoreValue);
            DestroyBall();
        }

    }

    private void DestroyBall()
    {
        Destroy(gameObject);
    }
}
