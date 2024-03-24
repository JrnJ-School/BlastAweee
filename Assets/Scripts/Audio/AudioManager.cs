using UnityEngine.Audio;
using UnityEngine;
using Unity.VisualScripting;
using System;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();
                if (_instance == null)
                {
                    GameObject obj = new("AudioManager");
                    _instance = obj.AddComponent<AudioManager>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        SetSounds();
    }
    #endregion Singleton

    [field: SerializeField]
    private Sound[] AllSounds { get; set; }

    private Sound[] Sounds { get; set; }

    private void SetSounds()
    {
        Sounds = new Sound[AllSounds.Length];

        foreach (Sound sound in AllSounds)
        {
            sound.AudioSource = gameObject.AddComponent<AudioSource>();
            sound.AudioSource.clip = sound.AudioClip;

            sound.AudioSource.volume = sound.Volume;
            sound.AudioSource.pitch = sound.Pitch;

            Sounds[(int)sound.Id] = sound;
        }
    }

    public static void Play(Sound.SoundId soundId)
    {
        AudioManager.Instance.Sounds[(int)soundId].AudioSource.Play();
    }
}
