using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLift : MonoBehaviour
{
    // Start is called before the first frame update
    public bool raiseElevator = true;
    public float raiseStartDelay = 5f;
    public float lowerStartDelay = 3f;
    public float localPositionY = 2906.2f;
    public float originalPositionY = 2871.3f;
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 1000f);
        if (raiseElevator)
        {
            StartCoroutine(RaiseElevator(raiseStartDelay));
            raiseElevator = false;
        
        }
    }

    // Update is called once per frame
    void Update()
    {
    }


    IEnumerator RaiseElevator(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        for (float i = 0; i <= 45.87f; i += Time.deltaTime)
        {

            if (gameObject.GetComponent<Rigidbody2D>().position.y >= localPositionY)
            {
                break;
            }
            gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(gameObject.GetComponent<Rigidbody2D>().position.x, (gameObject.GetComponent<Rigidbody2D>().position.y + (Time.deltaTime * 15))));
            yield return null;
        }

        StartCoroutine(LowerElevator(lowerStartDelay));
        yield return null;
    }


    IEnumerator LowerElevator(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        for (float y = 0; y <= 45.87f; y += Time.deltaTime)
        {
            if (gameObject.GetComponent<Rigidbody2D>().position.y <= originalPositionY)
            {
                break;
            }
            gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(gameObject.GetComponent<Rigidbody2D>().position.x, (gameObject.GetComponent<Rigidbody2D>().position.y - (Time.deltaTime * 15))));
            yield return null;
        }
        raiseElevator = true;
        StartCoroutine(RaiseElevator(raiseStartDelay));
        yield return null;
    }


}



