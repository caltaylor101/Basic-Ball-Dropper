using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
            var hinge = GetComponent<HingeJoint2D>();
            // Make the hinge motor rotate with 90 degrees per second and a strong force.
            var motor = hinge.motor;
            hinge.motor = motor;
            hinge.useMotor = true;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
