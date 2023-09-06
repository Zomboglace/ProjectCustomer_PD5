using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    public float acceleration = 10.0f;
    public float maxSpeed = 20.0f;
    public float drag = 0.25f;
    public float rollingResistance = 0.01f;
    public float rotationSpeed = 100.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    float currentSpeed = 0.0f;
    float currentDrag = 0.0f;
    float currentRotation = 0.0f;


    void calculateForce()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the current speed
        currentSpeed += verticalInput * acceleration * Time.deltaTime;

        // Calculate the current drag
        currentDrag = drag * currentSpeed;


        bool negativeDrag = currentSpeed < 0;
        if (negativeDrag) {
            currentDrag = -currentDrag;
        }
        currentDrag = Mathf.Clamp(currentDrag, drag, maxSpeed);
        if (negativeDrag) {
            currentDrag = -currentDrag;
        }


        bool negativeSpeed = currentSpeed < 0;
        if (negativeSpeed) {
            currentSpeed = -currentSpeed;
        }
        // Apply the drag
        currentSpeed -= currentDrag * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        if (negativeSpeed) {
            currentSpeed = -currentSpeed;
        }


        // Clamp the speed to the max speed
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);


        // Calculate the current rotation
        currentRotation = horizontalInput * rotationSpeed;


        // Log every 1 second
        if (Time.frameCount % 60 == 0) {
            Debug.Log("Speed: " + currentSpeed + " Drag: " + currentDrag);
        }



    }




    // Update is called once per frame
    void Update()
    {
        calculateForce();

        Vector3 moveDirection = transform.forward;

        // Rotate the car based on horizontal input
        transform.Rotate(Vector3.up * currentRotation * Time.deltaTime);

        // Move the car in the direction it's facing
        transform.Translate(moveDirection * currentSpeed * Time.deltaTime, Space.World);
    }
}
