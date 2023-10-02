using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Image hpBar;
    CharacterStats player;

    private void Start()
    {
        player = GameManager.instance.player.GetComponent<CharacterStats>();
        hpBar.transform.position = Camera.main.WorldToScreenPoint(player.transform.position + new Vector3(0f, -1f, 0f));

    }
    private void Update()
    {
        hpBar.transform.position = Camera.main.WorldToScreenPoint(player.transform.position + new Vector3(0f, -1f, 0f));
        hpBar.fillAmount = player.currentHealth / player.maxHealth;
    }
}
