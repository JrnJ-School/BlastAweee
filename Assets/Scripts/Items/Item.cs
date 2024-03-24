using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An Object in the Game that is Pickupable
/// </summary>
public abstract class Item : MonoBehaviour
{
    [field: SerializeField]
    public string ItemTag { get; private set; }

    private void Awake()
    {
        if (TryGetComponent(out Collider2D collider))
        {
            collider.isTrigger = true;
        }

        this.gameObject.tag = ItemTag;
    }

    public void PickedUp()
    {
        Destroy(gameObject);
    }
}
