using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour
{
    [field: SerializeField]
    public TextMeshProUGUI NameText { get; private set; }

    [field: SerializeField]
    public TextMeshProUGUI DurationText { get; private set; }

    [field: SerializeField]
    public Image Icon { get; private set; }

    public PowerUp PowerUp { get; private set; }

    public void UpdatePowerUp(PowerUp powerUp)
    {
        PowerUp = powerUp;
        NameText.text = powerUp.Name;
        DurationText.text = powerUp.Duration.ToString();
        Icon.sprite = powerUp.Icon;

        powerUp.DurationChanged += (newDuration) => { DurationText.text = Mathf.Round(newDuration).ToString(); };
    }
}
