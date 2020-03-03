using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * 0.05f);
        if(transform.position.z <= -30)
        {
            transform.position = new Vector3(0, -5f, 30f);
        }
    }
}
