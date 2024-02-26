using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatisticsManager : MonoBehaviour
{
    #region Singleton
    private static StatisticsManager _instance;
    public static StatisticsManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<StatisticsManager>();
                if (_instance == null)
                {
                    GameObject obj = new("StatisticsManager");
                    _instance = obj.AddComponent<StatisticsManager>();
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

    public List<IStatistic> Statistics { get; set; }

    // 
    public void GetAllStatistics()
    {

    }

    // PlayerPrefs
    public void GetStatisticsFromSave()
    {
        
    }

    public void SaveStatisticsToSave()
    {

    }
}
