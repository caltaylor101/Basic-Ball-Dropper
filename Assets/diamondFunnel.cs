using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamondFunnel : MonoBehaviour
{
    public GameObject waterDrop;

    private GameObject waterDropSpawns;
    private List<Spawner> spawnPoints;

    private Spawner spawn1;
    private Spawner spawn2;
    private Spawner spawn3;

    // Start is called before the first frame update
    void Start()
    {
        waterDropSpawns = GameObject.Find("WaterDropSpawns");
        spawn1 = GameObject.Find("WaterDropSpawns/Spawner_1").GetComponent<Spawner>();
        spawn2 = GameObject.Find("WaterDropSpawns/Spawner_2").GetComponent<Spawner>();
        spawn3 = GameObject.Find("WaterDropSpawns/Spawner_3").GetComponent<Spawner>();
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
        if (collision.collider.tag == "WaterDrop")
        {
            waterDrop = collision.gameObject;
            Die();
        }


    }

    public void Die()
    {
        waterDropSpawns.GetComponent<Transform>().position = new Vector3(waterDrop.transform.position.x, waterDrop.transform.position.y, -1);
        foreach (Spawner spawn in spawnPoints)
        {
            spawn.Spawn();
        }
       
        Destroy(waterDrop);
    }
}
