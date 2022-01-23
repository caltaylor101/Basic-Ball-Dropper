using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
   
    // Start is called before the first frame update
    private int ballCount;
    private SpriteRenderer render;
    private GameObject ballSpawnPoints;
    private Transform ballSpawnLocation;
    private List<Spawner> spawnPoints;
    private Spawner spawn1;
    private Spawner spawn2;
    private Spawner spawn3;
    private Spawner spawn4;
    private Spawner spawn5;


    //Reworking Damage to boxes. 
    public double damagePower = 1;
    public double damageMultiplier = 1;
    public double prestigeBonus;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        ballSpawnPoints = GameObject.Find("BallSpawnPoints");
        spawn1 = GameObject.Find("BallSpawnPoints/Spawner_1").GetComponent<Spawner>();
        spawn2 = GameObject.Find("BallSpawnPoints/Spawner_2").GetComponent<Spawner>();
        spawn3 = GameObject.Find("BallSpawnPoints/Spawner_3").GetComponent<Spawner>();
        spawn4 = GameObject.Find("BallSpawnPoints/Spawner_4").GetComponent<Spawner>();
        spawn5 = GameObject.Find("BallSpawnPoints/Spawner_5").GetComponent<Spawner>();

        spawnPoints = new List<Spawner>();
        spawnPoints.Add(spawn1);
        spawnPoints.Add(spawn2);
        spawnPoints.Add(spawn3);
        spawnPoints.Add(spawn4);
        spawnPoints.Add(spawn5);
        spawnPoints.Add(spawn1);
        spawnPoints.Add(spawn2);
        spawnPoints.Add(spawn3);
        spawnPoints.Add(spawn4);
        spawnPoints.Add(spawn5);
        spawnPoints.Add(spawn1);
        spawnPoints.Add(spawn2);
        spawnPoints.Add(spawn3);
        spawnPoints.Add(spawn4);
        spawnPoints.Add(spawn5);
        spawnPoints.Add(spawn1);
        spawnPoints.Add(spawn2);
        spawnPoints.Add(spawn3);
        spawnPoints.Add(spawn4);
        spawnPoints.Add(spawn5);




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Hittable")
        {
            collision.gameObject.GetComponent<Shatterable>().damagePower = damagePower;
            collision.gameObject.GetComponent<Shatterable>().damageMultiplier = damageMultiplier;

            ImageFade otherScript = GameObject.Find("GameRun").GetComponent<ImageFade>();
            if (gameObject.name == "ClickBall(Clone)")
            {
                otherScript.ballCount--;

            }
            if (gameObject.name == "AutoBall(Clone)")
            {
                otherScript.idleBallCount--;

            }
            otherScript.scoreCalculator = otherScript.scoreCalculator + (otherScript.scoreMultiplier * otherScript.scoreValue);
            otherScript.totalScore = otherScript.totalScore + (int)Math.Ceiling(otherScript.scoreMultiplier * otherScript.scoreValue);
            DestroyBall();
        }
    }

    private void DestroyBall()
    {
       // Debug.Log(ballSpawnPoints.GetComponent<Transform>().position);
        //ballSpawnLocation = ballSpawnPoints.GetComponent<Transform>();
        //ballSpawnLocation = gameObject.transform;
        //Debug.Log(ballSpawnLocation.position);
        //Debug.Log(ballSpawnPoints.GetComponent<Transform>().position);
        //Debug.Log("difference");
        //Debug.Log(gameObject.transform.position);
        render.enabled = false;
        ballSpawnPoints.GetComponent<Transform>().position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1);

        foreach (Spawner spawn in spawnPoints)
        {
            spawn.Spawn();
        }
        Destroy(gameObject);
    }
}
