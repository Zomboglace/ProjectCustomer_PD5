using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //public float moveSpeed = 5f;
    public float force = 5f;
    public float torque = 2f;
    public Rigidbody playerRigidbody;
    public float direction;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
       // playerRigidbody.AddForce(0, force, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the player.
       
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction.
        //Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        // Apply the movement to the player's position.
        //playerRigidbody.MovePosition(transform.position + movement);


        // playerRigidbody.AddForce(horizontalInput * force *Time.deltaTime, 0f, verticalInput * force *Time.deltaTime);
        //playerRigidbody.AddTorque(0f, horizontalInput * torque * Time.deltaTime, 0f);
        //direction=playerRigidbody.eulerAngles.y;

        // Apply torque for rotation
        playerRigidbody.AddTorque(0f, horizontalInput * torque * Time.deltaTime, 0f);

        // Calculate the local forward direction
        Vector3 localForward = transform.forward;

        // Apply force in the local forward direction
        playerRigidbody.AddForce(localForward * verticalInput * force * Time.deltaTime);
    }
}
