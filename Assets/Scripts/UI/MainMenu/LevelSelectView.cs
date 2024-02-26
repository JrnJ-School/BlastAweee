using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectView : View
{
    [field: SerializeField]
    public MainMenuViewManager ViewManager { get; private set; }

    [field: SerializeField]
    public Transform LevelButtonsContainer { get; private set; }

    private void Awake()
    {
        UILevel[] uiLevels = LevelButtonsContainer.GetComponentsInChildren<UILevel>();

        foreach (UILevel level in uiLevels)
        {
            // If you set the variable directly it bugs out for some reason
            int levelId = level.LevelId;
            level.Button.onClick.AddListener(() => LevelButtonClick(levelId));
        }
    }

    public void LevelButtonClick(int levelId)
    {
        GameSceneManager.Instance.LoadScene("LevelScene" + levelId);
    }

    public void ReturnButtonClick()
    {
        ViewManager.LoadPreviousView();
    }
}
