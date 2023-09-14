using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectPosition : MonoBehaviour
{
    public GameObject objectToFollow;
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Only follow the z position of the object
        Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, objectToFollow.transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
