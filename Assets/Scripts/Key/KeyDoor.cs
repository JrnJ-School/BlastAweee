using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [field: SerializeField]
    private Sprite ClosedDoorVisual { get; set; }

    [field: SerializeField]
    private Sprite OpenDoorVisual { get; set; }

    [field: SerializeField]
    private SpriteRenderer Renderer { get; set; }

    [field: SerializeField]
    private int KeysNeededToOpen { get; set; }

    private GameUI GameUI { get; set; }

    private bool IsOpen { get; set; } = false;

    private void Awake()
    {
        GameUI = GameManager.Instance.GameUI;
        Renderer.sprite = ClosedDoorVisual;
    }

    public void TryOpen(PlayerController opener)
    {
        if (!IsOpen)
        {
            if (opener.Keys.Count >= KeysNeededToOpen || opener.NoKeysRequired)
            {
                Open();
            }
        }
    }

    private void Open()
    {
        Renderer.sprite = OpenDoorVisual;
        IsOpen = true;
        AudioManager.Play(Sound.SoundId.Win);
        GameUI.NextLevelScreen.gameObject.SetActive(true);
    }
}
