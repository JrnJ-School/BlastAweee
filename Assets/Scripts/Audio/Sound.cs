using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Internal;

[System.Serializable]
public class Sound
{
    public enum SoundId
    {
        BombShoot = 0,
        ArrowShoot = 1,
        TakeDamage = 2,
        Dash = 3,
        Win = 4,
        Death = 5,
        BombExplode = 6
    }

    [field: SerializeField]
    public SoundId Id { get; private set; }

    [field: SerializeField]
    public AudioClip AudioClip { get; private set; }

    [field: SerializeField, Range(0.0f, 1.0f)]
    public float Volume { get; private set; }

    [field: SerializeField]
    public float Pitch { get; private set; }

    public AudioSource AudioSource { get; set; }
}
