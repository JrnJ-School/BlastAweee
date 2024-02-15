using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : Entity
{
    public virtual void Move()
    {
        //Rb.velocity = _moveDirection * _activeMoveSpeed;
    }
}
