using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject gameTittle;
    public GameObject rules;
    public GameObject options;

    void Start()
    {
        rules.SetActive(false);
        options.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ShowRules()
    {
        rules.SetActive(true);
        gameTittle.SetActive(false);
    }

    public void ShowSettings()
    {
        options.SetActive(true);
        gameTittle.SetActive(false);
    }

    public void GoBackRules()
    {
        gameTittle.SetActive(true);
        rules.SetActive(false);
        options.SetActive(false);
    }
}
