using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public float crystalDamage;
    public float maxCrystalDamage;
    public float damagePower = 1;
    public float damageMultiplier = 1;

    private List<Spawner> spawnPoints;
    private GameObject waterDropSpawns;

    private Spawner spawn1;
    private Spawner spawn2;
    private Spawner spawn3;

    public GameObject waterDrop;

    public bool spawnSand = false;
    public int spawnSandCount;
   public GameObject crystalSand;

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
        if (crystalDamage >= (maxCrystalDamage / 2) && spawnSandCount < 1)
        {
            spawnSand = true;
            spawnSandCount += 1;
        }
        if (crystalDamage >= (maxCrystalDamage-5) && spawnSandCount == 1)
        {
            spawnSand = true;
            spawnSandCount += 1;
        }
        if (crystalDamage < 50)
        {
            spawnSandCount = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "WaterDrop")
        {
            crystalDamage += (damageMultiplier * damagePower);
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
        if (spawnSand)
        {
         GameObject crystalSandFab = Instantiate(crystalSand, new Vector3(waterDrop.transform.position.x, waterDrop.transform.position.y, -1), Quaternion.identity);

        }
        if (crystalDamage >= maxCrystalDamage)
        {
            gameObject.GetComponent<Transform>().localScale -= new Vector3(.01f, .01f, .01f);

            crystalDamage = 0;
        }
        Destroy(waterDrop);
        spawnSand = false;
    }
}
