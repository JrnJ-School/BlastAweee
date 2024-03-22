using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject obj = new("GameManager");
                    _instance = obj.AddComponent<GameManager>();
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
    #endregion Singleton

    [field: SerializeField]
    public PlayerController Player { get; private set; }

    [field: SerializeField]
    public GameUI GameUI { get; private set; }

    [field: SerializeField]
    public Camera Camera { get; private set; }

    private Level CurrentLevel { get; set; }

    public void SelectLevel(int levelId)
    {
        GameObject.DontDestroyOnLoad(Player);
        GameObject.DontDestroyOnLoad(GameUI);
        GameObject.DontDestroyOnLoad(Camera);

        GameSceneManager.Instance.OnLevelSceneLoaded += OnLevelSceneLoaded;
        GameSceneManager.Instance.LoadLevelSceneAsync("LevelScene" + levelId);
    }

    private void OnLevelSceneLoaded(object sender, EventArgs e)
    {
        CurrentLevel = GameObject.Find("Level").GetComponent<Level>();

        Player.transform.position = CurrentLevel.SpawnPosition.position;
        Camera.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10.0f);

        Player.ResetOnEnterLevel();
        Player.gameObject.SetActive(true);
        GameUI.gameObject.SetActive(true);
        Camera.gameObject.SetActive(true);
    }

    public void SelectMainMenu()
    {
        Player.gameObject.SetActive(false);

        GameSceneManager.Instance.OnMainMenuSceneLoaded += OnMainMenuSceneLoaded;
        GameSceneManager.Instance.LoadMainMenuSceneAsync();
    }

    private void OnMainMenuSceneLoaded(object sender, EventArgs e)
    {
        GameUI.gameObject.SetActive(false);
        Camera.gameObject.SetActive(false);
    }
}
