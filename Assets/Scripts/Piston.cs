using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    // Start is called before the first frame update
    public PhysicsMaterial2D pistonBounce;
    public Animator pistonAnim;
    public int gasParticles;
    public int maxGasParticles;
    public GameObject gameRun;
    public int gasCreatedBallProduction;

    public GameObject gasBall;
    void Start()
    {
        pistonAnim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            // position corners, 4.87,2945 - 7.86,2945.36 - 7.93,2940.21 - 4.92,2940.09
            gameRun.GetComponent<ImageFade>().ballCount -= 1;
            gasParticles += 1;
            float positionX = Random.Range(4.9f, 7.93f);
            float positionY = Random.Range(2940, 2945);
            collision.gameObject.tag = "GasParticle";
            collision.gameObject.GetComponent<Transform>().position = new Vector3(positionX, positionY, -1);
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            collision.gameObject.GetComponent<Rigidbody2D>().sharedMaterial = pistonBounce;

            if (gasParticles >= maxGasParticles)
            {
                pistonAnim.SetBool("compressNow", true);
                gameRun.GetComponent<ImageFade>().gasCreatedBall += 1;

            }
        }
    }


    public void instantiateGasBall()
    {
        Instantiate(gasBall, new Vector3(6.43f, 2934.889f, 1), Quaternion.identity);

    }
}
    

    

