using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public AutoAccelerate carMovement;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle")
        {
            carMovement.enabled = false;
           // Debug.Log("GAMEOVER!!!");
        }
    }
}
