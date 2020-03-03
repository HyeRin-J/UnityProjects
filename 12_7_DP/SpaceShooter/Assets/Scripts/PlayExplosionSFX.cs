using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayExplosionSFX : MonoBehaviour {
    AudioSource audioSource;
    public AudioClip playingAudioClip, asteroidSFX, playerSFX;
    public bool isAsteroidExplosion = false, isPlayerExplosion = false;
    
	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
        if (isAsteroidExplosion)
        {
            audioSource.PlayOneShot(asteroidSFX);
            isAsteroidExplosion = false;
        }
        if (isPlayerExplosion)
        {
            audioSource.PlayOneShot(playerSFX);
            isPlayerExplosion = false;
        }
    }
}
