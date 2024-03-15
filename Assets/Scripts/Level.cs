using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [field: SerializeField]
    public Transform SpawnPosition { get; private set; }
}
