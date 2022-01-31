using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    private SpriteRenderer render;
    private GameObject ballSpawnPoints;
    private List<Spawner> spawnPoints;
    private Spawner spawn1;
    private Spawner spawn2;
    private Spawner spawn3;
    private Spawner spawn4;
    private Spawner spawn5;
    private GameObject destructionObject;
    public int destructionBounce = 0;
    public int maxDestructionBounce = 1;
    private GameObject gameRun;
    // Start is called before the first frame update
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

        gameRun = GameObject.Find("GameRun");
        destructionBounce = gameRun.GetComponent<ImageFade>().destructionBounce;
        maxDestructionBounce = gameRun.GetComponent<ImageFade>().maxDestructionBounce;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag != "Damage" && collision.collider.tag != "Wall" && collision.collider.tag != "DestructionMovable1")
        {

            ImageFade otherScript = GameObject.Find("GameRun").GetComponent<ImageFade>();

            otherScript.scoreCalculator = otherScript.scoreCalculator + (otherScript.scoreMultiplier * otherScript.scoreValue);
            otherScript.totalScore = otherScript.totalScore + (int)Math.Ceiling(otherScript.scoreMultiplier * otherScript.scoreValue);
            destructionObject = collision.gameObject;
            destructionBounce++;

            if (destructionBounce < maxDestructionBounce)
            {
                DestroyObject();
            }
            if (destructionBounce >= maxDestructionBounce)
            {
                DestroyBall();
                otherScript.destructionBallCount--;

            }

        }
    }

    private void DestroyBall()
    {
        render.enabled = false;
        ballSpawnPoints.GetComponent<Transform>().position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1);
        foreach (Spawner spawn in spawnPoints)
        {
            spawn.Spawn();
        }
        ballSpawnPoints.GetComponent<Transform>().position = new Vector3(destructionObject.transform.position.x, destructionObject.transform.position.y, 1);
        foreach (Spawner spawn in spawnPoints)
        {
            spawn.Spawn();
        }
        destructionBounce = 0;
        if (destructionObject.tag == "Hourglass")
        {
            GameObject hourglassGraphic = GameObject.Find("hourglass-graphic");
            Destroy(hourglassGraphic);
        }
        Destroy(destructionObject);
        Destroy(gameObject);
    }

    private void DestroyObject()
    {
        ballSpawnPoints.GetComponent<Transform>().position = new Vector3(destructionObject.transform.position.x, destructionObject.transform.position.y, 1);
        foreach (Spawner spawn in spawnPoints)
        {
            spawn.Spawn();
        }
        if (destructionObject.tag == "Hourglass")
        {
            GameObject hourglassGraphic = GameObject.Find("hourglass-graphic");
            Destroy(hourglassGraphic);
        }
        Destroy(destructionObject);
        
    }
}
