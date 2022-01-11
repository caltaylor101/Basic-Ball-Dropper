using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGlass : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cannonball;
    private List<Spawner> spawnPoints;
    private GameObject ballSpawnPoints;

    private Spawner spawn1;
    private Spawner spawn2;
    private Spawner spawn3;

    public int dropVariable;

    void Start()
    {
        ballSpawnPoints = GameObject.Find("WaterSpawnPoints");
        spawn1 = GameObject.Find("WaterSpawnPoints/Spawner_1").GetComponent<Spawner>();
        spawn2 = GameObject.Find("WaterSpawnPoints/Spawner_2").GetComponent<Spawner>();
        spawn3 = GameObject.Find("WaterSpawnPoints/Spawner_3").GetComponent<Spawner>();
        spawnPoints = new List<Spawner>();
        spawnPoints.Add(spawn1);
        spawnPoints.Add(spawn2);
        spawnPoints.Add(spawn3);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Damage")
        {

            ImageFade otherScript = GameObject.Find("GameRun").GetComponent<ImageFade>();
            otherScript.score = otherScript.score + (otherScript.scoreMultiplier * otherScript.scoreValue);
            cannonball = collision.gameObject;

            Die();
        }

    }


    public void HitReceived()
    {
        Die();
    }

    public void Die()
    {
        ballSpawnPoints.GetComponent<Transform>().position = new Vector3(cannonball.transform.position.x, cannonball.transform.position.y, 1);
        foreach (Spawner spawn in spawnPoints)
        {
            spawn.Spawn();
        }
        Destroy(cannonball);
    }
}
