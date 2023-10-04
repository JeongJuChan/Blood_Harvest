using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Image hpBar;
    CharacterStatsHandler player;

    private void Start()
    {
        player = GameManager.instance.player.GetComponent<CharacterStatsHandler>();
        hpBar.transform.position = Camera.main.WorldToScreenPoint(player.transform.position + new Vector3(0f, -1f, 0f));

    }
    private void Update()
    {
        hpBar.transform.position = Camera.main.WorldToScreenPoint(player.transform.position + new Vector3(0f, -1f, 0f));
        hpBar.fillAmount = player.CurrentStats.currentHealth / player.CurrentStats.maxHealth;
    }
}
