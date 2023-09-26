using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D target;
    public bool isLive = true;

    private float _speed = 2;

    Rigidbody2D rb;
    SpriteRenderer spr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
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
}
