using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    private void OnEnable()
    {
        GetComponent<FollowTarget>().target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
