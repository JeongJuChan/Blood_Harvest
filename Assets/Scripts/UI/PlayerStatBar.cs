using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatBar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerLevel;
    [SerializeField] TextMeshProUGUI playerGold;
    [SerializeField] Image playerExpBar;
    CharacterStats player;

    private void Start()
    {
        player = GameManager.instance.player.GetComponent<CharacterStats>();
        playerLevel.text = "Lv. " + player.level.ToString();
        playerExpBar.fillAmount = player.exp / player.maxExp;
    }
    private void Update()
    {
        playerExpBar.fillAmount = player.exp / player.maxExp;
    }
    public void LevelUp()
    {
        if(player.exp >= player.maxExp)
        {
            player.level++;
            player.exp -= player.maxExp;
            playerLevel.text = "Lv. " + player.level.ToString();
        }
    }
}
