using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    public float torqueMultiplier = 50;
    public Vector2 shardSpeedMultiplier = new Vector2(150, 500);

    public float fadingSpeed = 1f;
    public float startFadingAfterSeconds = 5f;



    private Rigidbody2D rigid;
    private Vector3 rotation;
    private Vector2 force;
    private bool isActive = true;
    private float currentTime = 0;

    private Renderer[] renderers;

    void Start()
    {
        renderers = gameObject.GetComponentsInChildren<Renderer>();
        rigid = GetComponent<Rigidbody2D>();

        float rndTorqueSpeed = (Random.value + 1) * torqueMultiplier;
        force = new Vector2((Random.value) * shardSpeedMultiplier.x, (Random.value) * shardSpeedMultiplier.y);

        rigid.AddTorque(rndTorqueSpeed);
        float side = Random.value;

        if (side > 0.5)
            force.x *= (-1);
        else
        {
            force.x *= (1);
        }
        rigid.AddForce(force);

        Invoke("AddWaterGlassScript", 5f);

    }

    void Update()
    {
       

    }


    private void AddWaterGlassScript()
    {
        gameObject.AddComponent<WaterGlass>();
    }

    
}

