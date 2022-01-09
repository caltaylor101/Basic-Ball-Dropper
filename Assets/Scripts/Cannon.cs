using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public int cannonBullets;
    public Animator cannonAnim;
    // Start is called before the first frame update
    void Start()
    {
       Animator cannonAnim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GasProduct")
        {
            cannonBullets += 1;
            Destroy(collision.gameObject);
        }
    }
    public void ShootCannonball()
    {
        if (cannonBullets > 0)
        {
            cannonAnim.SetBool("shootCannonball", true);
        }
    }
}