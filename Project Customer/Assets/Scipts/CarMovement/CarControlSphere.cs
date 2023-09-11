using UnityEngine;

public class CarControlSphere : MonoBehaviour
{

    public Rigidbody spehere;

    public float forwardAcc = 3f, backAcc = 2f, maxSpeed = 50f, turnStrength = 180f;

    private float speedInput, turnInput;

    // Start is called before the first frame update
    void Start()
    {
        spehere.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        speedInput = 0;

        if (Input.GetAxis("Vertical") > 0) {
            speedInput = Input.GetAxis("Vertical") * forwardAcc * 1000f;
        }

        else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * backAcc * 1000f;
        }
        transform.position = spehere.position;

        turnInput = Input.GetAxis("Horizontal");

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(speedInput) > 0)
        {
            spehere.AddForce(transform.forward * speedInput);
        }
    }
}
