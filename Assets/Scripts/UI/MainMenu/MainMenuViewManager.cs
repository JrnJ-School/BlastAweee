using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuViewManager : ViewManager
{
    [field: SerializeField]
    public HomeView HomeView { get; private set; }

    [field: SerializeField]
    public LevelSelectView LevelSelectView { get; private set; }

    [field: SerializeField]
    public StatisticsView StatisticsView { get; private set; }

    private void Awake()
    {
        this.CurrentView = HomeView;
    }
}
