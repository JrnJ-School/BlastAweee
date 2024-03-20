using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp
{
    public string Name { get; set; }

    public Sprite Icon { get; set; }

    public float Duration { get; set; }

    public event Action OnExpired;

    public virtual void OnPickup(PlayerController player)
    {
        
    }

    public virtual void Use()
    {
        
    }

    public void SetExpired()
    {
        OnExpired?.Invoke();
    }
}
