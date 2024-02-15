using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp
{
    public string Name { get; set; }

    public Sprite Icon { get; set; }

    public float Duration { get; set; }

    public virtual void Use()
    {
        
    }
}
