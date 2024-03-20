 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenSceneAdditive(string sceneName)
    {
         SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
    
    public void OpenSceneSingle(string sceneName)
    {
         SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
