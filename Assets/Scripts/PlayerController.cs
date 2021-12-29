using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float verticalInput;
    public Vector2 testPosition = new Vector2(0, 0);

    // test touch controls
    private float width;
    public float height;
    public Vector2 position;
    public Vector2 startPos;
    public Vector2 direction;
    public string message;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
        position = transform.position;


    }
    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        transform.position = new Vector2(transform.position.x, (transform.position.y + verticalInput));


        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            

            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.
                    startPos = touch.position;
                    message = "begun";
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    direction = touch.position - startPos;
                    if (direction.y > 0 && gameObject.transform.position.y >= 3030)
                    {
                        break;
                    }
                    else if (direction.y > 0)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, -10);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, -10);
                    }
                    startPos = touch.position;
                    //transform.position = new Vector2(transform.position.x, (transform.position.y + (direction.y / Math.Abs(direction.y))));
                    break;
            }
        }

    }
}

