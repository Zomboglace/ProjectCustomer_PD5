using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public AutoAccelerate carMovement;
    public AudioSource src;
    public AudioClip crashsound, backgroundmusik;


    //death scene
    public GameObject endScene;

    void Start()
    {
        endScene.SetActive(false);
        src.clip = backgroundmusik;
        src.Play();
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle")
        {
            carMovement.enabled = false;
            endScene.SetActive(true);
            Debug.Log("GAMEOVER!!!");

            //play sound after crash
            src.clip = crashsound;
            src.Play();
        }
    }
}
