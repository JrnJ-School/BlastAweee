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

    public void LoadScene(string sceneName)
    {
        AsyncOperation asyncSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncSceneOperation.allowSceneActivation = false;

        // Show Loading/Progress here

        asyncSceneOperation.allowSceneActivation = true;
    }
}
