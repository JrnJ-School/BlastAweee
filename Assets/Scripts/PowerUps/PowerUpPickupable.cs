using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickupable : Item
{
    [field: SerializeField, Header("Variables")]
    public string Name { get; set; }

    [field: SerializeField]
    public Sprite Icon { get; set; }

    [field: SerializeField]
    public float Duration { get; set; }

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = Icon;
    }

    public virtual void SetData(PowerUp powerUp)
    {
        Name = powerUp.Name;
        Duration = powerUp.Duration;
        Icon = powerUp.Icon;

        GetComponent<SpriteRenderer>().sprite = Icon;
    }

    public virtual PowerUp ToPowerUp()
    {
        return new PowerUp(Duration)
        {
            Name = Name,
            Icon = Icon
        };
    }
}
