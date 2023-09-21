using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectPosition : MonoBehaviour
{
    public GameObject objectToFollow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        // Only follow the z position of the object
        transform.position = new Vector3(transform.position.x, transform.position.y, objectToFollow.transform.position.z);
    }
}
