using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpCount : MonoBehaviour {
    DestroyByContact contact;
    public GameObject hpBar;
    float MaxHp;

	// Use this for initialization
	void Start () {
        contact = gameObject.GetComponent<DestroyByContact>();
        MaxHp = contact.hp;
	}
	
	// Update is called once per frame
	void Update () {
        hpBar.transform.localScale = new Vector3(contact.hp / MaxHp, 0.1f, 1f);
	}
}
