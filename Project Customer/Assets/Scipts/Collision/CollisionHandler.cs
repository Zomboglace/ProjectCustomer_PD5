using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public AutoAccelerate carMovement;
    public AudioSource src;
    public AudioClip crashsound, backgroundmusik;

    private bool gameOver = false;

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
        if(collisionInfo.collider.tag == "Obstacle" && !gameOver)
        {
            gameOver = true;
            carMovement.enabled = false;
            endScene.SetActive(true);
            Debug.Log("GAMEOVER!!!");

            //play sound after crash

            src.clip = crashsound;
            src.Play();
        }
    }

    public void endSceneButton()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
