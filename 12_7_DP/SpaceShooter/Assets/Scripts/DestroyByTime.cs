using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {
    public float lifeTime;
    float elapsedTime;

    private void Start()
    {
        elapsedTime = 0.0f;
    }
    // Update is called once per frame
    void Update () {
        elapsedTime = elapsedTime + Time.deltaTime; //deltaTime => 이전 프레임부터 다음 프레임까지 걸린 시간. 매번 다른 시간이 들어감.
        if(elapsedTime >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
