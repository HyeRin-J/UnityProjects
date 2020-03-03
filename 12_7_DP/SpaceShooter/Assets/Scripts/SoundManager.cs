using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SFXType
{
    Explosion_Asteroid = 0,
    Explosion_Enemy,
    Explosion_Player,
    Weapon_Enemy,
    Weapon_Player
}

public class SoundManager : MonoBehaviour {
    public AudioClip[] sfxClip;
    public AudioSource sfxSource;

    static SoundManager _instance;

    public static SoundManager instance
    {
        get { return _instance; }
    }

    public void SFX_Play()
    {
        if(sfxSource.clip != null)
        {
            sfxSource.Play();
        }
    }

    public void SFX_PlayOneShot(SFXType sfxType)
    {
        sfxSource.PlayOneShot(sfxClip[(int)sfxType]);
    }

    private void Awake()
    {
        _instance = this;
    }
}
