using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
    Rigidbody rb;
    public float tumble;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
