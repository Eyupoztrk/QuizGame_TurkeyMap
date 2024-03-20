using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenGame : MonoBehaviour
{
    [SerializeField] private GameObject OpeningPage;
    [SerializeField] private int waitTime;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("username"))
        {
            //  kayıtlı
            Invoke("OpenMainPage",waitTime);
            
        }
        else
        {
            // yeni giriş
            Invoke("OpenLoginPage",waitTime);
        }
    }

    public void OpenMainPage()
    {
        SceneManager.LoadScene("Scenes/MainScene");
    }

    public void OpenLoginPage()
    {
        OpeningPage.SetActive(false);
    }
    
}
