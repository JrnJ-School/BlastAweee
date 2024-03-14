using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStatistic : MonoBehaviour
{
    [field: SerializeField]
    public TextMeshProUGUI NameText { get; private set; }

    [field: SerializeField]
    public TextMeshProUGUI ValueText { get; private set; }

    public void Set(Statistic statistic)
    {
        NameText.text = statistic.Key;
        ValueText.text = statistic.GetStatisticValueAsString();
    }
}
