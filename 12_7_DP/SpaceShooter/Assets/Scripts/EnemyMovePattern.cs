using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovePattern : MonoBehaviour {
    Rigidbody rb;
    
    //방향 전환 딜레이 변수
    public Vector2 startDelay;
    public Vector2 evasionDelay;
    public Vector2 evasionWaiting;

    //방향 전환시 최대 속도
    public float maxEvasionSpeed;

    //초당 움직임 속도 배율
    public float deltaSpeed;

    //Z축 회전 기울기
    public float tilt;

    //바운더리
    public Boundary boundary;

    //방향 전환 로직으로 정해진 방향
    float targetEvasionVelocity;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Evade());
	}
	
    IEnumerator Evade()
    {
        float delay = Random.Range(startDelay.x, startDelay.y);
        yield return new WaitForSeconds(delay);

        //방향 전환 루프
        while (true)
        {
            //방향 결정 : 현재 위치 기준
            targetEvasionVelocity = Random.Range(1, maxEvasionSpeed) * -Mathf.Sign(transform.position.x); //Mathf.Sign => 부호만 추출함(값 X)
            yield return new WaitForSeconds(Random.Range(evasionDelay.x, evasionDelay.y));  //일정 시간 유지

            //다시 방향 0
            targetEvasionVelocity = 0;
            yield return new WaitForSeconds(Random.Range(evasionWaiting.x, evasionWaiting.y));  // 일정 시간 유지
        }

    }

	// Update is called once per frame
	void FixedUpdate () {
        float newXVelocity = Mathf.MoveTowards(rb.velocity.x, targetEvasionVelocity, Time.fixedDeltaTime * deltaSpeed);    //MoveTowards => current에서 target으로 maxDelta만큼 이동함.
        rb.velocity = new Vector3(newXVelocity, 0.0f, rb.velocity.z);
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),  // 새로운 X
            0.0f,                                                      // 고정 좌표
            rb.position.z
            );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

    }
}
