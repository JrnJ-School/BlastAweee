using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [field: SerializeField]
    public Sprite ClosedDoorVisual { get; private set; }

    [field: SerializeField]
    public Sprite OpenDoorVisual { get; private set; }

    [field: SerializeField]
    public int KeysNeededToOpen { get; private set; }

    private bool IsOpen { get; set; } = false;

    private void Awake()
    {
        
    }

    public void TryOpen(PlayerController opener)
    {
        if (!IsOpen)
        {
            if (opener.Keys.Count < KeysNeededToOpen)
            {
                return;
            }
        }

        Open();
    }

    private void Open()
    {
        IsOpen = true;
    }
}
