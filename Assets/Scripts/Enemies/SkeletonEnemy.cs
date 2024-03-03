using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemy : Enemy
{
    public override void Move()
    {
        // Evade Player instead of going towards it
        // so the skeleton will keep a distance from the player and shoot it with the bow
    }
}
