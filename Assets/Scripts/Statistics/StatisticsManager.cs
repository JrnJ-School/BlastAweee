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

    public static List<Statistic> Statistics { get; private set; } = new();

    // Statistics
    public static EnemyKillStatistic EnemyKillStatistic { get; } = new();
    public static BulletsShotStatistic BulletsShotStatistic { get; } = new();
    public static DeathStatistic DeathStatistic { get; } = new();

    public static void RegisterStatistic(Statistic statistic)
    {
        Statistics.Add(statistic);
    }

    public static object GetStatistic(Statistic statistic)
    {
        switch (statistic.StatisticType)
        {
            case Statistic.StatisticValueType.Int:
                return PlayerPrefs.GetInt(statistic.Key);
            case Statistic.StatisticValueType.Float:
                return PlayerPrefs.GetFloat(statistic.Key);
            case Statistic.StatisticValueType.String:
                return PlayerPrefs.GetString(statistic.Key);
            default: return null;
        }
    }

    public void SetStatistic(Statistic statistic)
    {
        switch (statistic.StatisticType)
        {
            case Statistic.StatisticValueType.Int:
                PlayerPrefs.SetInt(statistic.Key, (int)statistic.GetStatisticValue());
                break;
            case Statistic.StatisticValueType.Float:
                PlayerPrefs.SetFloat(statistic.Key, (float)statistic.GetStatisticValue());
                break;
            case Statistic.StatisticValueType.String:
                PlayerPrefs.SetString(statistic.Key, (string)statistic.GetStatisticValue());
                break;
            default: return;
        }
    }

    // PlayerPrefs
    public void GetStatisticsFromSave()
    {
        
    }

    public void SaveStatisticsToSave()
    {
        PlayerPrefs.Save();
    }
}
