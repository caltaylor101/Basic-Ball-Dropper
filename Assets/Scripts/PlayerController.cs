using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.EventSystems;

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

    public GameObject otherBall;
    public GameObject selectedObject;
    Vector3 offset;
    Vector3 offset2;


    // ui variables
    public bool uiAccessed = false;

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
        // handles moving an object by tag, like "movable". 
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && Physics2D.OverlapPoint(mousePosition))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject.tag == "Movable")
            {
                if (GameObject.FindWithTag("Movable2"))
                {
                    otherBall = GameObject.FindWithTag("Movable2");
                    otherBall = otherBall.transform.gameObject;
                    offset2 = otherBall.transform.position - mousePosition;
                }

                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
            }
            else if (targetObject.tag == "Movable2")
            {
                otherBall = GameObject.FindWithTag("Movable");
                selectedObject = selectedObject.transform.gameObject;
                otherBall = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
                offset2 = otherBall.transform.position - mousePosition;
            }
            if (targetObject.tag == "MultiMovable1")
            {
                if (GameObject.FindWithTag("MultiMovable2"))
                {
                    otherBall = GameObject.FindWithTag("MultiMovable2");
                    otherBall = otherBall.transform.gameObject;
                    offset2 = otherBall.transform.position - mousePosition;
                }

                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
            }
            else if (targetObject.tag == "MultiMovable2")
            {
                otherBall = GameObject.FindWithTag("MultiMovable1");
                selectedObject = selectedObject.transform.gameObject;
                otherBall = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
                offset2 = otherBall.transform.position - mousePosition;
            }

        }

        if (selectedObject)
        {
            if (mousePosition.y > 3035)
            {
                selectedObject.transform.position = mousePosition + offset;
                if (otherBall)
                {
                    otherBall.transform.position = mousePosition + offset;

                }
            }
        }

        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
            otherBall = null;
        }

        // Handles moving the screen down 
        verticalInput = Input.GetAxis("Vertical");
        transform.position = new Vector3(transform.position.x, (transform.position.y + verticalInput), -10);


        // Handle screen touches.
        if (Input.touchCount > 0 && !selectedObject && !otherBall && !uiAccessed && Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y < 3035.5f)
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
                    else if (direction.y < 0)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - 0.65f, -10);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + 0.65f, -10);
                    }
                    startPos = touch.position;
                    //transform.position = new Vector2(transform.position.x, (transform.position.y + (direction.y / Math.Abs(direction.y))));
                    break;
            }
        }

    }

    
}

