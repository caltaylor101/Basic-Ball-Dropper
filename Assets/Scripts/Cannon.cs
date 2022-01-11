using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public int cannonBullets;
    public Animator cannonAnim;
    public GameObject cannonball;
    public bool pourWater;
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
        if (cannonBullets > 0 && pourWater == false)
        {
            cannonAnim.SetBool("shootCannonball", true);
        }
        if (cannonBullets == 0 || pourWater == true)
        {
            cannonAnim.SetBool("shootCannonball", false);

        }

    }

    public void ShootCannonballRight()
    {
        cannonBullets -= 1;
        //cannonAnim.SetInteger("cannonBullets", cannonBullets);
        GameObject newCannonball = Instantiate(cannonball, new Vector3(7.8f, 2918.233f, 1), Quaternion.identity);
        //newCannonball.GetComponent<Rigidbody2D>().velocity = transform.right * 10f;
        //newCannonball.tag = "cannonTest";
        newCannonball.GetComponent<Rigidbody2D>().AddForce((Vector2.right * 600f) + (Vector2.down * 600f));


    }

    public void ShootCannonballLeft()
    {
        cannonBullets -= 1;
        //cannonAnim.SetInteger("cannonBullets", cannonBullets);
        GameObject newCannonball = Instantiate(cannonball, new Vector3(1.449667f, 2918.233f, 1), Quaternion.identity);
        newCannonball.GetComponent<Rigidbody2D>().AddForce(-(Vector2.right * 600f) + (Vector2.down * 600f));

    }

    public void ShootCannonballDown()
    {
        cannonBullets -= 1;
        //cannonAnim.SetInteger("cannonBullets", cannonBullets);
        GameObject newCannonball = Instantiate(cannonball, new Vector3(5.054342f, 2917.4f, 1), Quaternion.identity);
        newCannonball.GetComponent<Rigidbody2D>().AddForce((Vector2.down * 850f));
    }
}