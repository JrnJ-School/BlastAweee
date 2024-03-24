using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILevel : View
{
    [field: SerializeField, Header("Components")]
    private TextMeshProUGUI Text { get; set; }

    [field: SerializeField]
    public Button Button { get; private set; }

    [field: SerializeField, Header("Variables")]
    public int LevelId { get; private set; }

    [field: SerializeField]
    private string LevelName { get; set; }

    private void Awake()
    {
        Text.text = LevelName;
    }
}
