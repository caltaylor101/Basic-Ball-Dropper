using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public int cannonBullets;
    public Animator cannonAnim;
    public GameObject cannonball;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        //GameObject[] balls = GameObject.FindGameObjectsWithTag("cannonTest");
        //foreach (GameObject ball in balls)
        //{
         //   Debug.Log(ball.GetComponent<Rigidbody2D>().velocity);
        //}
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GasProduct")
        {
            cannonBullets += 1;
            Destroy(collision.gameObject);
        }
    }
    public void ShootCannonballBool()
    {
        if (cannonBullets > 0)
        {
            cannonAnim.SetBool("shootCannonball", true);
        }
        if (cannonBullets == 0)
        {
            cannonAnim.SetBool("shootCannonball", false);
        }
    }

    public void ShootCannonballRight()
    {
        cannonBullets -= 1;
        GameObject newCannonball = Instantiate(cannonball, new Vector3(6.99f, 2918.04f, 1), Quaternion.identity);
        //newCannonball.GetComponent<Rigidbody2D>().velocity = transform.right * 10f;
        //newCannonball.tag = "cannonTest";
        newCannonball.GetComponent<Rigidbody2D>().AddForce((Vector2.right * 600f) + (Vector2.down * 600f));


    }

    public void ShootCannonballLeft()
    {
        cannonBullets -= 1;
        GameObject newCannonball = Instantiate(cannonball, new Vector3(1.449667f, 2918.233f, 1), Quaternion.identity);
        newCannonball.GetComponent<Rigidbody2D>().AddForce(-(Vector2.right * 600f) + (Vector2.down * 600f));

    }
}