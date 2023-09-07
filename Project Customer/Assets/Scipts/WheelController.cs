using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;


    public float acceleration = 1000.0f;
    public float breakForce = 750.0f;
    public float maxTurnAngle = 30.0f;

    private float currentAcceleration = 0.0f;
    private float currentBreakForce = 0.0f;
    private float currentTurnAngle = 0.0f;

    void FixedUpdate() {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.Space)) {
            currentBreakForce = breakForce;
        } else {
            currentBreakForce = 0.0f;
        }

        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backRight.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;

        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontRight.steerAngle = currentTurnAngle;
        frontLeft.steerAngle = currentTurnAngle;

        UpdateWheel(frontRight, frontRightTransform, true);
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(backRight, backRightTransform, true);
        UpdateWheel(backLeft, backLeftTransform);
    }

    void UpdateWheel(WheelCollider collider, Transform transform, bool reverse = false) {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        transform.position = position;
        if (reverse)
            rotation *= Quaternion.Euler(0, 180, 0);
        transform.rotation = rotation;
    }
}
