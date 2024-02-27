using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsView : View
{
    [field: SerializeField]
    public MainMenuViewManager ViewManager { get; private set; }

    public void ReturnButtonClick()
    {
        StatisticsManager.Instance.GetAllStatistics();
        ViewManager.LoadPreviousView();
    }
}
