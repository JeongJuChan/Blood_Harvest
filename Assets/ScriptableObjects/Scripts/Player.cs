using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public RuntimeAnimatorController animController;
    public GameObject MainSprite;

    Animator anim;

    CharacterStats player;
    private void Awake()
    {
        anim = MainSprite.GetComponent<Animator>();
    }
    private void Start()
    {
        player = GameManager.instance.player.GetComponent<CharacterStats>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        player.currentHealth -= 10 * Time.deltaTime;
        Debug.Log(player.currentHealth);

        if (player.currentHealth < 0)
        {
            anim.SetTrigger("IsDead");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.currentHealth -= 20 * Time.deltaTime;
        Debug.Log(player.currentHealth);

        if (player.currentHealth < 0)
        {
            anim.SetTrigger("IsDead");
        }
    }
}
