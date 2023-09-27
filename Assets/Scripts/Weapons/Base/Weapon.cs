using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("Collision")]
    protected Collider2D collider;
    protected float damage;

    [Header("Movement")]
    [SerializeField] protected float moveSpeed = 1f;

    protected void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    protected void Update()
    {
        Move();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollide(collision);
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    protected abstract void OnCollide(Collider2D collision);
    protected abstract void Move();
}
