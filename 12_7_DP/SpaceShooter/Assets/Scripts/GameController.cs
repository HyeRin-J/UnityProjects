using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//1. 장애물을 (운석, 적) 일정 주기로 생성
//2. 점수관리
//3. 게임 오버 처리

public class GameController : MonoBehaviour {
    public int gameScore;
    public GameObject[] hazzards;   //장애물 원본 오브젝트 배열
    public Vector3 spawnBoundary; //X 랜덤, Y = 0, Z = 13 고정
    public int waveSpawnCount;  //웨이브 당 생성 개수
    public float spawnDelay;    //다음 생성 시간
    public float startDelay;    //최초 생성 시간
    public float waveDelay;     //다음 웨이브 시간
    public int stageNum = 1;

    IEnumerator waveCoroutine;

    //UI 오브젝트
    public Text scoreText;
    public Text gameoverText;
    public Text restartText;
    public Text stageClearText;
    public Text StageText;
    public bool isGameOver;    //게임 오버 상태 여부
    bool isAbleRestart; //재시작 가능 여부

    private float blinkTime = 0.0f;

    public Camera mainCamera;

	// Use this for initialization
	void Start () {
        isGameOver = false;
        isAbleRestart = false;
        gameScore = 0;
        waveCoroutine = SpawnWaves();
        StartCoroutine(waveCoroutine);  //코루틴 시작 함수
	}
	
	// Update is called once per frame
	void Update () {
        
        if (isAbleRestart)
        {
            if(Time.time >= blinkTime)
            {
                blinkTime = Time.time + 0.5f;
                restartText.gameObject.SetActive(!restartText.gameObject.activeSelf);
            }
            if (Input.GetKeyUp(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  //SceneManager 사용하려면 using UnityEngine.SceneManagement 해야함
                                                //GetActiveScene은 현재 사용중인 Scene의 정보를 Get
                                                //LoadScene(Scene #) # 씬을 불러옴
            }
        }
        //게임 오버 시 모두 멈춤
        if (isGameOver)
        {
            GameObject[] movingHazzards = GameObject.FindGameObjectsWithTag("Hazzards");
            GameObject[] movingEnemys = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] enemyBolts = GameObject.FindGameObjectsWithTag("EnemyBolt");

            for (int i = 0; i < movingHazzards.Length; i++)
            {
                if (movingHazzards[i] != null)
                {
                    movingHazzards[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                    movingHazzards[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }
            }

            for (int i = 0; i < movingEnemys.Length; i++)
            {
                if (movingEnemys[i] != null)
                {
                    movingEnemys[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                    movingEnemys[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    movingEnemys[i].GetComponent<EnemyMovePattern>().enabled = false;
                    movingEnemys[i].transform.Find("engines_enemy").gameObject.SetActive(false);
                }
            }

            for (int i = 0; i < enemyBolts.Length; i++)
            {
                if (enemyBolts[i] != null)
                {
                    enemyBolts[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                    enemyBolts[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startDelay);    //호출 시킨 후 startDelay만큼 지연
        while (true)
        {
            for (int i = 0; i < waveSpawnCount; i++)
            {
                //장애물 랜덤 생성
                int index = Random.Range(0, hazzards.Length); //배열.Length => 배열의 길이 
                GameObject original = hazzards[index];

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnBoundary.x, spawnBoundary.x), spawnBoundary.y, spawnBoundary.z); //생성 위치

                Instantiate(original, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnDelay);    //하나 생성 후 spawnDelay만큼 지연

                if (isGameOver)
                {
                    break;
                }
            }

            //Stage Clear 텍스트
            if (!isGameOver)
            {
                yield return new WaitForSeconds(waveDelay / 2);
                if (!isGameOver)
                {
                    stageClearText.gameObject.SetActive(true);
                    stageNum++;
                    StageText.text = "STAGE : " + stageNum;
                }
                yield return new WaitForSeconds(waveDelay / 2); //Wave 끝난 후 WaveDelay만큼 지연
                stageClearText.gameObject.SetActive(false);
            }
            //게임 오버 후, waveDelay만큼 시간이 지난 후에 restartText를 출력
            else
            {
                yield return new WaitForSeconds(waveDelay);
                restartText.gameObject.SetActive(true);
                isAbleRestart = true;

                break;
            }
        }
    }

    public void SetScore(int addScore = 0)
    {
        gameScore += addScore;
        scoreText.text = "Score : " + gameScore;    //UI 갱신
    }

    public void GameOver()
    {
        gameoverText.gameObject.SetActive(true);
        isGameOver = true;
    }
}
