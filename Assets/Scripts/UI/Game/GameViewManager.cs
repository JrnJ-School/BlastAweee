using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameViewManager : ViewManager
{
    [field: SerializeField]
    public EscapeView EscapeView { get; private set; }

    [field: SerializeField]
    public CheatsView CheatsView { get; private set; }

    private void Awake()
    {
        this.CurrentView = EscapeView;
    }
}
