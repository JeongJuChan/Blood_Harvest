using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    // public RuntimeAnimatorController animController;
    public GameObject MainSprite;

    Animator anim;

    CharacterStatsHandler player;

    [SerializeField] private float minDamage = 10f;
    [SerializeField] private float maxDamage = 20f;

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
        Damaged(minDamage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damaged(maxDamage);
    }

    public void Damaged(float damage)
    {
        player.CurrentStats.currentHealth -= damage * Time.deltaTime;
        //Debug.Log(player.CurrentStats.currentHealth);

        if (player.CurrentStats.currentHealth < 0)
        {
            anim.SetTrigger("IsDead");
        }
    }
}
