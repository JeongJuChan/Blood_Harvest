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
        playerExpBar.fillAmount = player.exp / 100f;
    }
    private void Update()
    {
        playerExpBar.fillAmount = player.exp / 100f;
    }
    public void LevelUp()
    {
        if(player.exp >= 100f)
        {
            player.level++;
            player.exp -= 100f;
            playerLevel.text = "Lv. " + player.level.ToString();
        }
    }
}
