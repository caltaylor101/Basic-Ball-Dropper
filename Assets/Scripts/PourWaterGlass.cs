using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourWaterGlass : MonoBehaviour
{
    // Start is called before the first frame update
    public int waterDrop;
    public int cannonBullets;
    public GameObject cannon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "WaterDrop")
        {
            waterDrop += 1;
        }
        if (waterDrop > 65 && cannon.GetComponent<Cannon>().pourWater == false)
        {
            waterDrop = 0;
            cannonBullets = cannon.GetComponent<Cannon>().cannonBullets;
            cannon.GetComponent<Cannon>().pourWater = true;
            gameObject.GetComponent<Animator>().SetBool("pourWater", true);
            
        }

    }
}
