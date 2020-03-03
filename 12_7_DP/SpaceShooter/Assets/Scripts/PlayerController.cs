using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    Rigidbody rb;
    AudioSource audioSource;
    public float speed;
    public Boundary boundary;
    public float tilt;
    public GameObject boltOriginal;
    public Transform SpawnPoint;

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
	}

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),  // 새로운 X
            0.0f,                                                      // 고정 좌표
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)   // 새로운 Z
            );

        rb.rotation = Quaternion.Euler(rb.velocity.z * tilt, 0.0f, rb.velocity.x * -tilt);

    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(boltOriginal, SpawnPoint.position, Quaternion.identity);

            audioSource.Play();
        }
    }
}
