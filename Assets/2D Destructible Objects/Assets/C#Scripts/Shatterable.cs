using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatterable : MonoBehaviour, IHittable
{
    public List<Spawner> spawnPoints;
    public double damage = 0;
    public double maxDamage = 1;
    public double damagePower;
    public double damageMultiplier;
    public int destructionScore;
    public GameObject gameRun;

    private SpriteRenderer render;

    BoxCollider2D objectCollider;
    Color32 brown = new Color32(116, 77, 40, 250);
    // Use this for initialization
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        objectCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        var colorRenderer = gameObject.GetComponent<Renderer>();

        //Call SetColor using the shader property name "_Color" and setting the color to red
        colorRenderer.material.SetColor("_Color", Color.white);
        if (damage <= (maxDamage * 0.25))
        {
            colorRenderer.material.SetColor("_Color", Color.white);
        }
        else if (damage <= (maxDamage * 0.5) && damage > (maxDamage * 0.25))
        {
            colorRenderer.material.SetColor("_Color", Color.yellow);
        }
        else if (damage > (maxDamage * .5) && damage <= (maxDamage * 0.75))
        {
            colorRenderer.material.SetColor("_Color", brown);

        }
        else
        {
            colorRenderer.material.SetColor("_Color", Color.grey);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        damage = damage + (damagePower * damageMultiplier);


        if (damage >= maxDamage)
        {
            HitReceived();
        }

    }
    public void HitReceived()
    {
        Die();
    }

    public void Die()
    {
        render.enabled = false;

        foreach (Spawner spawn in spawnPoints)
        {
            spawn.Spawn();
        }

        gameRun.GetComponent<ImageFade>().score += (int)Math.Ceiling(destructionScore * gameRun.GetComponent<ImageFade>().scoreMultiplier);
        gameRun.GetComponent<ImageFade>().totalScore += (int)Math.Ceiling(destructionScore * gameRun.GetComponent<ImageFade>().scoreMultiplier);
        Destroy(gameObject);
    }
}