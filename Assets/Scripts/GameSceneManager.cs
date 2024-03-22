using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private static GameSceneManager _instance;
    public static GameSceneManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameSceneManager>();
                if (_instance == null)
                {
                    GameObject obj = new("GameSceneManager");
                    _instance = obj.AddComponent<GameSceneManager>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    public event EventHandler OnLevelSceneLoaded;

    public EventHandler LoadLevelSceneAsync(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName).completed += LevelSceneLoadedComplete;
        return OnLevelSceneLoaded;
    }

    private void LevelSceneLoadedComplete(AsyncOperation obj)
    {
        OnLevelSceneLoaded?.Invoke(this, EventArgs.Empty);
    }


    public event EventHandler OnMainMenuSceneLoaded;

    public EventHandler LoadMainMenuSceneAsync()
    {
        SceneManager.LoadSceneAsync("MainMenuScene").completed += MainMenuSceneLoadedComplete;
        return OnMainMenuSceneLoaded;
    }

    private void MainMenuSceneLoadedComplete(AsyncOperation obj)
    {
        OnMainMenuSceneLoaded?.Invoke(this, EventArgs.Empty);
    }
}