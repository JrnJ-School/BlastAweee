using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeView : View
{
    [field: SerializeField]
    public GameViewManager ViewManager { get; private set; }

    public void CheatsButtonClick()
    {
        ViewManager.SwitchView(ViewManager.CheatsView);
    }
}
