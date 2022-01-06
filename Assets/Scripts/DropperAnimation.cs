using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DropperAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 startPosition;
    public GameObject otherFlipper;
    public int dropVariable;
    public int maxCapacityDrop;
    public float dropResetDelay;
    public bool readyToDrop = false;
    public float dropStartDelay;

    void Start()
    {

        startPosition = gameObject.GetComponent<Transform>().position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            dropVariable = dropVariable + 1;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            dropVariable = dropVariable - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (dropVariable + otherFlipper.GetComponent<DropperAnimation>().dropVariable > maxCapacityDrop)
        {
            StartCoroutine(DropPanels(dropStartDelay));
            if (readyToDrop)
            { 
                StopAllCoroutines();
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            otherFlipper.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            otherFlipper.GetComponent<DropperAnimation>().StartCoroutine(ResetDropPanels(dropResetDelay));
            StartCoroutine(ResetDropPanels(dropResetDelay));
            }
        }
    }

    IEnumerator DropPanels(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        otherFlipper.GetComponent<DropperAnimation>().readyToDrop = true;
        readyToDrop = true;
        if (readyToDrop) yield break;
    }


    IEnumerator ResetDropPanels(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        for (float i = 1f; i >= 0; i -= 0.1f)
        {
            var hinge = gameObject.GetComponent<HingeJoint2D>();
            var motor = hinge.motor;

            if (gameObject.name == "LeftDropper")
            {
                motor.motorSpeed = -100;
                hinge.motor = motor;
                hinge.useMotor = true;
                if (gameObject.GetComponent<Transform>().rotation.z != 0)
                {
                    i = 1f;
                }
                if (gameObject.GetComponent<Transform>().rotation.z >= 0)
                {
                    i = 0;
                    hinge.useMotor = false;
                    gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
                    gameObject.GetComponent<Transform>().position = startPosition;
                }
            }
            else
            {
                motor.motorSpeed = 100;
                hinge.motor = motor;
                hinge.useMotor = true;
                if (gameObject.GetComponent<Transform>().rotation.z != 0)
                {
                    i = 1f;
                }
                if (gameObject.GetComponent<Transform>().rotation.z <= 0)
                {
                    i = 0;
                    hinge.useMotor = false;
                    gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
                    gameObject.GetComponent<Transform>().position = startPosition;

                }
            }
            
            
            yield return null;
        }
        readyToDrop = false;
        otherFlipper.GetComponent<DropperAnimation>().readyToDrop = false;
    }
}
