using UnityEngine;
using UnityEngine.UI;

public class CarControlSphere : MonoBehaviour
{

    public Rigidbody spehere;

    public float forwardAcc = 3f, backAcc = 2f, maxSpeed = 50f, turnStrength = 180f, gravityForce= 10f, dragOnGround = 3f, initialAcc = 2f;
    
    //fuel variables
    /*
    private float carFuel = 105;
    public float maxCarFuel = 105, fuelSubstractTime = 1.0;
    private string carFuelString;
    public Text carFuelText;
    */

    public float maxRotation = 90f;

    private float speedInput, turnInput;

    public bool grounded;

    public LayerMask whatIsGround;

    public float groundRayLength = 0.5f;
    public Transform groundRayPoint;

    public Transform leftFrontWheel, rightFrontWheel;
    public float maxWheelTurn = 25f;

    // Start is called before the first frame update
    void Start()
    {
        spehere.transform.parent = null;
        //forwardAcc = initialAcc; //to start slow

        //fuel
        /*
        carFuel = maxCarFuel;
        InvokeRepeating("lessFuel", 3.0f, fuelSubstractTime);
        carFuelString = carFuel.ToString();
        */
    }

    // Update is called once per frame
    void Update()
    {
        speedInput = 0;

        /*
        if (Input.GetAxis("Vertical") > 0) {
            speedInput = Input.GetAxis("Vertical") * forwardAcc * 1000f;
        }

        else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * backAcc * 1000f;
        }
        */

        speedInput = forwardAcc * 1000f; //change acc in time to SPEED UP

        transform.position = spehere.position;

        turnInput = Input.GetAxis("Horizontal");

        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime, 0f));

        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x,
                                                       (turnInput * maxWheelTurn) - 180,
                                                        leftFrontWheel.localRotation.eulerAngles.z);

        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x,
                                                        (turnInput * maxWheelTurn),
                                                        rightFrontWheel.localRotation.eulerAngles.z);

    }

    void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;

        if(Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength,whatIsGround))
        {
            grounded = true;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        if (grounded)
        {
            spehere.drag = dragOnGround;
            if (Mathf.Abs(speedInput) > 0)
            {
                spehere.AddForce(transform.forward * speedInput);
            }
        }
        else
        {
            spehere.drag = 0.1f;
            spehere.AddForce(Vector3.up * -gravityForce * 100);
        }

        
    }


    /*
    void lessFuel()
    {
        carFuel -= 0.5;
        carFuelString = carFuel.ToString();

    }
    */
}
