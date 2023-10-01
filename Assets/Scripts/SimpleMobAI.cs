using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMobAI : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;

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
        isLive = true;
        _health = _maxHealth;
    }

    private void Update()
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
}
