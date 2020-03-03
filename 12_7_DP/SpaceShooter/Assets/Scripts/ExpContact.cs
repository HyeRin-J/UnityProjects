using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpContact : MonoBehaviour {
    PlayerLevelHP playerLevelHP;

	// Use this for initialization
	void Start () {
        playerLevelHP = FindObjectOfType<PlayerLevelHP>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazzards"))
        {
            playerLevelHP.playerExp += 20;
        }
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<DestroyByContact>().hp -= playerLevelHP.boltDamage;

            if (other.GetComponent<DestroyByContact>().hp <= 0)
            {
                playerLevelHP.playerExp += 25;
                Destroy(other.gameObject);
            }
        }
    }
}
