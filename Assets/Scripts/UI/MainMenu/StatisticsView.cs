using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsView : View
{
    [field: SerializeField]
    public MainMenuViewManager ViewManager { get; private set; }

    [field: SerializeField]
    public Transform StatisticsParent { get; private set; }

    [field: SerializeField]
    public GameObject StatisticPrefab { get; private set; }

    public override void OnEnter()
    {
        foreach (Statistic statistic in StatisticsManager.Statistics)
        {
            UIStatistic uiStatistic = Instantiate(StatisticPrefab, StatisticsParent).GetComponent<UIStatistic>();
            uiStatistic.Set(statistic);
        }
    }

    public override void OnExit()
    {
        foreach (Transform child in StatisticsParent)
        {
            Destroy(child.gameObject);
        }
    }

    public void ReturnButtonClick()
    {
        ViewManager.LoadPreviousView();
    }
}
