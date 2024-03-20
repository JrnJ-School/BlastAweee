using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp
{
    public string Name { get; set; }

    public Sprite Icon { get; set; }

    public float Duration { get; private set; }

    public event Action OnExpired;
    public event Action<float> DurationChanged;

    public PowerUp()
    {
        
    }

    public PowerUp(float duration)
    {
        Duration = duration;
    }

    public virtual void SetDuration(float duration)
    {
        Duration = duration;
        DurationChanged?.Invoke(Duration);
    }

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
