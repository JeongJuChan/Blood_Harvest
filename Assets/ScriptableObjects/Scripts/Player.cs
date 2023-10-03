using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public RuntimeAnimatorController animController;
    public GameObject MainSprite;

    Animator anim;

    CharacterStatsHandler player;
    private void Awake()
    {
        anim = MainSprite.GetComponent<Animator>();
    }
    private void Start()
    {
        player = GetComponent<CharacterStatsHandler>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        player.CurrentStats.currentHealth -= 10 * Time.deltaTime;
        Debug.Log(player.CurrentStats.currentHealth);

        if (player.CurrentStats.currentHealth < 0)
        {
            anim.SetTrigger("IsDead");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.CurrentStats.currentHealth -= 20 * Time.deltaTime;
        Debug.Log(player.CurrentStats.currentHealth);

        if (player.CurrentStats.currentHealth < 0)
        {
            anim.SetTrigger("IsDead");
        }
    }
}
