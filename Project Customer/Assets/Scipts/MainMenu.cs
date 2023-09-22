using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioSource src, src2;
    public AudioClip sfx1, mainMenuMusic;

    public GameObject gameTittle;
    public GameObject rules, rules2;
    public GameObject nextPanelButton;
    public GameObject options;

    void Start()
    {
        src.clip = sfx1;
        src2.clip = mainMenuMusic;
        src2.Play();

        rules.SetActive(false);
        rules2.SetActive(false);
        options.SetActive(false);
    }

    public void PlayGame()
    {
        src.Play();
        SceneManager.LoadSceneAsync(1);
    }

    public void ShowRules()
    {
        src.Play();
        rules.SetActive(true);
        gameTittle.SetActive(false);
        nextPanelButton.SetActive(true);
    }

    public void ShowNextRules()
    {
        src.Play();
        rules2.SetActive(true);
        nextPanelButton.SetActive(false);
    }

    public void ShowSettings()
    {
        src.Play();
        options.SetActive(true);
        gameTittle.SetActive(false);
    }

    public void GoBackRules()
    {
        src.Play();
        gameTittle.SetActive(true);
        rules2.SetActive(false);
        rules.SetActive(false);
        options.SetActive(false);
    }

    public void Button1()
    {
        src.Play();
    }

}
