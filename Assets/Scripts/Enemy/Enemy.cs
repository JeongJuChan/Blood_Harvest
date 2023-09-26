using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed;
    private float _health;
    private float _maxHealth;

    public bool isLive;

    public Rigidbody2D target;
    public RuntimeAnimatorController[] animController;

    Rigidbody2D rb;
    SpriteRenderer spr;
    Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!isLive) return;

        Vector2 dir = target.position - rb.position; 
        Vector2 nextdir = dir.normalized * _speed * Time.fixedDeltaTime; 
        rb.MovePosition(rb.position + nextdir); 
        rb.velocity = Vector2.zero;    
    }

    private void LateUpdate()
    {
        if (!isLive) return;

        spr.flipX = target.position.x < rb.position.x;
    }

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        _health = _maxHealth;
    }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animController[data.zombieType];
        _speed = data.zombieSpeed;
        _maxHealth = data.zombieHealth;
        _health = data.zombieHealth;
    }
}