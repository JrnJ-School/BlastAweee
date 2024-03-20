using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatsView : View
{
    [field: SerializeField]
    public GameViewManager ViewManager { get; private set; }

    [field: SerializeField]
    public PlayerController Player { get; private set; }

    public void NoKeysRequiredToggleChanged(bool value)
    {
        Player.NoKeysRequired = value;
    }

    public void InvincibleToggleChanged(bool value)
    {
        Player.SetInvincible(value);
    }

    public void ReturnButtonClick()
    {
        ViewManager.LoadPreviousView();
    }
}
