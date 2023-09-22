using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAccelerate : MonoBehaviour
{
    public Rigidbody sphere;       //the car will follow this rigid body sphere

    public float forwardAcc = 5f, maxSpeed = 50f, turnStrength = 180f; 
        
    public float gravityForce = 10f, dragOnGround = 3f; //these values influence how the car behaves while in mid air

    public float speedInput= 3000;
    private float turnInput;    //these values influence how fast the car moves vertically or sideways

    public bool grounded;                       //
    public LayerMask whatIsGround;              //-->  variables influencing 
    public float groundRayLength = 0.5f;        //-->   mid air behaviour                                          
    public Transform groundRayPoint;            //

    public Transform leftFrontWheel, rightFrontWheel;       //wheel turn behaviour variables
    public float maxWheelTurn = 25f;                        //

    //---fuel variables---
    public float carFuel = 110;
    public float maxCarFuel = 110, fuelSubstractTime = 1.0f;
    
    private Vector3 spherePos;
    public Vector3 sphereOffset;

    //death scene
    public GameObject endScene;

    //drunk system

    public BeerDrinking drinking;

    // Start is called before the first frame update
    void Start()
    {
        sphere.transform.parent = null;        //don't know what this does
        InvokeRepeating("ReduceFuel", 3.0f, fuelSubstractTime);
        sphereOffset = new Vector3(0f, .45f, 1.1f);
    }

    // Update is called once per frame
    void Update()
    {
        speedInput += forwardAcc * Time.deltaTime * 10; //increase speed gradually

       // Debug.Log(sphere.position);

        spherePos = sphere.transform.position;

        transform.position = spherePos -sphereOffset ;      //move car to the position of the sphere


        turnInput = Input.GetAxis("Horizontal");      //read steering input

        turnInput = turnInput + drinking.getHorizontalOffset();

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime, 0f)); //rotate car, sphere will automatically follow car's new forward direction

        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * maxWheelTurn) - 180, leftFrontWheel.localRotation.eulerAngles.z);  //turn wheels
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, (turnInput * maxWheelTurn), rightFrontWheel.localRotation.eulerAngles.z);     //

    }

    void FixedUpdate()
    {
        grounded = false;                                                                                                           //
        RaycastHit hit;                                                                                                             //
                                                                                                                                    //--\
        if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatIsGround))                        //--->    some voodoo code to check if 
        {                                                                                                                           //--->  the car is on the ground or not
            grounded = true;                                                                                                        //--/
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;                          //
        }                                                                                                                           //

        if (grounded)
        {
            sphere.drag = dragOnGround;        //makes the car move normally when on ground
            sphere.AddForce(transform.forward * speedInput);       //move the sphere (car will follow)
        }
        else
        {
            sphere.drag = 0.1f;                                        //if the car is mid air it will move slower
            sphere.AddForce(Vector3.up * -gravityForce * 100);         //and will fall faster then normal
        }


    }

    void ReduceFuel()
    {
        carFuel -= 1;
    }
}
