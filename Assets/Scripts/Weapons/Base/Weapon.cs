using System;
using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("Collision")]
    protected BoxCollider2D collider;
    protected float damage;

    [Header("Movement")]
    [SerializeField] protected float moveSpeed = 1f;
    protected Transform offsetTransform;

    protected virtual void Awake()
    {
        collider = GetComponentInChildren<BoxCollider2D>();
    }

    private void Start()
    {
        StartCoroutine(Move());
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollide(collision);
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void SetOffsetTransform(Transform shooterTrans)
    {
        offsetTransform = shooterTrans;
    }

    protected virtual void OnCollide(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<IDamagable>().Damaged(damage);
        }
    }

    protected abstract IEnumerator Move();

    
}
