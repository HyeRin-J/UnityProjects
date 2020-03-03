using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelHP : MonoBehaviour {
    public Text levelText;
    public Slider ExpBar;

    public int playerLevel = 1;
    public float playerExp;
    public float boltDamage = 1;

    public int playerHp = 3;

    public RawImage[] HpImage;

    // Use this for initialization
    void Start () {
        playerLevel = 1;
        playerExp = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        ExpBar.value = playerExp / 100.0f;
		if(playerExp >= 100)
        {
            playerLevel++;
            levelText.text = "LV : " + playerLevel;
            playerExp -= 100;
            boltDamage *= 1.5f;
        }
        if (playerHp <= 2)
        {
            if (HpImage[playerHp] != null)
            {
                HpImage[playerHp].gameObject.SetActive(false);
            }
        }
	}
}
