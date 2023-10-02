using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Image hpBar;
    Image playerHpBar;
    CharacterStats player;

    private void Start()
    {
        player = GameManager.instance.player.GetComponent<CharacterStats>();
        playerHpBar = Instantiate(hpBar, canvas.transform);
        playerHpBar.transform.position = Camera.main.WorldToScreenPoint(player.transform.position + new Vector3(0f, -1f, 0f));

    }
    private void Update()
    {
        playerHpBar.transform.position = Camera.main.WorldToScreenPoint(player.transform.position + new Vector3(0f, -1f, 0f));
        playerHpBar.fillAmount = player.currentHealth / player.maxHealth;
    }
}
