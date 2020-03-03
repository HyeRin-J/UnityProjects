using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    Rigidbody rb;
    public float speed;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        /*
                 if (gameObject.tag.Equals("Hazzards"))
        {
            Vector3 heading = new Vector3(Random.Range(-5.5f, 5.5f), 0.0f, -15.0f) - transform.position;
            rb.velocity = heading * speed;
        }
         */
    }


    void FixedUpdate () {
        
	}
}
