using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public int score;
    public GameController gameController;
    public float hp;
    public PlayerLevelHP playerLevelHP;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>(); //GameCotorller 컴포넌트의 형태로 찾을 수 있음
        playerLevelHP = FindObjectOfType<PlayerLevelHP>();

        hp = hp + hp * 1.5f * (gameController.stageNum - 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Hazzards") || other.CompareTag("Enemy") || other.CompareTag("EnemyBolt")) return;

        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
            playerLevelHP.playerHp--;
            if(playerLevelHP.playerHp <= 0)
            {
                gameController.GameOver();
                Destroy(other.gameObject);
            }
        }
        
        if (explosion != null)
        {//explosion 게임오브젝트가 존재할 때 폭발 효과
            Instantiate(explosion, transform.position, Quaternion.identity);

        }

        if (CompareTag("Enemy"))
        {
            if (hp <= 0)
            {
                gameController.SetScore(score);
                Destroy(gameObject);
            }
        }
        else
        {
            gameController.SetScore(score);
            Destroy(gameObject);
        }
    }
}
