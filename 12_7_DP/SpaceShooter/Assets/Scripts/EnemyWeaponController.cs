using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour {
    AudioSource audioSource;
    public GameObject shotOriginal;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;
    GameController gameController;

    void Fire()
    {
        Instantiate(shotOriginal, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play();
    }

	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        gameController = FindObjectOfType<GameController>();
        InvokeRepeating("Fire", delay, fireRate);   //특정 함수를 몇 초 후에 몇 초 주기로 호출할 지를 결정.
	}

    private void FixedUpdate()
    {
        if (gameController.isGameOver)
        {
            CancelInvoke("Fire");
        }
    }
}
