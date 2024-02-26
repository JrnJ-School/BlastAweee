using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeView : View
{
    [field: SerializeField]
    public MainMenuViewManager ViewManager { get; private set; }

    public void LevelSelectButtonClick()
    {
        ViewManager.SwitchView(ViewManager.LevelSelectView);
    }

    public void StatisticsButtonClick()
    {
        ViewManager.SwitchView(ViewManager.StatisticsView);
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }
}
