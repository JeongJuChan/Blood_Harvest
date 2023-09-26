using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("Weapon Data")]
    public ItemData data;

    [Header("Collision")]
    protected Collider2D _collider;

    protected virtual void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    protected void Start()
    {
        Shoot();
    }

    protected abstract void OnTriggerEnter2D(Collider2D collision);

    protected abstract void Shoot();

}
